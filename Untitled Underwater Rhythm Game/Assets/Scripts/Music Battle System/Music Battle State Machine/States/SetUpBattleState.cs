using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpBattleState : MBSMState
{
    public MBSMState sirenSing; 
    public bool battleSetUp;
    [SerializeField] private GameObject battleBoard;
    [SerializeField] private GameObject successAnim;
    [SerializeField] private GameObject sirenSingAnim;
    private void Start()
    {
        battleSetUp = false;
    }
    public override void Construct()
    {
        //call transitionsirenbattle stuff 
        FindObjectOfType<TransitionSirenBattle>().SetUpBattle();
        
        battleBoard.SetActive(true);
        successAnim.SetActive(true);
        sirenSingAnim.SetActive(true);
        FindObjectOfType<SirenMoveNoteAnim>().ShowSirenMarkerEmpty();
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
