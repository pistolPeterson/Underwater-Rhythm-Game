using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    private bool panelState = false;

    private void Start()
    {
          panelState = false;
          mainMenuPanel.SetActive(panelState);
    }

    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);

    }

    public void TogglePanel()
    {
        panelState = !panelState;
        mainMenuPanel.SetActive(panelState);
    }


    public void GoToOverworld()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();     
    }
}
