using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap<TGridObject>
{
    public event EventHandler<EventChangeArgs> OnValueChanged;
    public class EventChangeArgs : EventArgs{
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;
    Vector3 origin;

    private TGridObject[,] myGrid;
   public GridMap(int width, int height, float cellSize, Vector3 origin, Func<GridMap<TGridObject>, int, int, TGridObject> createGridObject){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        myGrid = new TGridObject[width, height];

        for (int i = 0; i < width; i++)
        {
            for(int j =0; j < height; j++)
            {
                myGrid[i, j] = createGridObject(this, i,j);
                Debug.DrawLine(GetWorldPos(i, j), GetWorldPos(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPos(i, j), GetWorldPos(i+1, j), Color.white, 100f);
            }
        }
    }

    public Vector3 GetWorldPos(int x, int y){
            return new Vector3(x, 0, y) * cellSize + origin;
    }

    public void GetXY(Vector3 pos, out int x, out int y){
        x = Mathf.FloorToInt((pos - origin).x / cellSize);
        y = Mathf.FloorToInt((pos - origin).z/ cellSize);
    }

    public Vector3 RecalculatePos(Vector3 pos){
        int x, y;
        GetXY(pos, out x, out y);
        return GetWorldPos(x, y);
    }
    public void SetGridObject(int x, int y, TGridObject GridObject){
        if (x >= 0 && x < width && y >= 0 && y < height){
            myGrid[x, y] = GridObject;
            if(OnValueChanged != null){
                OnValueChanged(this, new EventChangeArgs { x = x, y = y });
            }
        }
    }

    public void TriggerValueChanged(int x, int y){
        if (OnValueChanged != null)
        {
            OnValueChanged(this, new EventChangeArgs { x = x, y = y });
        }
    }
    public void SetGridObject(Vector3 pos, TGridObject GridObject)
    {
        int x, y;
        GetXY(pos, out x, out y);
        SetGridObject(x, y, GridObject);
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return myGrid[x, y];
        }
        else
        {
            return default(TGridObject);
        }
    }

    public TGridObject GetGridObject(Vector3 pos)
    {
        int x, y;
        GetXY(pos, out x, out y);
        return GetGridObject(x, y);
    }
}
