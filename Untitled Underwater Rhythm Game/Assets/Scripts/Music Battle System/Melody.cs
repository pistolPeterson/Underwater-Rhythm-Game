using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melody : MonoBehaviour
{
    public List<NoteObject> lvl1Melody;
    // Start is called before the first frame update
    void Start()
    {
        
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
                break;
            case NoteInputType.Q:
                Debug.Log("Playing Q");
                break;
            case NoteInputType.E:
                Debug.Log("Playing E");
                break;
            case NoteInputType.R:
                Debug.Log("Playing R");
                break;
        }
    }
}
