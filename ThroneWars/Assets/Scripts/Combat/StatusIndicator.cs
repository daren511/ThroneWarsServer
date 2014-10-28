using UnityEngine;
using System.Collections;

public class StatusIndicator : MonoBehaviour {

    //public ;
    float time_;
    float time_to_fade = 1.5f;
    TextMesh textMesh;
    bool showDamage = false;
    Color textColor;
	// Use this for initialization
	void Start () {
        textMesh = GameObject.Find("StatusIndicator").GetComponent<TextMesh>();
        textColor = textMesh.color;
        textColor.a = 0;
        textMesh.color = textColor;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        Vector3 euler = faceCamera.eulerAngles;

        euler.z = 0f;
        faceCamera.eulerAngles = euler;
        transform.rotation = faceCamera;

        if(showDamage)
        {
            transform.Translate(new Vector3(0, 0.051f, 0));

            textColor.a =  Mathf.Cos((Time.time - time_) * ((Mathf.PI / 2) / time_to_fade));
            textMesh.color = textColor;

            if(textColor.a <= 0)
            {
                showDamage = false;
            }
        }
	}
    public void Show(int dmg, string type)
    {
        string text = InfosToShow(dmg, type);

        time_ = Time.time;
        textColor.a = 1;
        textMesh.color = textColor;
        textMesh.text = text;
        showDamage = true;
    }
    private string InfosToShow(int amt, string type)
    {
        string indic = "";

        switch(type)
        {
                
            case "Damage":
                textColor = Color.red;
                indic = "-" + amt + " PV";
                break;
            case "Health":
                textColor = new Color(0.5f, 1, 0.5f);
                indic = "+" + amt + " PV";
                break;
            case "PhysGain":
                textColor = new Color(0.8f, 0.9f, 0.3f);
                indic = "+" + amt + "";
                break;
            case "PhysLost":
                textColor = new Color(0.8f, 0.9f, 0.3f);
                indic = "-" + amt + "";
                break;
            case "MagicGain":
                textColor = new Color(0.54f, 0.124f, 0.9f);
                indic = "+" + amt + "";
                break;
            case "MagicLost":
                textColor = new Color(0.54f, 0.124f, 0.9f);
                indic = "-" + amt + "";
                break;
            case "Exp":
                break;
            case "Gold":
                break;
        }

        return indic;
    }
}
