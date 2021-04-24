using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Grid2D<TGridObject>
{
  public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
  public class OnGridValueChangedEventArgs : EventArgs {
    public int x;
    public int y;
  }
  private int height;
  private int width;
  private TGridObject[,] gridArray;
  private float cellSize;
  private Vector3 originPosition;
  private TextMesh[,] debugTextArray;

  public Grid2D(int width, int height, float cellSize, Vector3 originPosition, Func<Grid2D<TGridObject>, int, int, TGridObject> createGridObject)
  {
    this.width = width;
    this.height = height;
    this.cellSize = cellSize;
    this.originPosition = originPosition;

    gridArray = new TGridObject[width, height];
    debugTextArray = new TextMesh[width, height];

    for (int x = 0; x < gridArray.GetLength(0); x++)
    {
      for (int y = 0; y < gridArray.GetLength(1); y++)
      {
        gridArray[x, y] = createGridObject(this, x, y);
      }
    }

    for (int x = 0; x < gridArray.GetLength(0); x++)
    {
      for (int y = 0; y < gridArray.GetLength(1); y++)
      {
        debugTextArray[x, y] = CreateWorldText(null, gridArray[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 10, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center);
        Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
      }
    }
    Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
    Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

    OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
    {
      debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y].ToString();
    };
  }

  public void TriggerGridObjectChanged(int x, int y)
  {
    if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
  }
  public float GetCellSize() {
    return this.cellSize;
  }
  public int GetWidth() {
    return this.width;
  }

  public int GetHeight() {
    return this.height;
  }
  private Vector3 GetWorldPosition(int x, int y)
  {
    return new Vector3(x, y) * cellSize + originPosition;
  }

  public void SetValue(int x, int y, TGridObject value)
  {
    if (x >= 0 && y >= 0 && x < width && y < height)
    {
      gridArray[x, y] = value;
      if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }
  }

  public void SetValue(Vector3 worldPosition, TGridObject value)
  {
    int x, y;
    GetXY(worldPosition, out x, out y);
    SetValue(x, y, value);
  }

  public TGridObject GetValue(int x, int y)
  {
    if (x >= 0 && y >= 0 && x < width && y < height)
    {
      return gridArray[x, y];
    }
    else
    {
      return default(TGridObject);
    }
  }

  public TGridObject GetValue(Vector3 worldPosition)
  {
    int x, y;
    GetXY(worldPosition, out x, out y);
    
    return GetValue(x, y);
  }
  public void GetXY(Vector3 worldPosition, out int x, out int y)
  {
    x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
    y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
  }

  public TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment)
  {
    GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
    Transform transform = gameObject.transform;
    transform.SetParent(parent, false);
    transform.localPosition = localPosition;
    TextMesh textMesh = gameObject.GetComponent<TextMesh>();
    textMesh.anchor = textAnchor;
    textMesh.alignment = textAlignment;
    textMesh.text = text;
    textMesh.fontSize = fontSize;
    textMesh.color = color;
    return textMesh;
  }
}
