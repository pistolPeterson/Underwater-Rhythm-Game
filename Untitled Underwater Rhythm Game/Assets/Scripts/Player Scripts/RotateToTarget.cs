using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public float rotSpeed;
    private Vector2 direction;
    public float moveSpeed = 2.0f;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

       
        direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
      //  Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

     

    }
}
