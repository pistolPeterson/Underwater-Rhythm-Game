using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFXManager : MonoBehaviour
{
    private FMOD.Studio.EventInstance waterAmbiInstance;
    public EventReference waterAmbienceSfx;


    private FMOD.Studio.EventInstance ui1Instance;
    public EventReference ui1SFX;

    private FMOD.Studio.EventInstance ui2Instance;
    public EventReference ui2SFX;

    private FMOD.Studio.EventInstance playStingerInstance;
    public EventReference playStingerSFX;

    private FMOD.Studio.EventInstance battleMusicInstance;
    public EventReference battleMusic;

    private void Start()
    {
        waterAmbiInstance = RuntimeManager.CreateInstance(waterAmbienceSfx);
        ui1Instance = RuntimeManager.CreateInstance(ui1SFX);
        ui2Instance = RuntimeManager.CreateInstance(ui2SFX);
        battleMusicInstance = RuntimeManager.CreateInstance(battleMusic);
        playStingerInstance = RuntimeManager.CreateInstance(playStingerSFX);
        waterAmbiInstance.start();
        DontDestroyOnLoad(this);
    }


    public void PlayUI1()
    {
        ui1Instance.start();
    }

    public void PlayUI2()
    {
        ui2Instance.start();
    }

    public void PlayStinger()
    {
        playStingerInstance.start();
    }

    public void StartBattleMusic()
    {
        battleMusicInstance.start();
    }

    public void StopBattleMusic()
    {
        battleMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}