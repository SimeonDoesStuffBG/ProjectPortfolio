using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableMechanics : TowerMechanics
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        gameObject.layer = ((Placable)thisTower).layer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TowerAction()
    {
        throw new System.NotImplementedException();
    }
}
