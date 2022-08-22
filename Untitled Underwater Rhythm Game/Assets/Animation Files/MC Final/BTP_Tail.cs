using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTP_Tail : MonoBehaviour
{

    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    public bool tailHasEnd;
    public Transform tailEnd;

    public bool hasBodyParts;
    public Transform[] bodyParts;

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {

        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);

            if (hasBodyParts)
            {
                bodyParts[i - 1].transform.position = segmentPoses[i];
            }

        }
        lineRend.SetPositions(segmentPoses);

        if (tailHasEnd)
        {
            tailEnd.position = segmentPoses[segmentPoses.Length - 1];
        }
    }

    private void ResetPos()
    {
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;
        }
        lineRend.SetPositions(segmentPoses);
    }
}

