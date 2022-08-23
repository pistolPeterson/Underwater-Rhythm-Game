using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenuPanel;
    private bool panelState = false;

    private void Start()
    {
          panelState = false;
          mainMenuPanel.SetActive(panelState);
    }


    public void TogglePanel()
    {
        panelState = !panelState;
        mainMenuPanel.SetActive(panelState);
    }


    public void GoToOverworld()
    {
        Debug.Log("Starting next game");
        FindObjectOfType<LevelLoader>().LoadNextLevel();     
    }
}
