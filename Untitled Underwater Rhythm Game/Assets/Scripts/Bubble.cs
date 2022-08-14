using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float duration = 2.5f;
    [SerializeField] private Transform bubbleTransform;
    public PathType pathType = PathType.CatmullRom;
    private PathMode pathMode = PathMode.Sidescroller2D;
    public Vector3[] waypoints;



    private int size = 16; 
    private Vector3[] testWaypoints; 

    void SetUpVector3()
    {
       
        for(int i = 0; i < size; i++)
        {
            testWaypoints[i].y = i + 1;

            if (i % 4 == 1 || i % 4 == 3)
                testWaypoints[i].x = 0;

            if (i % 4 == 0)
                testWaypoints[i].x = 0.5f;

            if (i % 4 == 2)
                testWaypoints[i].x = -0.5f;

        }

        //test print vals
        foreach (Vector3 i in testWaypoints)
            Debug.Log(i);
    }

    
    private void Start()
    {
        testWaypoints = new Vector3[size];
        SetUpVector3();
       bubbleTransform = transform;
        //transform.DOMove(new Vector3(5, 0, 0), duration);
        Tween t = bubbleTransform.DOPath(testWaypoints, duration, pathType, pathMode);//*.SetOptions(true).SetLookAt(0.001f);
        // Then set the ease to Linear and use infinite 
        t.SetEase(Ease.Linear).SetLoops(-1);
    }

    private void Update()
    {
      
    }
    private void OnEnable()
    {
        Debug.Log(" bubble is enabled?");
    }
    private void OnMouseDown()
    {
        //play pop bubble anim 

        //play bubble sfx, (musical?)

        //bubble manager will set disactive somewhere and place it somewhere else 
    }
}
