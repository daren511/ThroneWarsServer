using UnityEngine;
using System.Collections;

public class UserInterfaceGraphics : MonoBehaviour
{


    public Rect lifeBarRect;
    public Rect lifeBarLabelRect;
    public Rect lifeBarBackgroundRect;
    public Texture2D lifeBarBackground;
    public Texture2D lifeBar;




    //private float damage = 10;

    //private PlayerVitalData PVDScript;
    public GameObject PlayerData;


    private float LifeBarWidth = 300f;

    // Use this for initialization
    void Start()
    {
        instance = this;
        //PVDScript = PlayerData.GetComponent("PlayerVitalData") as PlayerVitalData;

    }
    // Update is called once per frame

    public static UserInterfaceGraphics instance;


    void OnGUI()
    {

        //instance.lifeBarRect.width = LifeBarWidth * (PVDScript.life / 200);
        instance.lifeBarRect.height = 20;

        instance.lifeBarBackgroundRect.width = LifeBarWidth;
        instance.lifeBarBackgroundRect.height = 20;

        GUI.DrawTexture(lifeBarRect, lifeBar);
        GUI.DrawTexture(lifeBarBackgroundRect, lifeBarBackground);

        GUI.Label(lifeBarLabelRect, "LIFE");



    }

}