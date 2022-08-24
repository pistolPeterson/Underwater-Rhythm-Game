using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputState : MBSMState
{
    public MBSMState endBattleState;
    public bool finishedInputState; 
    // Start is called before the first frame update
    void Start()
    {
        finishedInputState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Construct()
    {
        //allow input from user in ButtonInput 
        FindObjectOfType<ButtonInput>().AllowInput = true;
        finishedInputState = false;

    }

    public override void Destruct()
    {
        
    }

    public override void UpdateState()
    {
        //after the verify result, either go to end battle or go to siren sing with next melody, both from a game manager
        if(finishedInputState)
        {
            motor.ChangeState(endBattleState);
        }
    }

    public void PlayerInputDone()
    {
        FindObjectOfType<ButtonInput>().AllowInput = false;
        finishedInputState = true;
    }
}
