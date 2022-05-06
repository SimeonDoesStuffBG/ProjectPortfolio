using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] [Range(0,360)]
    private float movementAngle = 0;
    /*[SerializeField]
    private float horizontalMovement = 1f;
    [SerializeField]
    private float verticalMovement = 0f;*/
    [SerializeField]
    private float maxOffset = 3f;
    [SerializeField]
    private float speed = 2f;
    private Vector3 direction;
    private Vector3 neutralPosition;
    private Transform player;

    void Start(){
        //movementAngle = Mathf.Atan2(verticalMovement, horizontalMovement) * Mathf.Rad2Deg;
        movementAngle *= Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(movementAngle), Mathf.Sin(movementAngle), 0);
        //direction = new Vector3(horizontalMovement, verticalMovement, 0).normalized;
        neutralPosition = transform.position;
        speed /= 2;
    }

    void Update(){

        MovePlatform();
        float curOffset = Mathf.Abs((transform.position - neutralPosition).magnitude);
        //Debug.Log(curOffset);
        if (curOffset >= maxOffset){
            direction = -direction;
        }
        MovePlatform();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            player = other.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            player = null;
        }
    }

    private void MovePlatform(){//this will need a bit of explanation.
        //Initially the way I tackled this was simply doing this bit of code and then checking to see if the distance from the initial placement was more or less than the largest possible distance
        //And if it was I reversed the direction. It worked fine initially but there were edge cases where the player would always end up in a place where he'd have to reverse dirrection
        //My fix was to split the movement in two parts. I execute half of the movement, and then I do the check and direction change, before doing the other half and I haven't seen any edge cases
        //Because of this I half the platform's speed at the start. I do it at the start because it's an opperation that only needs to be done once so there was no point in putting it in a method called by update.
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.position += movement;
        if (player != null)
        {
            player.position += movement;
        }
    }

    private void OnDrawGizmos(){
        Vector3 dir = new Vector3(Mathf.Cos(movementAngle * Mathf.Deg2Rad), Mathf.Sin(movementAngle * Mathf.Deg2Rad), 0);
        Vector3 beg = transform.position +  dir * maxOffset;
        Vector3 end = transform.position - dir * maxOffset;
       
        Gizmos.DrawLine(beg, end);
        Gizmos.DrawWireCube(beg, transform.lossyScale);
        Gizmos.DrawWireCube(end, transform.lossyScale);
    }
}
