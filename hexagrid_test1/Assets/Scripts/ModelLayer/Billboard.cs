using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        Vector3 euler = faceCamera.eulerAngles;
        euler.z = 0f;
        faceCamera.eulerAngles = euler;
        transform.rotation = faceCamera;

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        float time = state.normalizedTime;

        if (oppositeCamera.x > 0 && oppositeCamera.z > 0)
        {
            anim.CrossFade("Walk Back", 0f);
        }
        else if (oppositeCamera.x < 0 && oppositeCamera.z < 0)
        {
            anim.CrossFade("Walk Front", 0f);
        }
        else if (oppositeCamera.x > -1 && oppositeCamera.z < 0.1f)
        {
            anim.CrossFade("Walk Right", 0f);
        }
        else if (oppositeCamera.x < 1 && oppositeCamera.z < 0.1f)
        {
            anim.CrossFade("Walk Left", 0f);
        }
    }
}
