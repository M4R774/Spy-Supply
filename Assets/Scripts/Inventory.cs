using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Grid2D<GameObject> grid;

    public List<GameObject> prefabs;
    int dragValue;

    int value;

  // Start is called before the first frame update
    void Start()  
    {
        grid = new Grid2D<GameObject>(10, 2, 1.6f, new Vector3(10, -3), (Grid2D<GameObject> g, int x, int y) => prefabs[Random.Range(0, prefabs.Count - 1)]);
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            Instantiate(grid.GetValue(x, 0), GetWorldPosition(x, 0) + new Vector3(grid.cellSize, grid.cellSize) * .5f, Quaternion.identity, GameObject.Find("ITEMS").transform);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (grid.GetValue(worldPosition) != null)
            {
                dragValue = 0;
            }
            else
            {
                dragValue = 1;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (dragValue != 0)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // grid.SetValue(worldPosition, dragValue);
            }
        }
    }

  private Vector3 GetWorldPosition(int x, int y)
  {
    return new Vector3(x, y) * grid.cellSize + grid.originPosition;
  }
}