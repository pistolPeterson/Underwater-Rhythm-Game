using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MainMenuMusic : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    public EventReference startMusic;

    private void Start()
    {
        instance = RuntimeManager.CreateInstance(startMusic);
        instance.start();
      //  
    }

    public void OpenHarp()
    {
        instance.setParameterByName("Player Progression", 1f);
    }

    public void OpenClarinet()
    {
        instance.setParameterByName("Player Progression", 2.1f);
    }
}
