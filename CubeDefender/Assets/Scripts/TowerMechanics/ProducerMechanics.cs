using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducerMechanics : TowerMechanics
{

    void Start()
    {
        base.Start();
        delay = ((Producer)thisTower).initialProduction;
        StartCoroutine(Produce());
        delay = ((Producer)thisTower).productionSpeed;
    }

    // Update is called once per frame

    public override void TowerAction()
    {
        ManaPellet.Create(((Producer)thisTower).currencyUnit, ((Producer)thisTower).currencyProduced, transform.position);
    }

    IEnumerator Produce(){
        while (true){
            yield return new WaitForSeconds(delay);
            TowerAction();
        }
    }
}
