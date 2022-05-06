using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum Type{
    Collectable,
    Rocket_Jump
}

public class PickUps : MonoBehaviour{
    [SerializeField]
    TextMeshProUGUI Text;

    private static int collectedPickUps;
    private static int maxCollectables;

    GameObject Door;
    [SerializeField]
    Sprite closedDoor;
    [SerializeField]
    Sprite openedDoor;

    [SerializeField]
    Type type = Type.Collectable;
    private void Awake()
    {
        collectedPickUps = 0;
        maxCollectables = GameObject.FindGameObjectsWithTag("Pick-up").Length;
        //at the start of the game we get the ammount of keys to pick up
    }

    private void Start()
    {
        Door = GameObject.FindGameObjectWithTag("Door");
    }

    private void Update()
    {
        Door.GetComponent<SpriteRenderer>().sprite = (collectedPickUps == maxCollectables) ? closedDoor : openedDoor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            if (type == Type.Collectable) {
                collectedPickUps++;
                Text.text = (collectedPickUps + "x");
                Debug.Log("You have " + collectedPickUps + " keys");
            }else if(type == Type.Rocket_Jump){
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            }
            Destroy(gameObject);
        }
    }
}
