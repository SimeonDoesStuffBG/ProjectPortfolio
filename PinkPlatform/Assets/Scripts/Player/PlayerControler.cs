using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    Sprite openDoor;

    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float initialJumpSpeed = 5f;

    [SerializeField]
    private int maxJumps = 1;//A simple boolean would probably work better in this case but this allows me to reuse the code and add more jumps if needed for my purposes.
    private int jumpsLeft;

    Movement movement;
    Jumper jumper;

    void Start(){
        jumpsLeft = maxJumps;
        movement = gameObject.AddComponent<Movement>();
        jumper = gameObject.AddComponent<Jumper>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            movement.MoveRight(speed, maxSpeed);
        }else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
                movement.MoveLeft(speed, maxSpeed);
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpsLeft > 0) {
            jumper.Jump(initialJumpSpeed);
            jumpsLeft--;
        }
    }

    public bool isMoving(){
        bool movingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool movingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        return (movingLeft || movingRight);
    }

    public bool Jumps(){
        return (jumpsLeft != maxJumps);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground")){
            jumpsLeft = maxJumps;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground")){
            jumpsLeft = maxJumps - 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Spring")){
            jumper.Jump(initialJumpSpeed * 2);
            jumpsLeft--;//We count the use of the spring as a jump
        }else if(other.CompareTag("Door") && other.gameObject.GetComponent<SpriteRenderer>().sprite == openDoor){
            gameObject.GetComponent<LevelManager>().Victory();
        }
    }
}
