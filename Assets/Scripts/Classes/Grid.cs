using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private float width;
    private float height;
    private float cellSize;
    private int[,] Cells;
    public Grid(int width, int height, float cellSize) 
    {
        this.width = width;
        this.height = height;
        Cells = new int[width, height];
        this.cellSize = cellSize;

        for (float i = 0; i < Cells.GetLength(0); i++)
        {
            for (float j = 0; j < Cells.GetLength(1); j++)
            {
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3(x, y) * cellSize - new Vector3(width, height) * cellSize / 2;
    }
}
