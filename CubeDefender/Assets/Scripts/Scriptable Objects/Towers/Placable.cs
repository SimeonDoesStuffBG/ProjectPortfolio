using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Placable Tower", menuName = "ScriptableObjects/Towers/Placable")]
public class Placable : Tower
{
    public override void SetType(){
        type = Type.Placer;
    }

    [Space, Header("Placer properties")]
    public LayerMask layer;
}
