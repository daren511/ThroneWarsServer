using UnityEngine;
using System.Collections;
using ControleBD;
using System.Threading;

public class onLoading : MonoBehaviour
{
    //---------- VARIABLES ----------//
    // kk
    private bool hasUpdatedGui = false;
    private string title = "Veuillez patienter";
    private string message = "En attente d'un autre joueur...";
    private Rect rect = new Rect((Screen.width - 400) / 2, (Screen.height - 75) / 2, 400, 90);
    public static Thread thread;
    private bool doneLoading = false;

    void Awake()
    {

    }

    void Start()
    {
        FindPlayer();
    }

    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();
        ResourceManager.GetInstance.CreateLogo();
        GUI.Window(-10, rect, doDisplayMessage, title);

        if(!PlayerManager._instance.isLoading && !doneLoading)
        {
            doneLoading = true;
            GameManager._instance._enemySide = PlayerManager._instance._playerSide == 1 ? 2 : 1;
            PlayerManager._instance.SendTeam();
            PlayerManager._instance.isWaitingPlayer = true;
            //CleanScene();
            Application.LoadLevel("placement");
        }
    }

    private void doDisplayMessage(int windowID)
    {
        GUILayout.Space(25);
        GUILayout.Label(message);
    }

    private void FindPlayer()
    {
        thread = new Thread(new ThreadStart(PlayerManager._instance.WaitingForPlayerScreen));
        thread.Start();
    }

    private void CleanScene()
    {
        doneLoading = false;
        PlayerManager._instance.isWaitingPlayer = false;
    }
} 