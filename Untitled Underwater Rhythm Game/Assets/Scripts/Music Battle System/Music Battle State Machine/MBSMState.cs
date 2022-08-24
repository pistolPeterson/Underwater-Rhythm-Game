using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MBSMState : MonoBehaviour
{
    public MBSMMotor motor;
    private void Start()
    {
        motor = FindObjectOfType<MBSMMotor>();
    }
    public virtual void Construct()
    {

    }

    public virtual void Destruct()
    {

    }

    public virtual void UpdateState()
    {

    }
}
