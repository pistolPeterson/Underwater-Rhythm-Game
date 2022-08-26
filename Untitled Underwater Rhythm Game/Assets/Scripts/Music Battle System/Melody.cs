using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Melody : MonoBehaviour
{
    public List<NoteObject> lvl1Melody;
    public List<NoteObject> lvl1Rd2Melody;

    public List<NoteObject> currentMelody;

    public List<MelodyBaseSO> melodies;

    private FMOD.Studio.EventInstance instance1;
    public EventReference noteSFX1;

    private FMOD.Studio.EventInstance instance2;
    public EventReference noteSFX2;
    private FMOD.Studio.EventInstance instance3;
    public EventReference noteSFX3;
    private FMOD.Studio.EventInstance instance4;
    public EventReference noteSFX4;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentMelody = lvl1Melody;
        gameManager = FindObjectOfType<GameManager>();  
        instance1 = RuntimeManager.CreateInstance(noteSFX1);
        instance2 = RuntimeManager.CreateInstance(noteSFX2);
        instance3 = RuntimeManager.CreateInstance(noteSFX3);
        instance4 = RuntimeManager.CreateInstance(noteSFX4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SirenSingMelody()
    {
        //Go to gamemanager, check round to play correct melody 
        // StartCoroutine(sing(lvl1Melody));
        int rand = Random.Range(0, melodies.Count);
        Debug.Log("singing " + rand);
        currentMelody = melodies[rand].melody;
        StartCoroutine(sing(melodies[rand].melody)); //method to choose a random one from here 
        /* switch(gameManager.GetCurrentRound())
         {
             case 0:
                 //StartCoroutine(sing(lvl1Melody));
                 break;
             case 1:
                 currentMelody = lvl1Rd2Melody;
                 StartCoroutine(sing(lvl1Rd2Melody));
                 break; 
                 default:

                 break;

         }*/

    }

    private IEnumerator sing(List<NoteObject> melody)
    {
        
        foreach (NoteObject note in melody)
        {
            yield return new WaitForSeconds(0.84f);
            //switch case based on note type 
            PlayNote(note.GetNoteInputType());
            //play specific animation based on note input 
        }
        yield return new WaitForSeconds(0.5f);
        //tell siren sing state we are done 
        FindObjectOfType<SirenSingState>().SirenDoneSinging();
        FindObjectOfType<SirenMoveNoteAnim>().HideSirenMarker();
    }

    public void PlayNote(NoteInputType type)
    {
        var sirenAnim = FindObjectOfType<SirenMoveNoteAnim>();

        switch(type)
        {
            case NoteInputType.W:
                sirenAnim.SirenSingWAnim();
                instance1.start();
                break;
            case NoteInputType.Q:
                sirenAnim.SirenSingQAnim();
                instance2.start();
                break;
            case NoteInputType.E:
                sirenAnim.SirenSingEAnim();
                instance3.start();
                break;
            case NoteInputType.R:
                sirenAnim.SirenSingRAnim();
                instance4.start();
                break;
        }
    }
}
