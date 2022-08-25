using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForBattleState : MBSMState
{
    public SetUpBattleState setUpBattle; 
    public bool goToBattle = false;
    [SerializeField] private GameObject battleBoard;
    [SerializeField] private GameObject successAnim;
    // Start is called before the first frame update
    void Start()
    {
        goToBattle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Construct()
    {
        goToBattle = false; 
        battleBoard.SetActive(false);
        successAnim.SetActive(false);
    }

    public override void Destruct()
    {
        goToBattle = false;
    }

    public override void UpdateState()
    {
          
        if (goToBattle)
        {

            //change to set up battle state 
            //go to battle back to false
            
            motor.ChangeState(setUpBattle); 
        }

    }

    public void GoToBattle() { goToBattle = true; }
}
