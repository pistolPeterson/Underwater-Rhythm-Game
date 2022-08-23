using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPTentacle1 : MonoBehaviour
{

    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public bool trailDrag;
    public float trailSpeed = 350;
    private float smoothVal;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {

        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            if (trailDrag)
            {
                smoothVal = smoothSpeed + i / trailSpeed;
            }
            else
            {
                smoothVal = smoothSpeed;
            }
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothVal);
        }
        lineRend.SetPositions(segmentPoses);
    }
}
