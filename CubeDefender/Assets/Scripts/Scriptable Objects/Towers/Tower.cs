using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Type{ 
    Attacker,
    Defender,
    Producer,
    InstaUse,
    Placer
}
public abstract class Tower : ScriptableObject
{
    [Header("Placement info")]
    public Transform prefab;
    public int width = 1;
    public int height = 1;
    [Space, Header("Object Showcase Properties")]
    public Mesh mesh;
    public Material material;
    public Sprite showcaseTexture;
    [Space, Header("Gameplay Info")]
    public int price = 100;
    public float reloadTime = 7.5f;
    
    public bool isUpgradeable = false;
    public bool isUpgrade = false;
    public Tower Upgrade;

    public LayerMask canBePlacedOn;
    public int Health = 10;
    [HideInInspector]
    public Type type;

    

    public List<Vector2Int> TakenSpaces(Vector2Int pos){
        List < Vector2Int > posList = new List<Vector2Int>();
        for (int x = 0; x < width; x++){ 
            for(int y = 0; y < height; y++){
                posList.Add(pos + new Vector2Int(x, y));
            }
        }
        return posList;
    }
    public abstract void SetType();
}
