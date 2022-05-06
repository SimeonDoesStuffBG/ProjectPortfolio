using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerMechanics : TowerMechanics
{
    [SerializeField]
    LayerMask enemy;

    private int projectileDamage;

    private float range;
    private int affectedColumns;
    private bool canHitAreal;

    private bool explosiveProjectiles;
    private float explosionRange;
    ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        system = ((Attacker)thisTower).particleSystem;
        float maxR = Mathf.Abs((transform.position - GameObject.Find("Border").transform.position).z);
        projectileDamage = ((Attacker)thisTower).projectileDamage * ((Attacker)thisTower).projectilesFired;
        if (explosiveProjectiles)
            projectileDamage /= 2;
        
        delay =((Attacker)thisTower).attackSpeed;
        range = Mathf.Min(((Attacker)thisTower).range,maxR);
        Debug.Log(range);
        affectedColumns = ((Attacker)thisTower).AffectedColumns;
        canHitAreal = ((Attacker)thisTower).canHitAreal;

        explosiveProjectiles = ((Attacker)thisTower).explosiveProjectile;
        explosionRange = ((Attacker)thisTower).explosionRange;

        enemy = LayerMask.GetMask("Enemy");
        StartCoroutine(Attack());
        //SetRepeat();
    }

    Enemy FindEnemy(){
        Vector3 boxSize = new Vector3(affectedColumns, 1, 1);
        if (Physics.BoxCast(transform.position, boxSize, Vector3.back, out RaycastHit hit,Quaternion.identity, range, enemy)){
            Debug.Log("Hit");
            return hit.collider.gameObject.GetComponent<Enemy>();
        }
        return null;
    }

    public IEnumerator Attack() 
    {
        while (true){
            yield return new WaitForSeconds(delay);
            TowerAction();
        }
    }
    IEnumerator SpawnParticleSystem()
    {
        ParticleSystem sys = Instantiate(system, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(sys);
    }

    public override void TowerAction()
    {
        if (FindEnemy()!=null) {
            audioManager.PlaySound("Shooting");
            StartCoroutine(SpawnParticleSystem());
            if (FindEnemy().isAreal)
            {
                if (canHitAreal)
                {
                    FindEnemy().isAreal = false;
                }
            }
            else
            {
                FindEnemy().TakeDamage(projectileDamage);
               
                if (explosiveProjectiles)
                {
                      
                    audioManager.PlaySound("Explosion");
                    Collider[] EnemiesInRange = Physics.OverlapSphere(FindEnemy().transform.position, explosionRange, enemy);
                    foreach (Collider c in EnemiesInRange)
                    {
                        c.GetComponent<Enemy>().TakeDamage(projectileDamage);
                    }
                   
                }
              
            }
            StopCoroutine(SpawnParticleSystem());
        } 
    }


}
