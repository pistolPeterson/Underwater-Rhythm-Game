using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{

    public LightStates playerLightState = LightStates.None; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstLightState()
    {
        playerLightState = LightStates.FirstLightState;
    }
}
public enum LightStates
{
    None,
    FirstLightState, 
}