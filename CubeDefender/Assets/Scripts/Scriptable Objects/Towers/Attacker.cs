using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attacking Tower", menuName = "ScriptableObjects/Towers/Attacker")]
public class Attacker : Tower
{
    public override void SetType()
    {
        type = Type.Attacker;
        //prefab.GetChild(0).gameObject.AddComponent<AttackerMechanics>();
    }
    [Space, Header("Attacker Properties")]
    public int projectileDamage = 3;
    public int projectilesFired = 1;
    public float attackSpeed = 3f;
    public float range = 20f;
    [Range(1, 3)]
    public int AffectedColumns = 1;
    public bool canHitAreal = false;
    [Header("Explosive Projectiles")]
    public bool explosiveProjectile = false;
    public float explosionRange = 1.5f;
    public ParticleSystem particleSystem;
}
