using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Vector3 hiddenPos;
    private Vector3 exposedPos;
    [SerializeField]
    private float exposingSpeed = 0.1f;
    [SerializeField]
    private float dellay = 1f;
    private float currentDelay = 0f;
    //bool isSpiked = false;

    void Start()
    {
        hiddenPos = transform.position;
        exposedPos = transform.position + new Vector3(0, .5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDelay < 2 * dellay){
            currentDelay += Time.deltaTime;
            if(currentDelay >= dellay){
                PopUp(exposedPos);
            }
        }
        else{
            PopUp(hiddenPos);
            if(transform.position == hiddenPos){
                currentDelay = 0;
            }
        }
    }

    private void PopUp(Vector3 desiredPosition){
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, exposingSpeed);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision){
            Debug.Log("Spiked");
            collision.gameObject.GetComponent<LevelManager>().LoseLife();
    }
}
