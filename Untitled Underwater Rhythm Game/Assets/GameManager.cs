using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int roundsPerBattle = 3; 
    private int currentRound = 0;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }

    public void NextRound()
    {
        currentRound++;
        FindObjectOfType<Melody>(); //go to melody and switch to another melody
    }
}
