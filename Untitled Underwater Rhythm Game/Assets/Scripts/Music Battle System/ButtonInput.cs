using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FMODUnity;


[System.Serializable]
public class NoteEvent : UnityEvent<NoteLength, NoteInputType>
{

}
public class ButtonInput : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance1;
    public EventReference noteSFX1;

    private FMOD.Studio.EventInstance instance2;
    public EventReference noteSFX2;
    private FMOD.Studio.EventInstance instance3;
    public EventReference noteSFX3;
    private FMOD.Studio.EventInstance instance4;
    public EventReference noteSFX4;

   

  

    public KeyCode keyCode1;
    public NoteInputType noteType;
    public static NoteEvent noteEvent; 

    private float time;
    private bool isPressing;
    private float lastTimePressed;

    public bool AllowInput { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        instance1 = RuntimeManager.CreateInstance(noteSFX1);
        instance2 = RuntimeManager.CreateInstance(noteSFX2);
        instance3 = RuntimeManager.CreateInstance(noteSFX3);
        instance4 = RuntimeManager.CreateInstance(noteSFX4);

        time = 0; 
        lastTimePressed = 0;
        isPressing = false;
    }
    //TODO: A lot of duplicated code, might have to refactor later 
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!AllowInput)
        {
            Debug.Log("Not allowing input");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q) )
        {
            StartPressing();
            PlayNote(NoteInputType.Q);
        }


        if (Input.GetKeyUp(KeyCode.Q))
        {
            StopPressing(NoteInputType.Q);
            StopNote(NoteInputType.Q);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartPressing();
            PlayNote(NoteInputType.W);
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            StopPressing(NoteInputType.W);
            StopNote(NoteInputType.W);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartPressing();
            PlayNote(NoteInputType.E);
        }


        if (Input.GetKeyUp(KeyCode.E))
        {
            StopPressing(NoteInputType.E);
            StopNote(NoteInputType.E);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartPressing();
            PlayNote(NoteInputType.R);
        }


        if (Input.GetKeyUp(KeyCode.R))
        {
            StopPressing(NoteInputType.R);
            StopNote(NoteInputType.R);
        }
    }
    void StartPressing()
    {
        time = 0;
        isPressing = true;
        //start playing note audio event 
        instance1.start();
        
    }

    void StopPressing(NoteInputType type)
    {
        if (!isPressing) return;

        isPressing = false; 
        lastTimePressed = time;
        if (lastTimePressed >= 0.4f)
            noteEvent?.Invoke(NoteLength.LONG, type);
        else
            noteEvent?.Invoke(NoteLength.SHORT, type);

        //stop playing note audio event
        instance1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void PlayNote(NoteInputType type)
    {
        switch (type)
        {
            case NoteInputType.Q:
                instance1.start(); 
                break;
            case NoteInputType.W:
                instance2.start();
                break;
            case NoteInputType.E:
                instance3.start();
                break;
            case NoteInputType.R:
                instance4.start();
                break;
        }
    }

    private void StopNote(NoteInputType type)
    {
        switch (type)
        {
            case NoteInputType.Q:
                instance1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case NoteInputType.W:
                instance2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case NoteInputType.E:
                instance3.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case NoteInputType.R:
                instance4.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
        }
    }


}

public enum NoteLength
{
    NONE, 
    LONG, 
    SHORT,
}

public enum NoteInputType
{
    NONE,
    Q,
    W,
    E,
    R
}