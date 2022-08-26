using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!FMODUnity.RuntimeManager.HasBankLoaded("Master Bayynk"))
        {
            Debug.Log("Master Bank Loaded");
            SceneManager.LoadScene(1);
        }
        Debug.Log("working?");
    }
}
