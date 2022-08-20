using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]public class NoteObject 
{
    [SerializeField] private NoteLength noteLength;
    [SerializeField] private NoteInputType noteInputType;   

    public NoteObject(NoteLength len, NoteInputType type)
    {
        noteLength = len;
        noteInputType = type;
    }

    public NoteLength GetNoteLength() { return noteLength; }
    public NoteInputType GetNoteInputType() { return noteInputType; }
}
