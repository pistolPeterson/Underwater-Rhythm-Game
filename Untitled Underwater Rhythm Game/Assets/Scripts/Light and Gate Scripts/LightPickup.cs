using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickup :MonoBehaviour, ICollectible
{
    public GameObject lightObj;

    private void Start()
    {
        //lightObj.SetActive(false);
    }
    public void Collect()
    {
        //get the players light object and change its brightness real quick
        Debug.Log("Picked up a light collect, chagning brightness ");
        FindObjectOfType<LightState>().playerLightState = LightStates.FirstLightState;
       // lightObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
