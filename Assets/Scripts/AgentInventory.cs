using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInventory : MonoBehaviour
{
    public Grid2D<GameObject> grid;
    List<GameObject> items;
    public GameObject slot;

  // Start is called before the first frame update
    void Start()
    {
        grid = new Grid2D<GameObject>(3, 1, 1.6f, new Vector3(16, -1), null);
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = grid.GetHeight() - 1; y >= 0; y--)
            {
                Instantiate(slot, GetWorldPosition(x, y) + new Vector3(grid.cellSize, grid.cellSize) * .5f, Quaternion.identity, GameObject.Find("AgentInventorySlots").transform);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * grid.cellSize + grid.originPosition;
    }
}
