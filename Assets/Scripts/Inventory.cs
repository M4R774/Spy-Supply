using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Grid2D<GameObject> grid;
    public GameObject slot;

    public List<GameObject> prefabs;

  // Start is called before the first frame update
    void Start()  
    {
        grid = new Grid2D<GameObject>(10, 2, 1.6f, new Vector3(12, -4.55f), (Grid2D<GameObject> g, int x, int y) => null);
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = grid.GetHeight() - 1; y >= 0; y--)
            {
                Instantiate(slot, GetWorldPosition(x, y) + new Vector3(grid.cellSize, grid.cellSize) * .5f, Quaternion.identity, GameObject.Find("InventorySlots").transform);
                //Instantiate(grid.GetValue(x, y), GetWorldPosition(x, y) + new Vector3(grid.cellSize, grid.cellSize) * .5f, Quaternion.identity, GameObject.Find("Inventory").transform);
            }
        }
        BulkAddRandomItemToEmptySlot(2);
    }

    private void AddItemToEmptySlot(GameObject item) {
        grid.SetFirstEmptyValue(item);
    }

    public void AddRandomItemToEmptySlot()
    {
        GameObject random_item_prefab = prefabs[Random.Range(0, prefabs.Count)];
        grid.GetFirstEmptySlot(out int x, out int y);

        GameObject new_item = Instantiate(random_item_prefab, grid.GetWorldPosition(x, y) + new Vector3(grid.cellSize, grid.cellSize) * .5f, Quaternion.identity, GameObject.Find("Inventory").transform);
        grid.SetValue(x, y, new_item);
    }

    public void BulkAddRandomItemToEmptySlot(int number_of_items_to_be_added)
    {
        for (int i = 0; i < number_of_items_to_be_added; i++)
        {
            AddRandomItemToEmptySlot();
        }
    }


    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * grid.cellSize + grid.originPosition;
    }
}