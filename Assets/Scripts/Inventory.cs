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
        grid = new Grid2D<GameObject>(10, 2, 1.6f, new Vector3(10, -5), (Grid2D<GameObject> g, int x, int y) => prefabs[Random.Range(0, prefabs.Count - 1)]);
        for (int x = 0; x < grid.GetWidth(); x++)
        {
        for (int y = grid.GetHeight() - 1; y >= 0; y--)
            {
                Debug.Log("Y: " + y);
                Instantiate(grid.GetValue(x, y), GetWorldPosition(x, y) + new Vector3(grid.cellSize, grid.cellSize) * .5f, Quaternion.identity, GameObject.Find("Inventory").transform);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * grid.cellSize + grid.originPosition;
    }
}