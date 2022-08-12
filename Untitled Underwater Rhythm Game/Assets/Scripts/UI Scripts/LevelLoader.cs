using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
       
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play anim
        animator.SetTrigger("Start");

        //wait 
        yield return new WaitForSeconds(transitionTime);

        //load scene 
        SceneManager.LoadScene(levelIndex);
    }
}
