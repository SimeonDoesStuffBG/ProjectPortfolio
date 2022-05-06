using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Defender Tower", menuName = "ScriptableObjects/Towers/Defender")]
public class Defender : Tower
{
    public override void SetType()
    {
        type = Type.Defender;
    }

    [Space, Header("Defender Properties")]
    public readonly int BASE_HEALTH = 100;
    public bool canBeLeaped = true;
    public bool CanBePlacedOnOthers = false;
}