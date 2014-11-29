using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using ControleBD;
using System;
using System.Runtime.Serialization;

/// <summary>
/// Initialize the login screen
/// </summary>
public class onStartUp : MonoBehaviour
{
    //---------- CONSTANTES
    private const char SPLITTER = '?';

    //---------- VARIABLES
    private bool hasUpdatedGui = false;
    private static string userValue = "";
    private static string pwdvalue = "";
    private string txt = "";
    private bool canConnect = true;
    private bool validInfos = true;
    private bool confirmed = true;
    public static bool alreadyConnected = false;
    private bool hasEnter = false;  // Check fot the button enter (or return)
    private bool show = false;
    Mutex m = new Mutex();
    private GUIStyle lblError = new GUIStyle();
    private GUIStyle lblDev = new GUIStyle();
    // Login window
    private static float wL = 430.0f;
    private static float hL = 210.0f;
    private Rect rectLogin = new Rect((Screen.width - wL) / 2, (Screen.height - hL) / 2, wL, hL);


    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();
        ResourceManager.GetInstance.CreateLogo();
        if (PlayerManager._instance.DEV) { lblDev.normal.textColor = Color.red; GUI.Label(new Rect(10, 10, 200, 30), "DEV", lblDev); }

        onMenuLoad.createQuitWindow();
        GUILayout.Window(2, rectLogin, doLoginWindow, "Login");   // Draw the login window
        onMenuLoad.createMenuWindow(false);
        showWindow();
        if (show)
            GUILayout.Window(-100, new Rect((Screen.width - 200) / 2, Screen.height - 50, 200, 30), doSomething, "", GUIStyle.none);
    }

    void Connection()
    {
        m.WaitOne();
        if (hasEnter)
        {
            try
            {
                PlayerManager._instance.ConnectToServer();

                if (PlayerManager._instance.sck.Connected)
                {
                    // on vérifie les infos entrées par le joueur(usager, mot de passe)
                    string ans = PlayerManager._instance.CheckUserInfos(userValue, pwdvalue);

                    string[] tab = ans.Split(SPLITTER);

                    validInfos = tab[0].Contains("True");
                    if (validInfos)
                        confirmed = tab[1].Contains("True");
                    if (confirmed)
                        alreadyConnected = tab[2].Contains("True");


                    if (validInfos && confirmed && !alreadyConnected)
                    {
                        try
                        {
                            hasEnter = true;
                            PlayerManager._instance.LoadPlayer();
                            PlayerManager.USERNAME = userValue;
                            PlayerManager.PASSWORD = pwdvalue;
                            m.ReleaseMutex();
                            Application.LoadLevel("MainMenu");
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e.Message.ToString());
                        }
                    }
                    else
                        m.ReleaseMutex();

                }
            }
            catch (SocketException ex)   // The user can't connect to the server
            {
                Debug.Log(ex.Message.ToString());
                canConnect = false;
                hasEnter = false;
            }
        }
    }
    void doLoginWindow(int windowID)
    {
        // Ornament
        GUI.DrawTexture(new Rect(20, 4, 31, 40), ColoredGUISkin.Skin.customStyles[0].normal.background);

        // Username
        GUILayout.Space(35);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Usager");
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        checkEnter();
        checkArrowDown();
        GUI.SetNextControlName("User");
        userValue = GUILayout.TextField(userValue, GUILayout.Width(300));
        GUILayout.EndHorizontal();

        // Password
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Mot de passe");
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        checkEnter();
        checkArrowUp();
        GUI.SetNextControlName("PWD");
        pwdvalue = GUILayout.PasswordField(pwdvalue, '*', GUILayout.Width(300));
        GUILayout.EndHorizontal();

        if (GUI.GetNameOfFocusedControl() == string.Empty && !show)
        {
            GUI.FocusControl("User");
        }

        // If the user can't connect
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        lblError.normal.textColor = Color.red;
        if (!canConnect)
        {
            GUILayout.Label("Erreur dans la connexion au serveur", lblError);
            hasEnter = false;
        }
        else if (!validInfos)
        {
            GUILayout.Label("Usager/Mot de passe invalide", lblError);
            hasEnter = false;
        }
        else if (!confirmed)
        {
            GUILayout.Label("Votre compte n'est pas confirmé", lblError);
            hasEnter = false;
        }
        else if (alreadyConnected)
        {
            GUILayout.Label("Ce compte est déjà connecté", lblError);
            hasEnter = false;
        }
        else
            GUILayout.Label("");

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (userValue.Trim() == "" || pwdvalue.Trim() == "")    // Enable or disable the button is username and password are empty
            GUI.enabled = false;
        else
            GUI.enabled = true;

        // Login button
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Connexion", GUILayout.Width(170), GUILayout.Height(40)) && !hasEnter)
        {
            hasEnter = true;
            Connection();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    private void checkEnter()
    {
        if (Event.current.keyCode == KeyCode.Return && !hasEnter)
        {
            if (userValue.Trim() != "" && pwdvalue.Trim() != "")
            {
                hasEnter = true;
                Connection();
            }
        }
    }

    private void checkArrowDown()
    {
        if (Event.current.keyCode == KeyCode.DownArrow)
        {
            GUI.FocusControl("PWD");
        }
    }

    private void checkArrowUp()
    {
        if (Event.current.keyCode == KeyCode.UpArrow)
        {
            GUI.FocusControl("User");
        }
    }

    private void showWindow()
    {
        if (GUI.Button(new Rect(0, Screen.height - 10, 10, 10), "", GUIStyle.none))
            show = !show;
    }
/// <summary>
/// CHA CHAAA...!
/// </summary>
/// <param name="windowID"></param>
    private void doSomething(int windowID)
    {
        GUILayout.BeginHorizontal();
        GUI.SetNextControlName("secret");
        txt = GUILayout.PasswordField(txt, '*', GUILayout.Width(100));
        GUI.FocusControl("secret");
        if (GUILayout.Button("OK", GUILayout.Height(40)))
        {
            PlayerManager._instance.changePort(txt);
            txt = "";
            show = false;
            GUI.FocusControl("User");
        }
        GUILayout.EndHorizontal();
    }

    public static void SetInfos(string username, string password)
    {
        userValue = username;
        pwdvalue = password;
    }
}