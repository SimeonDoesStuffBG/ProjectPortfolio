using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Insta-use Tower", menuName = "ScriptableObjects/Towers/Insta-use")]
public class InstaUse : Tower
{
    public override void SetType()
    {
        type = Type.InstaUse;
    }

    [Space, Header("Insta-use properties")]
    public bool imediateUse = false;
    public float range = 1.5f;
    public bool damagesCurrentSpot = false;
    public bool playerActivated = false;
    public ParticleSystem particleSystem;
}
