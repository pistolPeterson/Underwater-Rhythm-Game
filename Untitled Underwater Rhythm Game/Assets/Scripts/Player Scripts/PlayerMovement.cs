using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range (5.0f, 15.0f)]private float moveSpeed;
   // [SerializeField] [Range(248f, 512f)] private float rotSpeed;
    private float moveHorizontal;
    private float moveVertical;


    private bool facingRight = true;
    private Rigidbody2D rb2D;
    private bool isMoveable = true;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isMoveable = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!isMoveable) return;

        if (moveHorizontal != 0f || moveVertical != 0f)
        {
             rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
           // rb2D.MovePosition(rb2D.position + new Vector2(moveHorizontal, moveVertical) * moveSpeed * Time.deltaTime);
        }


       

        
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void FreezePlayer() { isMoveable = false; rb2D.velocity = Vector2.zero; }
    public void UnFreezePlayer() { isMoveable = true; } 
}
