using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EndBattleState : MBSMState
{
    public MBSMState waitingForBattle;
    public bool battleEnded;
    [SerializeField] private GameObject battleBoard;
    [SerializeField] private GameObject sucessAnim;
    [SerializeField] private GameObject sirenSingAnim;

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
        sirenSingAnim.SetActive(false);
        FindObjectOfType<PlayerMovement>().UnFreezePlayer();
        FindObjectOfType<PlayerMovement>().gameObject.GetComponent<RotateToTarget>().useRotation = true;
        FindObjectOfType<CameraFollow>().FollowPlayer();
        FindObjectOfType<TransitionSirenBattle>().MoveSirenExitBattle();
        
        FindObjectOfType<TransitionSirenBattle>().ResetBattle();
        FindObjectOfType<SFXManager>().StopBattleMusic();
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
            Debug.Log("you commented out the end battle state btw");
           // motor.ChangeState(waitingForBattle);
        }
    }

    public void BattleEnded() { battleEnded = true; }
}
