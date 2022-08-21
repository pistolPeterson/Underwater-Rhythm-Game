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

        noteObjects = new List<NoteObject>();
    }
}
