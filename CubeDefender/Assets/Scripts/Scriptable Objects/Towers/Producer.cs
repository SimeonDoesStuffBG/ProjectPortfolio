using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Producer Tower", menuName = "ScriptableObjects/Towers/Producer")]
public class Producer : Tower
{
    public override void SetType()
    {
        type = Type.Producer;
    }

    [Space, Header("Producer properties")]
    public float productionSpeed = 20f;
    public float initialProduction = 5f;
    public int currencyProduced = 25;
    public RectTransform currencyUnit;
}
