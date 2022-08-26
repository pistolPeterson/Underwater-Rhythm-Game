using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAnimationSystem : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            PlayRedSuccess();
        if (Input.GetKeyDown(KeyCode.W))
            PlayBlueSuccess();
        if (Input.GetKeyDown(KeyCode.E))
            PlayYellowSuccess();
        if (Input.GetKeyDown(KeyCode.R))
            PlayPinkSuccess();
    }

    public void PlayBlueSuccess()
    {
        if (anim == null) return;
        anim.SetTrigger("Blue");
        anim.Play("blue good");
    }
    public void PlayRedSuccess()
    {
        if (anim == null) return;

        anim.Play("red good");
        anim.SetTrigger("Red");
    }
    public void PlayPinkSuccess()
    {
        if (anim == null) return;
        anim.SetTrigger("Pink");
        anim.Play("pink good");
    }
    public void PlayYellowSuccess()
    {
        if (anim == null) return;
        anim.SetTrigger("Yellow");
        anim.Play("yellow good");
    }
}
