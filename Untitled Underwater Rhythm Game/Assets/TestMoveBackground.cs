using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveBackground : MonoBehaviour
{
    private float startPosx;
    private float startPosy;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect; 
    // Start is called before the first frame update
    void Start()
    {
        startPosx = transform.position.x;
        startPosy = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float xdistance = (cam.transform.position.x * parallaxEffect);
        float ydistance = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startPosx + xdistance, startPosy + ydistance, transform.position.z);
    }
}
