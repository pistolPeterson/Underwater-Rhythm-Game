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
            PlayBlueSuccess();
        if (Input.GetKeyDown(KeyCode.W))
            PlayRedSuccess();
        if (Input.GetKeyDown(KeyCode.E))
            PlayPinkSuccess();
        if (Input.GetKeyDown(KeyCode.R))
            PlayYellowSuccess();
    }

    public void PlayBlueSuccess()
    {
        if (anim == null) return; 

        anim.Play("blue good");
    }
    public void PlayRedSuccess()
    {
        if (anim == null) return;

        anim.Play("red good");
    }
    public void PlayPinkSuccess()
    {
        if (anim == null) return;

        anim.Play("pink good");
    }
    public void PlayYellowSuccess()
    {
        if (anim == null) return;

        anim.Play("yellow good");
    }
}
