using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Movement movement;
    Jumper jumper;
    Animator animator;

    bool LeftOrRight;
    float Acceleration = 10;
    float WalkSpeed = 10;
    float RunSpeed = 20;

    [SerializeField]
    float positiveOffset = 0;
    [SerializeField]
    float negativeOffset = 0;

    Vector3 negativeGoal;
    Vector3 positiveGoal;
    void Start()
    {
        movement = gameObject.AddComponent<Movement>();
        jumper = gameObject.AddComponent<Jumper>();
        animator = gameObject.GetComponent<Animator>();

        positiveGoal = transform.position + Vector3.right * positiveOffset;
        negativeGoal = transform.position + Vector3.left * negativeOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(negativeGoal,transform.position)<=.001f || Vector3.Distance(positiveGoal, transform.position) <= .001f){
            LeftOrRight = !LeftOrRight;
        }
        if (LeftOrRight){
            movement.MoveLeft(Acceleration, WalkSpeed);
        }
        else
        {
            movement.MoveRight(Acceleration, WalkSpeed);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + Vector3.right * positiveOffset, .1f);
        Gizmos.DrawSphere(transform.position + Vector3.left * negativeOffset, .1f);
    }
}
