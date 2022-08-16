using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private int length;
    public Vector3[] segmentPoses;
    [SerializeField] private float targetDist;
    [SerializeField] private float smoothSpeed;

    private Vector3[] segmentV;
    [SerializeField] private Transform targetDir; 
    private LineRenderer lr;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        for(int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1]+ targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        lr.SetPositions(segmentPoses);
    }
}
