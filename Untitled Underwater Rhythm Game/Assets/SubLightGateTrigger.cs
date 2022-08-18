using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLightGateTrigger : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("triggered!");
            var playerLightState = collision.gameObject.GetComponent<LightState>();
            var isOpen = FindObjectOfType<LightGate>().isOpen;

            if (playerLightState.playerLightState == LightStates.FirstLightState && !isOpen)
            {
                FindObjectOfType<LightGate>().MoveGate();
            }
        }
    }
}
