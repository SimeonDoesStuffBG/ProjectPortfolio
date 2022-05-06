using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Vector3 initialPos;

    private bool toFall = false;
    [SerializeField]
    private float maxDellay = 1f;
    [SerializeField]
    private float respawnDelay = 2f;
    private float fallDelay;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        initialPos = transform.localPosition;
        fallDelay = maxDellay;
    }

    void FixedUpdate(){
        if (toFall){
            fallDelay -= Time.fixedDeltaTime;
            if(fallDelay <= 0){
                toFall = false;
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (transform.position.y <= -25f){
            if (rb.bodyType == RigidbodyType2D.Dynamic){
                rb.bodyType = RigidbodyType2D.Static;
            }
            fallDelay += Time.fixedDeltaTime;
            if(fallDelay >= respawnDelay){
                transform.position = initialPos;
                fallDelay = maxDellay;
            }
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            toFall = true;
        }else{
            boxCollider.isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        boxCollider.isTrigger = false;
    }
}
