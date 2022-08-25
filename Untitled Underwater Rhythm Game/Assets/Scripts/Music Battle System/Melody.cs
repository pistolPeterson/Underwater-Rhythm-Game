using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Melody : MonoBehaviour
{
    public List<NoteObject> lvl1Melody;

    private FMOD.Studio.EventInstance instance1;
    public EventReference noteSFX1;

    private FMOD.Studio.EventInstance instance2;
    public EventReference noteSFX2;
    private FMOD.Studio.EventInstance instance3;
    public EventReference noteSFX3;
    private FMOD.Studio.EventInstance instance4;
    public EventReference noteSFX4;

    // Start is called before the first frame update
    void Start()
    {
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
        //iterate through melody (ienum)
        //foreach note type 
        //play the corresponding note 
        //play corresponding animation 
        StartCoroutine(sing(lvl1Melody));


    }

    private IEnumerator sing(List<NoteObject> melody)
    {
        foreach (NoteObject note in melody)
        {
            yield return new WaitForSeconds(1);
            //switch case based on note type 
            PlayNote(note.GetNoteInputType());
            //play specific animation based on note input 
        }
        yield return new WaitForSeconds(0.5f);
        //tell siren sing state we are done 
        Debug.Log("tell siren sing state we are done singing");
        FindObjectOfType<SirenSingState>().SirenDoneSinging();
    }

    public void PlayNote(NoteInputType type)
    {
        switch(type)
        {
            case NoteInputType.W:
                Debug.Log("Playing W");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Flute melody/fluteW", transform.position);
                instance1.start();
                break;
            case NoteInputType.Q:
                Debug.Log("Playing Q");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Flute melody/fluteQ", transform.position);
                instance2.start();
                break;
            case NoteInputType.E:
                Debug.Log("Playing E");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Flute melody/fluteE", transform.position);
                instance3.start();
                break;
            case NoteInputType.R:
                Debug.Log("Playing R");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Flute melody/fluteR", transform.position);
                instance4.start();
                break;
        }
    }
}
