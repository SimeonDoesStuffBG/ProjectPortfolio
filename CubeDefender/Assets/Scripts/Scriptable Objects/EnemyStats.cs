using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy", menuName ="ScriptableObjects/Enemy")]
public class EnemyStats : ScriptableObject
{
    public Transform prefab;
    [Header("Visuals")]
    public Mesh mesh;
    public Material material;
    [Space, Header("Gameplay Stats")]
    public int health;
    public int damage;
    public int instaKillsTanked;
    
    public float movementSpeed;
    public float runningModifier = 1;
    
    public bool canBeEaten = true;
    public bool isAreal = false;
    public bool leapsOver = false;
}
