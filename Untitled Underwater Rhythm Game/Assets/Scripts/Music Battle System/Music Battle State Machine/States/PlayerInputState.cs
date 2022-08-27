using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputState : MBSMState
{
    public MBSMState endBattleState;
    public MBSMState sirenSingState;
    GameManager gameManager;
    public bool finishedInputState;
    [SerializeField] private GameObject sirenSingAnim;
    // Start is called before the first frame update
    void Start()
    {
        finishedInputState = false;
        gameManager = FindObjectOfType<GameManager>();
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
        sirenSingAnim.SetActive(false);

    }

    public override void Destruct()
    {
        
    }

    public override void UpdateState()
    {
        //after the verify result, either go to end battle or go to siren sing with next melody, both from a game manager
        if(finishedInputState)
        {
           

            //Go to gamemanager, check if current round is 2 
            if (gameManager.GetCurrentRound() == 5)
            {
                motor.ChangeState(endBattleState);
            }
            else
            {
                gameManager.NextRound();
                motor.ChangeState(sirenSingState);
            }

            //if 3, go to end battle

            //else increase current round, assign next melody and go to siren sing state 




        }
    }

    public void PlayerInputDone()
    {
        FindObjectOfType<ButtonInput>().AllowInput = false;
        finishedInputState = true;
    }
}
