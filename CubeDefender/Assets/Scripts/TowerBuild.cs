using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerBuild : MonoBehaviour
{
    GridMap<GridObject> playingField;

    int gridWidth = 9;
    int gridHeight = 5;

    bool removeOrPlace = true;//true=place a building, false=remove


    [HideInInspector]
    public Tower tower = null;
    public Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (tower != null && Physics.Raycast(ray, out RaycastHit hit, 999f, tower.canBePlacedOn))
        {
            //Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), hit.point,Color.white,100f);
            return hit.point;
        }
        else
        {
            return new Vector3(11f,0,19);
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        float cellSize = 2f;
        playingField = new GridMap<GridObject>(gridHeight,gridWidth,cellSize, transform.GetChild(0).position, (GridMap<GridObject> g, int x, int y)=>new GridObject(g,x,y));
    }
    
    public void ToggleToRemove() { removeOrPlace = !removeOrPlace; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playingField.GetXY(GetMousePosition(), out int x, out int y);
            if (x >= 0 && x < gridHeight && y >= 0 && y < gridWidth)
            {
                GridObject gridObject = playingField.GetGridObject(x, y);
                if (removeOrPlace)
                {
                    if (tower != null)
                    {
                        List<Vector2Int> BuildingPositions = tower.TakenSpaces(new Vector2Int(x, y));
                        bool canBuild = true;
                        foreach (Vector2Int BuildingPos in BuildingPositions)
                        {
                            if (!playingField.GetGridObject(BuildingPos.x, BuildingPos.y).CanBuild())
                            {
                                if (!tower.isUpgrade)
                                {
                                    canBuild = false;
                                    break;
                                }
                                else if (playingField.GetGridObject(BuildingPos.x, BuildingPos.y).GetTowerPlaced().isUpgradeable)
                                {
                                    if (!playingField.GetGridObject(BuildingPos.x, BuildingPos.y).GetTowerPlaced().CorrectUpgrade(tower))
                                    {
                                        canBuild = false;
                                        break;
                                    }
                                }

                            }
                            else if (tower.isUpgrade)
                            {
                                canBuild = false;
                                break;
                            }
                        }
                            if (canBuild)
                            {
                                PlacedTower mech = PlacedTower.Create(playingField.GetWorldPos(x, y), new Vector2Int(x, y), tower);
                                ImportantValues.SubtractMoney(tower.price);
                                foreach (Vector2Int BuildingPos in BuildingPositions)
                                {
                                    if (!playingField.GetGridObject(BuildingPos.x, BuildingPos.y).CanBuild())
                                        playingField.GetGridObject(BuildingPos.x, BuildingPos.y).GetTowerPlaced().Remove();
                                    playingField.GetGridObject(BuildingPos.x, BuildingPos.y).SetTowerPlaced(mech);
                                }
                            }
                        }
                    }
                    else
                    {
                        GridObject obj = playingField.GetGridObject(GetMousePosition());
                        PlacedTower mech = obj.GetTowerPlaced();
                        if (mech != null)
                        {
                            List<Vector2Int> BuildingPositions = mech.GetTower().TakenSpaces(new Vector2Int(x, y));
                            mech.Remove();
                            foreach (Vector2Int BuildingPos in BuildingPositions)
                            {
                                playingField.GetGridObject(BuildingPos.x, BuildingPos.y).ClearTowerPlaced();
                            }
                        }
                        removeOrPlace = true;
                    }
                }
                tower = null;
            }
        }

   public class GridObject {
        private GridMap<GridObject> grid;
        private int x;
        private int y;
        private PlacedTower towerPlaced;
        
        public void SetTowerPlaced(PlacedTower transfrom){
            this.towerPlaced = transfrom;
            grid.TriggerValueChanged(x, y);
        }

        public void ClearTowerPlaced(){
            towerPlaced = null;
            grid.TriggerValueChanged(x, y);
        }

        public PlacedTower GetTowerPlaced(){
            return towerPlaced;
        }
        public bool CanBuild(){
            return towerPlaced == null;
        }
        public GridObject(GridMap<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }
    }
}
