using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBSMMotor : MonoBehaviour
{
    public MBSMState activeState;
    public MBSMState initialState; 

    // Start is called before the first frame update
    void Start()
    {
        activeState = initialState;
        activeState.Construct();
    }

    // Update is called once per frame
    void Update()
    {
        activeState.UpdateState();
    }



    public void ChangeState(MBSMState state)
    {
        activeState.Destruct();
        activeState = state;
        activeState.Construct(); 
    }
}
