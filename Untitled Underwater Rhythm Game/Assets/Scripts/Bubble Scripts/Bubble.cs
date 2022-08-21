using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float duration = 2.5f;
    [SerializeField] private Transform bubbleTransform;
    private float randomizeAnimStrength = 0.6f;
    private PathType pathType = PathType.CatmullRom;
    private PathMode pathMode = PathMode.Sidescroller2D;
    
    public static event Action fss;
   


    private Vector3 originPos; 
    private int waypointSize = 10; 
    private Vector3[] testWaypoints;
    private float timer;

    private void SetUpWayPoints()
    {
       //procedural set the waypoints to emulate bubble floating up
        for(int i = 0; i < waypointSize; i++)
        {
            //y is just always increasing by 1
            testWaypoints[i].y = i + 1 + originPos.y;

            //x is changing to -0.5 -> 0 -> 0.5 -> 0 pattern
            if (i % 4 == 1 || i % 4 == 3)
                testWaypoints[i].x = 0 + originPos.x;

            if (i % 4 == 0)
                testWaypoints[i].x = 0.5f + originPos.x;

            if (i % 4 == 2)
                testWaypoints[i].x = -0.5f + originPos.x;

        }

        //test print vals
       // foreach (Vector3 i in testWaypoints)
           // Debug.Log(i);
    }
    private void RandomizeWaypoints() //each bubble animation will have that natural floating anim, but will never look exactly the same 
    {
        for (int i =0; i < waypointSize; i++ )
        {
            testWaypoints[i].x += Random.Range(0, randomizeAnimStrength) - (randomizeAnimStrength /2);
            testWaypoints[i].y += Random.Range(0, randomizeAnimStrength) - (randomizeAnimStrength / 2);
        }
        //randomize duration as well
        duration += Random.Range(0, randomizeAnimStrength) - (randomizeAnimStrength / 2);

    }

    private void Start()
    {
        timer = 0;
        originPos = transform.position;
        testWaypoints = new Vector3[waypointSize]; //set up array size 
        SetUpWayPoints(); //set up the generic waypoint paths
        RandomizeWaypoints(); //randomize the waypoints a bit, so each bubble anim is not exactly the same
        bubbleTransform = transform;

        //driver for bubble anim
        Tween t = bubbleTransform.DOPath(testWaypoints, duration, pathType, pathMode);     
        t.SetEase(Ease.Linear).SetLoops(-1);
    }

    public void Pop()
    {
        

        //play pop bubble anim 

        //play bubble sfx, (musical?)

        //bubble manager will set disactive somewhere and place it somewhere else 
        //call bubble manager
        gameObject.SetActive(false);    
    }

    private void Update()
    {
      timer += Time.deltaTime;

        if(timer > duration)
        {
            Pop();
        }
    }
    private void OnEnable()
    {
        timer = 0;
        
    }
    private void OnMouseDown()
    {
        Pop();
    }
}
