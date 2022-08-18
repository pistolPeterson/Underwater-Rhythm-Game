using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
       cam = GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = new Vector3 (playerPos.position.x, playerPos.position.y, cam.position.z);
        gameObject.transform.position = newPos;
    }
}
