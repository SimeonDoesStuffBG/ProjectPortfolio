using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        if(rb == null){
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }

   public void MoveLeft(float speed, float maxSpeed){
        transform.localScale = new Vector2(-1, 1);
        if (rb.velocity.x >= -maxSpeed){//Using the negative of the max speed to insure a speed Limit applies when moving left(negative speed)
            rb.AddForce(Vector2.left * speed);
        }
    }

    public void MoveRight(float speed, float maxSpeed) {
        transform.localScale = new Vector2(1, 1);
        if (rb.velocity.x <= maxSpeed){
            rb.AddForce(Vector2.right * speed);
        }
    }
}
