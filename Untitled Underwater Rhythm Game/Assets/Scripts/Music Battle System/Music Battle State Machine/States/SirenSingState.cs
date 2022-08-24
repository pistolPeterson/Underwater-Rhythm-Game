using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenSingState : MBSMState
{
    public MBSMState playerInputState;
    public bool doneSinging = false; 
    // Start is called before the first frame update
    void Start()
    {
        doneSinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Construct()
    {
        //make siren "sing" melody 
        //find melody object and play on fmod 
        FindObjectOfType<Melody>().SirenSingMelody();
        //play the correct positioning based on the notes on the board
        //start timer system? set to 0 ?

    }

    public override void Destruct()
    {
        doneSinging = false; 
    }

    public override void UpdateState()
    {
       //after a certain time, switch to player input state, use a simple timer system 
       if(doneSinging)
        {
            //go to player input state
            motor.ChangeState(playerInputState);
        }

    }

    public void SirenDoneSinging()
    {
        doneSinging = true; 
    }
}
