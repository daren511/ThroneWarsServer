using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * ResourceManager
 * By Alexis Lalonde, 2014
 * A singleton that contains the colors and styles of the menus
 */
public class ResourceManager : MonoBehaviour
{
    //---------- VARIABLES ----------//
    // Color
    private Color _primaryColor = new Color(0.0f, 0.579f, 1.0f, 1.0f);
    private Color _secondaryColor = new Color(1.0f, 0.972f, 0.0f, 1.0f);
    // Background & Logo
    private Texture _background = Resources.Load("Menu/Background", typeof(Texture)) as Texture;
    private static Texture _logo = Resources.Load("Menu/Logo", typeof(Texture)) as Texture;
    private static Rect rectLogo = new Rect((Screen.width - _logo.width) / 2, 0, _logo.width, _logo.height);
    // Textures
    private Texture2D _healthTexture = Resources.Load("Menu/HEALTH", typeof(Texture2D)) as Texture2D;
    private Texture2D _magicTexture = Resources.Load("Menu/MANA", typeof(Texture2D)) as Texture2D;
    private Texture2D _atkTexture = Resources.Load("Menu/WATK", typeof(Texture2D)) as Texture2D;
    private Texture2D _defTexture = Resources.Load("Menu/WDEF", typeof(Texture2D)) as Texture2D;
    private Texture2D _matkTexture = Resources.Load("Menu/MATK", typeof(Texture2D)) as Texture2D;
    private Texture2D _mdefTexture = Resources.Load("Menu/MDEF", typeof(Texture2D)) as Texture2D;
    // Instance
    private static ResourceManager _instance = null;

    public static ResourceManager GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (ResourceManager)FindObjectOfType(typeof(ResourceManager));
                if (_instance == null)
                    _instance = (new GameObject("ResourceManager")).AddComponent<ResourceManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this;
    }

    public bool UpdateGUI(bool hasUpdatedGui)
    {
        if (!hasUpdatedGui)
        {
            ColoredGUISkin.Instance.UpdateGuiColors(_primaryColor, _secondaryColor);
            hasUpdatedGui = true;
        }
        GUI.skin = ColoredGUISkin.Skin;
        return hasUpdatedGui;
    }

    public List<Texture2D> GetResourcesIcons()
    {
        return new List<Texture2D> { _healthTexture, _magicTexture, _atkTexture, _defTexture, _matkTexture, _mdefTexture };
    }

    public void CreateBackground()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _background);   // Draw the background image
    }

    public void CreateLogo()
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.Box(rectLogo, _logo, GUIStyle.none);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}
