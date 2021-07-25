using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerMovement.Instance.getMovement().x < 0) transform.localScale = Vector3.one;
        else if (PlayerMovement.Instance.getMovement().x > 0) transform.localScale = new Vector3(-1, 1, 1);

        if (PlayerMovement.Instance.getRigidBody().velocity.magnitude > 0.01f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walking", false);
        }

        anim.SetBool("Pushing", PlayerMovement.Instance.isPushing);
    }
}
