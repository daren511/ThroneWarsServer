using UnityEngine;
using ControleBD;

public class ComboBox
{
    private static bool forceToUnShow = false;
    private static int useControlID = -1;
    private bool isClickedComboButton = false;
    private int selectedItemIndex = 0;

    private Rect rect;
    private GUIContent buttonContent;
    private GUIContent[] listContent;
    private string buttonStyle;
    private string boxStyle;
    public GUIStyle listStyle;
    private Personnages perso;

    public ComboBox(Rect rect, GUIContent buttonContent, GUIContent[] listContent, GUIStyle listStyle)
    {
        this.rect = rect;
        this.buttonContent = buttonContent;
        this.listContent = listContent;
        this.buttonStyle = "button";
        this.boxStyle = "box";
        this.listStyle = listStyle;
    }

    public ComboBox(Rect rect, GUIContent buttonContent, GUIContent[] listContent, string buttonStyle, string boxStyle, GUIStyle listStyle)
    {
        this.rect = rect;
        this.buttonContent = buttonContent;
        this.listContent = listContent;
        this.buttonStyle = boxStyle;
        this.boxStyle = boxStyle;
        this.listStyle = listStyle;
    }

    public int Show()
    {
        if (forceToUnShow)
        {
            forceToUnShow = false;
            isClickedComboButton = false;
        }

        bool done = false;
        int controlID = GUIUtility.GetControlID(FocusType.Passive);

        switch (Event.current.GetTypeForControl(controlID))
        {
            case EventType.mouseUp:
                {
                    if (isClickedComboButton)
                    {
                        done = true;
                    }
                }
                break;
        }

        if (GUI.Button(rect, buttonContent, buttonStyle))
        {
            if (useControlID == -1)
            {
                useControlID = controlID;
                isClickedComboButton = false;
            }

            if (useControlID != controlID)
            {
                forceToUnShow = true;
                useControlID = controlID;
            }
            isClickedComboButton = true;
        }

        if (isClickedComboButton)
        {
            Rect listRect = new Rect(rect.x, rect.y + listStyle.CalcHeight(listContent[0], 1.0f) + 3,
                      rect.width, listStyle.CalcHeight(listContent[0], 1.0f) * listContent.Length + 20);

            GUI.Box(listRect, "", boxStyle);
            int newSelectedItemIndex = GUI.SelectionGrid(listRect, selectedItemIndex, listContent, 1, listStyle);
            if (newSelectedItemIndex != selectedItemIndex)
            {
                selectedItemIndex = newSelectedItemIndex;
                buttonContent = listContent[selectedItemIndex];

                perso = PlayerManager._instance.GetDefaultStats(buttonContent.text.ToString());
                useControlID = -1;
            }
        }
        if (done)
        {
            isClickedComboButton = false;
            useControlID = -1;
        }

        return selectedItemIndex;
    }

    public int SelectedItemIndex
    {
        get
        {
            return selectedItemIndex;
        }
        set
        {
            selectedItemIndex = value;
        }
    }

    public Personnages GetStats()
    {
        if (perso == null)
            perso = PlayerManager._instance.GetDefaultStats(listContent[0].text.ToString());
        return perso;
    }

    public void ResetContent()
    {
        buttonContent = listContent[0];
        perso = PlayerManager._instance.GetDefaultStats(buttonContent.text.ToString());
    }
}