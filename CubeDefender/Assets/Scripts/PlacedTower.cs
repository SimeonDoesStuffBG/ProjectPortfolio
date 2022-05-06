using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedTower : MonoBehaviour
{
    public static PlacedTower Create(Vector3 position, Vector2Int posOnGrid, Tower tower)
    {
        Transform towerTransform = Instantiate(tower.prefab, position, Quaternion.identity);
        

        PlacedTower mech = towerTransform.GetComponentInChildren<PlacedTower>();
        tower.SetType();
        GameObject child = towerTransform.GetChild(0).gameObject;
        switch (tower.type){
            case Type.Attacker:
                child.AddComponent<AttackerMechanics>();
                break;
            case Type.Producer:
                child.AddComponent<ProducerMechanics>();
                break;
            case Type.InstaUse:
                child.AddComponent<InstaUseMechanics>();
                break;
            case Type.Defender:
                child.AddComponent<DefenderMechanics>();
                break;
            case Type.Placer:
                child.AddComponent<PlacableMechanics>();
                break;
            default:
                break;
        }
        //mechanics.SetTower(tower);
        mech.towerType = tower;
        mech.posOnGrid = posOnGrid;
        mech.isUpgradeable = tower.isUpgradeable;

        return mech;
    }

    [HideInInspector]
    public bool isUpgradeable;
    private Tower towerType;
    private Vector2Int posOnGrid;
    // Start is called before the first frame update


    public List<Vector2Int> PositionsOnGrid()
    {
        return towerType.TakenSpaces(posOnGrid);
    }
    public void Remove()
    {
        Destroy(transform.parent.gameObject);
        //Destroy(gameObject);
    }

    public bool CorrectUpgrade(Tower upgrade){
        return towerType.Upgrade == upgrade;
    }

    public Tower GetTower(){
        return towerType;
    }
}