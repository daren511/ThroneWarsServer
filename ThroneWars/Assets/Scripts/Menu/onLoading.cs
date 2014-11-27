using UnityEngine;
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
    public static Thread thread;
    private bool doneLoading = false;

    void Awake()
    {

    }
    void Start()
    {
        FindPlayer();
        //StartCoroutine(StartSearch());
    }
    void OnGUI()
    {
        hasUpdatedGui = ResourceManager.GetInstance.UpdateGUI(hasUpdatedGui);
        ResourceManager.GetInstance.CreateBackground();
        ResourceManager.GetInstance.CreateLogo();
        GUI.Window(-10, rect, doDisplayMessage, title);
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 50, 200, 50), "Annuler"))
            cancelLoading();

        if(!PlayerManager._instance.isLoading && !doneLoading)
        {
            doneLoading = true;
            Debug.Log("Ennemi affecté");
            GameManager._instance._enemySide = PlayerManager._instance._playerSide == 1 ? 2 : 1;

            PlayerManager._instance.PrepareGame();
            Application.LoadLevel("placement");
        }
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
        thread = new Thread(new ThreadStart(PlayerManager._instance.Lobby));
        thread.Start();
    }
    IEnumerator WaitForPlayer()
    {
        while (PlayerManager._instance.isWaitingPlayer)
        {
            Debug.Log("En attente d'un joueur");
            Debug.Log(PlayerManager._instance.isWaitingPlayer);
            if ( ReferenceEquals(PlayerManager._instance.isWaitingPlayer, false))
            {
                //Debug.Log("J'vais trouver un joueur...wait for it");
                yield break;
            }
            Debug.Log("minute , je t'attends");
            yield return this;
        }
    }
    IEnumerator StartSearch()
    {
        //if (!started)
        //{
        //    started = true;
        //    yield return new WaitForSeconds(1);
        //    PlayerManager._instance.LookForPlayer();
        //}
        yield return 0;
    }
} 