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
            var state = FindObjectOfType<WaitForBattleState>();
            state.GoToBattle();

            
        }
    }

    public void SetUpBattle()
    {
        Debug.Log("Time to start a siren battle");
        //add delay between steps?

        MusicTrigger();
        //move siren to correct position
        MoveSirenIntoBattle();
        //freeze player and move player to correct position
        MovePlayer();
        //zoom camera to correct position 
        ZoomCam();
        //unlock Music battle UI 

        //delay would be nice here 
        //unlock music battle state machine 
        //Fmod stuff?

        //probably put this in a ienum to make it wait a bit 
        StartCoroutine(waitThenSetUpBattle());
    }


    private IEnumerator waitThenSetUpBattle()
    {
        yield return new WaitForSeconds(7.0f);
        FindObjectOfType<SetUpBattleState>().BattleIsSetUp();
    }
    void MoveSirenIntoBattle()
    {
        Vector3 newPosition = new Vector3(130 ,0, 0);
        transform.DOMove(newPosition, 4);
       
    }

    public void MoveSirenExitBattle()
    {
        Vector3 newPosition = new Vector3(200, 5, 0);
        transform.DOMove(newPosition, 3.5f);
        StartCoroutine(waitThenEndBattle());
    }
    private IEnumerator waitThenEndBattle()
    {
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<EndBattleState>().BattleEnded();
    }

    void MovePlayer()
    {
        PlayerMovement playerM = FindObjectOfType<PlayerMovement>();
        playerM.FreezePlayer();
        playerM.gameObject.GetComponent<RotateToTarget>().useRotation = false;
        Vector3 newPosition = new Vector3(30, 0, 0); //another array of positions? 
        playerM.transform.DOMove(newPosition, 4);
        playerM.transform.DORotate(new Vector3(0, 0, 0), 3.5f);
    

    }


    void ZoomCam()
    {


        FindObjectOfType<CameraFollow>().FollowObjectOneTime(new Vector3(80, 15, -125));
    }

    void MusicTrigger()
    {
        var music = FindObjectOfType<MainMenuMusic>();
        if (music != null)
            music.MusicTransition();
    }

    public void ResetBattle() { battleStarted = false; }
}

