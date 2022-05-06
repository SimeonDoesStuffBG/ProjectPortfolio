using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaUseMechanics : TowerMechanics
{
    // Start is called before the first frame update
   
    ParticleSystem system;   
    void Start()
    {
       
        base.Start();
        system = ((InstaUse)thisTower).particleSystem;
        if (((InstaUse)thisTower).imediateUse)
            StartCoroutine(TowerActionWithDelay(1));
    }

    // Update is called once per frame
    public void Update()
    {
        if (Physics.BoxCast(transform.position, Vector3.one, transform.forward * -1, out RaycastHit hit, Quaternion.identity, .1f, LayerMask.GetMask("Enemy")))
        {
            TowerAction();
        }
    }


    IEnumerator TowerActionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TowerAction();
    }
    IEnumerator SpawnParticleSystem()
    {
        ParticleSystem sys =  Instantiate(system,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(sys);
    }
    public override void TowerAction()
    {
        
        audioManager.PlaySound("Explosion");
        Collider[] EnemiesInRange= Physics.OverlapSphere(transform.position, ((InstaUse)thisTower).range,LayerMask.GetMask("Enemy"));
        foreach(Collider c in EnemiesInRange){
            c.GetComponent<Enemy>().InstaKillEffect();
        }
        StartCoroutine(SpawnParticleSystem());
        TakeDamage(this.health);
    }
}
