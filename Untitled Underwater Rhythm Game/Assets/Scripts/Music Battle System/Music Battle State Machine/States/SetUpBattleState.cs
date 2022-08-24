using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpBattleState : MBSMState
{
    public MBSMState sirenSing; 
    public bool battleSetUp;
    private void Start()
    {
        battleSetUp = false;
    }
    public override void Construct()
    {
        //call transitionsirenbattle stuff 
        FindObjectOfType<TransitionSirenBattle>().SetUpBattle();
    }

    public override void Destruct()
    {
       battleSetUp = false;
    }

    public override void UpdateState()
    {
        if(battleSetUp)
        {
            //go to siren sing state 
            motor.ChangeState(sirenSing);
        }
      

    }

    public void BattleIsSetUp()
    {
        battleSetUp = true;
    }


}
