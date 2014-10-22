using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo state;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        state = anim.GetCurrentAnimatorStateInfo(0);
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

        PlayAnimations(oppositeCamera);

    }
    public void AttackAnimation()
    {
        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        string clip = "";
        if (oppositeCamera.x > 0 && oppositeCamera.z > 0)
        {
            clip = "MeleeAttackBack";
        }
        else if (oppositeCamera.x < 0 && oppositeCamera.z < 0)
        {
            clip = "MeleeAttackFront";
        }
        else if (oppositeCamera.x > -1 && oppositeCamera.z < 0.1f)
        {
            clip = "MeleeAttackRight";
        }
        else if (oppositeCamera.x < 1 && oppositeCamera.z < 0.1f)
        {
            clip = "MeleeAttackLeft";
        }
        anim.CrossFade(clip, 1f);
    }
    private void PlayAnimations(Vector3 camera)
    {
        if (camera.x > 0 && camera.z > 0)
        {
            anim.CrossFade("IdleBack", 0f);
        }
        else if (camera.x < 0 && camera.z < 0)
        {
            anim.CrossFade("IdleFront", 0f);
        }
        else if (camera.x > -1 && camera.z < 0.1f)
        {
            anim.CrossFade("IdleRight", 0f);
        }
        else if (camera.x < 1 && camera.z < 0.1f)
        {
            anim.CrossFade("IdleLeft", 0f);
        }
    }
}
