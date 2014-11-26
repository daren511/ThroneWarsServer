﻿using UnityEngine;
using System.Collections;
using ControleBD;
using System.Threading;

public class onLoading : MonoBehaviour
{
    //---------- VARIABLES ----------//
    private bool hasUpdatedGui = false;
    private string title = "Veuillez patienter";
    private string message = "En attente d'un autre joueur...";
    private Rect rect = new Rect((Screen.width - 400) / 2, (Screen.height - 75) / 2, 400, 90);


    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();
        ResourceManager.GetInstance.CreateLogo();
        GUI.Window(-10, rect, doDisplayMessage, title);
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 50, 200, 50), "Annuler"))
            cancelLoading();
    }

    private void doDisplayMessage(int windowID)
    {
        GUILayout.Space(25);
        GUILayout.Label(message);
    }

    private void cancelLoading()
    {
        PlayerManager._instance.LoadPlayer();
        Application.LoadLevel("MainMenu");
    }

    private void FindPlayer()
    {
        Thread t = new Thread(new ThreadStart(PlayerManager._instance.LookForPlayer));
    }
}
