using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo state;
    Character character;
    // Use this for initialization
    void Start()
    {
        character = GetComponentInParent<Character>();
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
        string clip = "";
        float angle = Camera.main.transform.eulerAngles.y;

        if (angle <= 135 && angle > 45)
        {
            clip = "MeleeAttackBack";
        }
        if (angle <= 225 && angle > 135)
        {
            clip = "MeleeAttackLeft";
        }
        if (angle <= 315 && angle > 225)
        {
            clip = "MeleeAttackFront";
        }
        if ((angle <= 360 && angle > 315)
         || (angle <= 45 && angle > 0))
        {
            clip = "MeleeAttackRight";
        }        
        anim.CrossFade(clip, 1f);
    }
    private void PlayAnimations(Vector3 camera)
    {
        float angle = Camera.main.transform.eulerAngles.y;

        if (angle <= 135 && angle > 45)
        {
            anim.CrossFade("IdleBack", 0f);
        }
        if (angle <= 225 && angle > 135)
        {
            anim.CrossFade("IdleLeft", 0f);
        }
        if (angle <= 315 && angle > 225)
        {
            anim.CrossFade("IdleFront", 0f);
        }
        if ((angle <= 360 && angle > 315)
         || (angle <= 45 && angle > 0))
        {
            anim.CrossFade("IdleRight", 0f);
        }
    }
}
