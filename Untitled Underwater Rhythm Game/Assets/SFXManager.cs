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
    private FMOD.Studio.EventInstance playStinger2Instance;
    public EventReference playStinger2SFX;

    private FMOD.Studio.EventInstance battleMusicInstance;
    public EventReference battleMusic;


    private FMOD.Studio.EventInstance sirenHissInstance;
    public EventReference sirenHissSfx;

    private FMOD.Studio.EventInstance sirenRageInstance;
    public EventReference sirenRageSfx;


    private FMOD.Studio.EventInstance sirenLaughInstance;
    public EventReference sirenLaughSFX;

    private float battleMusicProgression;
    private void Start()
    {
        waterAmbiInstance = RuntimeManager.CreateInstance(waterAmbienceSfx);
        ui1Instance = RuntimeManager.CreateInstance(ui1SFX);
        ui2Instance = RuntimeManager.CreateInstance(ui2SFX);
        battleMusicInstance = RuntimeManager.CreateInstance(battleMusic);
        playStingerInstance = RuntimeManager.CreateInstance(playStingerSFX);
        playStinger2Instance = RuntimeManager.CreateInstance(playStinger2SFX);
        sirenHissInstance = RuntimeManager.CreateInstance(sirenHissSfx);
        sirenRageInstance = RuntimeManager.CreateInstance(sirenRageSfx);
        sirenLaughInstance = RuntimeManager.CreateInstance(sirenLaughSFX);
        battleMusicProgression = 1.01f;
        waterAmbiInstance.start();
        DontDestroyOnLoad(this);
    }

    public void PlaySirenRage() { sirenRageInstance.start(); }
    public void PlaySirenHiss() { sirenHissInstance.start(); }
    public void PlaySirenLaugh() { sirenLaughInstance.start(); }
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
    public void PlayStinger2()
    {
        playStinger2Instance.start();
    }


    public void StartBattleMusic()
    {
        battleMusicInstance.start();
    }

    public void StopBattleMusic()
    {
        battleMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void IncreaseBattleMusic()
    {
        battleMusicProgression += 1.0f;
        if (battleMusicProgression > 3.5f)
        {
            battleMusicProgression = 3.01f;
            PlaySirenRage();
        }
        else 
            PlaySirenHiss();
            
        battleMusicInstance.setParameterByName("BattlePhase", battleMusicProgression);
    }

    public void DecreaseBattleMusic()
    {
        battleMusicProgression -= 1.0f;
        if (battleMusicProgression < 0.0f)
            battleMusicProgression = 1.01f;
        battleMusicInstance.setParameterByName("BattlePhase", battleMusicProgression);
        PlaySirenLaugh();

    }
}
