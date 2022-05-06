using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMechanics : TowerMechanics
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        health += ((Defender)thisTower).BASE_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TowerAction()
    {
        //throw new System.NotImplementedException();
    }
}
