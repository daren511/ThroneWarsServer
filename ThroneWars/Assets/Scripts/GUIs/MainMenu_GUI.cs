using UnityEngine;
using System.Collections;


/* MainMenu_GUI
 * par Charles Hunter-Roy, 2014
 * simple interface de connexion,
 * pour le projet de fin de D.E.C - Throne Wars
 */
public class MainMenu_GUI : MonoBehaviour
{

    private Rect _containerBox = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 400, 250);
    private Rect _playButton;
    private Rect _optionsButton;
    private Rect _aboutButton;
    private Rect _quitButton;

    public GUISkin _skin;

    private bool quitGUI = false;

    public MainMenu_GUI()
    {
        _quitButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 80, 300, 50);
        _aboutButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 300, 50);
        _optionsButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 20, 300, 50);
        _playButton = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 70, 300, 50);
    }
    void OnGUI()
    {
        GUI.skin = _skin;

        if (quitGUI)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 200, 140), "Etes-vous sur?");
            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 40, 160, 40), "Oui"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2, 160, 40), "Non"))
            {
                quitGUI = false;
            }
        }
        else
        {
            GUI.Box(_containerBox, "Throne Wars - Menu Principal");

            if (GUI.Button(_playButton, "Jouer"))
            {
                //trouver un autre joueur, et connexion a une partie
                Application.LoadLevel("placement");
            }
            if (GUI.Button(_optionsButton, "Options"))
            {
                //options (sons, contraste, etc)
            }
            if (GUI.Button(_aboutButton, "A propos de"))
            {
                for (int i = 0; i < 4; ++i)
                {
                    Debug.Log(PlayerManager._instance._chosenTeam[i]._characterClass._className + " de niveau " + PlayerManager._instance._chosenTeam[i]._characterClass._classLevel);
                }
            }
            if (GUI.Button(_quitButton, "Quitter"))
            {
                quitGUI = true;
            }
        }
    }

}