using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    private Transform cam;
    private bool followPlayer = true;

    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
       cam = GetComponent<Transform>();
        followPlayer = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(followPlayer)
            FollowPlayer();

    }

    public void FollowPlayer()
    {
        float interpolation = speed * Time.deltaTime;
        followPlayer = true;
        var newPos = new Vector3(playerPos.position.x, playerPos.position.y, cam.position.z);
        newPos.x = Mathf.Lerp(transform.position.x, playerPos.position.x, interpolation);
        newPos.y = Mathf.Lerp(transform.position.y, playerPos.position.y, interpolation);
        gameObject.transform.position = newPos;
    }

    public void FollowObjectOneTime(Vector3 vector3)
    {
        followPlayer = false;
        transform.DOMove(vector3, 3);
    }
}
