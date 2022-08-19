using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransitionSirenBattle : MonoBehaviour
{
    private bool battleStarted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !battleStarted)
        {
            battleStarted = true;

            Debug.Log("Time to start a siren battle");
            //add delay between steps?

            MusicTrigger();
            //move siren to correct position
            MoveSiren();
            //freeze player and move player to correct position
            MovePlayer();
            //zoom camera to correct position 
            ZoomCam();
            //unlock Music battle UI 

            //delay would be nice here 
            //unlock music battle state machine 
            //Fmod stuff?
        }
    }

    void MoveSiren()
    {
        Vector3 newPosition = new Vector3(100 ,0, 0);
        transform.DOMove(newPosition, 4);
    }

    void MovePlayer()
    {
        PlayerMovement playerM = FindObjectOfType<PlayerMovement>();
        playerM.FreezePlayer();

        Vector3 newPosition = new Vector3(50, 0, 0);
        playerM.transform.DOMove(newPosition, 4);

    }


    void ZoomCam()
    {
        FindObjectOfType<CameraFollow>().FollowObjectOneTime(new Vector3(80, 0, -125));
    }

    void MusicTrigger()
    {
        var music = FindObjectOfType<MainMenuMusic>();
        if (music != null)
            music.MusicTransition();
    }
}

