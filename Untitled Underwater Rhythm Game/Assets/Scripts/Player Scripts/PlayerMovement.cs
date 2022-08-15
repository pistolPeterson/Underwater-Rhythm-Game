using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range (5.0f, 15.0f)]private float moveSpeed;
    [SerializeField] [Range(50f, 70f)] private float jumpForce;
    private float moveHorizontal;
    private float moveVertical;


    private bool facingRight = true;
    private Rigidbody2D rb2D;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(moveHorizontal != 0f || moveVertical != 0f)
        {
            rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
        }
        


        //flipping mechanic 
        if(moveHorizontal > 0 && !facingRight )
        {
            Flip();
        }
        if(moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
