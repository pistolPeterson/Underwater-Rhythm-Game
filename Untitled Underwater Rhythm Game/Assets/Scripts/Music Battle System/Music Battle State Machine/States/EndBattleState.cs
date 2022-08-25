using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattleState : MBSMState
{
    public MBSMState waitingForBattle;
    public bool battleEnded;
    [SerializeField] private GameObject battleBoard;
    [SerializeField] private GameObject sucessAnim; 
    // Start is called before the first frame update
    void Start()
    {
        battleEnded = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Construct()
    {

        battleEnded = false;
        //turn off UI, save any game data somewhere 
        battleBoard.SetActive(false);
        sucessAnim.SetActive(false);
        FindObjectOfType<PlayerMovement>().UnFreezePlayer();
        FindObjectOfType<CameraFollow>().FollowPlayer();
    }

    public override void Destruct()
    {
        battleEnded = false;
    }

    public override void UpdateState()
    {
        //go to waiting for battle state 
        if (battleEnded)
        {
            motor.ChangeState(waitingForBattle);
        }
    }

    public void BattleEnded() { battleEnded = true; }
}
