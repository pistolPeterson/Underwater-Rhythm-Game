using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightGate : MonoBehaviour
{
    private LightState playerLs; 
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        playerLs = FindObjectOfType<LightState>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLs.playerLightState == LightStates.FirstLightState && !isOpen)
        {
            //move the gate up
          //  MoveGate(); 
          //  isOpen = true;
        }
    }

    public void MoveGate()
    {
        transform.DOMove(new Vector3(26, 50, 0), 4);
    }
}
