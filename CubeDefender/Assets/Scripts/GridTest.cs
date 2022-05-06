using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    GridMap<int> grid;
    // Start is called before the first frame update
    void Start()
    {
        //grid = new GridMap<int>(5,9,2f,transform.position-Vector3.one, ()=>0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetGridObject(mousePos, 10);
        }

        if (Input.GetMouseButtonDown(1))
        {
            grid.GetGridObject(mousePos);
        }
    }
}
