using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FMODUnity;

public class LightGate : MonoBehaviour
{
    private LightState playerLs; 
    public bool isOpen = false;
    // Start is called before the first frame update

    private FMOD.Studio.EventInstance gateMoveInstance;
    public EventReference gateMoveSFX;
    void Start()
    {
        playerLs = FindObjectOfType<LightState>();
        isOpen = false;
        gateMoveInstance = RuntimeManager.CreateInstance(gateMoveSFX);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLs.playerLightState == LightStates.FirstLightState && !isOpen)
        {
            //move the gate up
            //MoveGate(); 
            //isOpen = true;
        }
    }

    public void MoveGate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 25, transform.position.z);
        transform.DOMove(newPosition, 4);
        gateMoveInstance.start();
    }
}
