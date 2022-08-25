using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Vector3 basePos;
    Vector3 camBase;
    new Camera camera;
    private void Awake()
    {

        basePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        camera = FindObjectOfType<Camera>();
        camBase = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);

    }

    private void Update()
    {
        float newX = basePos.x + (camera.transform.position.x - camBase.x) * ((basePos.z % 10) / 10);
        float newY = basePos.y + (camera.transform.position.y - camBase.y) * ((basePos.z % 10) / 10);

        transform.position = new Vector3(newX, newY, basePos.z);
    }
}
