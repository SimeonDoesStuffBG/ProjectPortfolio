using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    Rigidbody2D rb;
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    public void Jump(float jumpSpeed){
        rb.velocity += Vector2.up * jumpSpeed;
    }
}
