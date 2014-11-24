using UnityEngine;
using System.Collections;
using ControleBD;

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
    }

    private void doDisplayMessage(int windowID)
    {
        GUILayout.Space(25);
        GUILayout.Label(message);
    }
}
