using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     private Transform player;
    private Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField]
    private float followSmoothing = 0.1f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//We get the player possition
    }

    void LateUpdate(){
        Vector3 expectesPosition = player.position + offset;//gives us the position of the player+the wanted camera offset
        Vector3 cameraPosition = Vector3.Lerp(transform.position, expectesPosition, followSmoothing);//interpolater between the current camera position and the desired one with the float FollowSmoothing to give tha camera movement a bit of dellay
        transform.position = cameraPosition;
    }
}
