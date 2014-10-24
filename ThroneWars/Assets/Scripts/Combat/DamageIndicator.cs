using UnityEngine;
using System.Collections;

public class DamageIndicator : MonoBehaviour {

    //public ;
    float time_;
    float time_to_fade = 1.5f;
    TextMesh textMesh;
    bool showDamage = false;
    Color textColor;
	// Use this for initialization
	void Start () {
        textMesh = GameObject.Find("DamageIndicator").GetComponent<TextMesh>();
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
    public void ShowDamage(int dmg)
    {
        time_ = Time.time;
        textColor.a = 1;
        textMesh.color = textColor;
        textMesh.text = dmg.ToString();
        showDamage = true;
    }
}
