using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    Grid2D<int> grid;
    int dragValue;

    int value;

  // Start is called before the first frame update
    void Start()
    {
        grid = new Grid2D<int>(15, 2, 1f, new Vector3(10, -3), (Grid2D<int> g, int x, int y) => 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (grid.GetValue(worldPosition) == 1)
            {
                dragValue = 0;
            } else {
                dragValue = 1;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(dragValue != 0)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                grid.SetValue(worldPosition, dragValue);
            }
        }
    }
}
