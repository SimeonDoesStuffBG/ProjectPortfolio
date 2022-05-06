using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerMechanics : MonoBehaviour
{
    protected AudioManager audioManager;

    protected Tower thisTower;
    protected float delay;

    bool isUbgradeable;
    LayerMask canBePlacedOn;
    protected int health;
    

    protected void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        thisTower = GetComponent<PlacedTower>().GetTower();
       
        isUbgradeable = thisTower.isUpgradeable;
        canBePlacedOn = thisTower.canBePlacedOn;
        health = thisTower.Health;

        GetComponent<MeshFilter>().mesh = thisTower.mesh;
        GetComponent<MeshRenderer>().material = thisTower.material;
    }


    // Update is called once per frame

    public abstract void TowerAction();

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);    
    }
}
