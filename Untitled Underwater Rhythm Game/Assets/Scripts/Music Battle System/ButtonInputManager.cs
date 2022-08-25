using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputManager : MonoBehaviour
{
    [SerializeField] private int melodySize = 4;
    private List<NoteObject> noteObjects = new List<NoteObject>();


    private void Start()
    {
        if(ButtonInput.noteEvent == null)
            ButtonInput.noteEvent = new NoteEvent();

        ButtonInput.noteEvent.AddListener(Convert);
    }


    void Convert(NoteLength noteLength, NoteInputType inputType)
    {
        noteObjects.Add(new NoteObject(noteLength, inputType));
        if (noteObjects.Count >= melodySize)
        {
            //send to another method that checks if its correct and also reset the list 
            ShowMelodyValues();
        }

    }

    void ShowMelodyValues()
    {
        foreach ( NoteObject x in noteObjects)
        {
            Debug.Log(x.GetNoteInputType() + " " + x.GetNoteLength());
        }

        VerifyInputNotes(noteObjects, FindObjectOfType<Melody>().lvl1Melody);

        noteObjects = new List<NoteObject>();
    }

    public void VerifyInputNotes(List<NoteObject> userNotes, List<NoteObject> melody)
    {
        if (IsSameMelody(userNotes, melody))
        {
            Debug.Log("you played it correctly!");
            //play good feedback 
        }
        else
        {
            Debug.Log("rip you played it incorrrectly");
            //play bad feedback 

        }

        //Go to gamemanager, use a lil wait time, figure out if you gotta do a new melody or go to end battle 
        StartCoroutine(GoToEndBattle());

    }
    private IEnumerator GoToEndBattle()
    {
        yield return new WaitForSeconds(1);
        
        FindObjectOfType<PlayerInputState>().PlayerInputDone();
    }

    private bool IsSameMelody(List<NoteObject> userNotes, List<NoteObject> melody)
    {
        for(int i =0; i < melody.Count; i++)
        {
            if(userNotes[i].GetNoteInputType() != melody[i].GetNoteInputType())
            {
                Debug.Log("not same input type");
                return false;
            }
                

            if(userNotes[i].GetNoteLength() != melody[i].GetNoteLength())
            {
                Debug.Log("not same length");
                return false;
            }
        }

        return true; 
    }
}
