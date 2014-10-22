using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/// <summary>
/// Initialize the login screen
/// </summary>
public class onStartUp : MonoBehaviour
{
    //---------- VARIABLES
    private bool hasUpdatedGui = false;
    private string userValue = "";
    private string pwdvalue = "";
    private bool canConnect = true;
    private GUIStyle lblError = new GUIStyle();
    // Connection
    private static Socket sck;
    private static IPEndPoint localEndPoint;
    private static string ip = "thronewars.ddns.net";
    private static int port = 50052;
    // Login window
    private static float wL = 430.0f;
    private static float hL = 210.0f;
    // Colors
    public Color primaryColor;
    public Color secondaryColor;
    // Window rectangles
    public Texture background;
    public Texture logo;
    private Rect rectLogin = new Rect((Screen.width - wL) / 2, (Screen.height - hL) / 2, wL, hL);


    void OnGUI()
    {
        hasUpdatedGui = onMenuLoad.updateGUI(hasUpdatedGui, primaryColor, secondaryColor);
        onMenuLoad.createBackground(background);
        onMenuLoad.createLogo(logo);

        onMenuLoad.createQuitWindow();
        GUILayout.Window(2, rectLogin, doLoginWindow, "Login");   // Draw the login window
        onMenuLoad.createMenuWindow(false);
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
        userValue = GUILayout.TextField(userValue, GUILayout.Width(300));
        GUILayout.EndHorizontal();

        // Password
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Mot de passe");
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        pwdvalue = GUILayout.PasswordField(pwdvalue, '*', GUILayout.Width(300));
        GUILayout.EndHorizontal();

        // If the user can't connect
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        lblError.normal.textColor = Color.red;
        if (!canConnect)
            GUILayout.Label("Erreur dans la connexion au serveur", lblError);
        else
            GUILayout.Label("");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        if (userValue.Trim() == "" || pwdvalue.Trim() == "")    // Enable or disable the button is username and password are empty
        {
            GUI.enabled = false;
        }
        else
            GUI.enabled = true;

        // Login button
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Connexion", GUILayout.Width(170), GUILayout.Height(40)))
        {
            try
            {
                // Connect the user to the server
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                localEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                sck.Connect(localEndPoint);

                // So the main menu can have the same colors has the login screen
                onMainMenu.background = background;
                onMainMenu.primaryColor = primaryColor;
                onMainMenu.secondaryColor = secondaryColor;
                Application.LoadLevel("MainMenu");
            }
            catch (SocketException ex)   // The user can't connect to the server
            {
                Debug.Log(ex.Message.ToString());
                canConnect = false;
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}