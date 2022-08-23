using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveNoteAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform feedbackAnimObject;
    public List<Vector3> placements; 
    // Start is called before the first frame update
    void Start()
    {
        feedbackAnimObject.anchoredPosition = placements[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            feedbackAnimObject.anchoredPosition = placements[0]; 
        
        if (Input.GetKeyDown(KeyCode.W))
            feedbackAnimObject.anchoredPosition = placements[1];
        
        if (Input.GetKeyDown(KeyCode.E))
            feedbackAnimObject.anchoredPosition = placements[2];
        
        if (Input.GetKeyDown(KeyCode.R))
            feedbackAnimObject.anchoredPosition = placements[3];
    }
}
