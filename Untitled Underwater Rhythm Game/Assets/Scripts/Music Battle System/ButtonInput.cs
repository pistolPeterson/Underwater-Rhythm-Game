using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


[System.Serializable]
public class NoteEvent : UnityEvent<NoteLength, NoteInputType>
{

}
public class ButtonInput : MonoBehaviour
{

    public Button button;
   

    public Sprite pressedImg;
    public Sprite normalImg;

    public KeyCode keyCode1;
    public NoteInputType noteType;
    public static NoteEvent noteEvent; 

    private float time;
    private bool isPressing;
    private float lastTimePressed;

    // Start is called before the first frame update
    void Start()
    {
        time = 0; 
        lastTimePressed = 0;
        isPressing = false;
    }
    //TODO: A lot of duplicated code, might have to refactor later 
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(keyCode1) )
        {
            StartPressing();
        }


        if (Input.GetKeyUp(keyCode1))
        {
            StopPressing();
        }
    }
    void StartPressing()
    {
        time = 0;
        isPressing = true;
        button.image.sprite = pressedImg;
        //start playing note audio event 
    }

    void StopPressing()
    {
        if (!isPressing) return;

        isPressing = false; 
        button.image.sprite = normalImg;
        lastTimePressed = time;
        if (lastTimePressed >= 0.4f)
            noteEvent?.Invoke(NoteLength.LONG, noteType);
        else
            noteEvent?.Invoke(NoteLength.SHORT, noteType);

        //stop playing note audio event
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
    A,
    B,
    C,
    D
}