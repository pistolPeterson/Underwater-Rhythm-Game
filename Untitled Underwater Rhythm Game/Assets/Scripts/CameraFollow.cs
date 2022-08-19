using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    private Transform cam;
    private bool followPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
       cam = GetComponent<Transform>();
        followPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(followPlayer)
            FollowPlayer();

    }

    void FollowPlayer()
    {
        var newPos = new Vector3(playerPos.position.x, playerPos.position.y, cam.position.z);
        gameObject.transform.position = newPos;
    }

    public void FollowObjectOneTime(Vector3 vector3)
    {
        followPlayer = false;
        transform.DOMove(new Vector3(80, 0, -125), 3);
    }
}
