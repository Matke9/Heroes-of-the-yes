using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int GCost;
    public int HCost;
    public int FCost;
    public List<Node> neighbours;
    public Gridd grid;
    public Location xy;
    public Node parent;

    public Node(int x, int y, int xh, int yh, int GC, Gridd grid)
    {
        int dxh, dyh;
        dxh = Mathf.Abs(x - xh);
        dyh = Mathf.Abs(y - yh);
        this.HCost = Mathf.Abs(dxh - dyh) * 10 + Mathf.Min(dxh, dyh) * 14;
        this.GCost = GC;
        this.FCost = this.GCost + this.HCost;
        this.grid = grid;
        this.xy = new Location(x, y);
        if (x - 1 >= 0 && x - 1 < grid.width &&
            y - 1 >= 0 && y - 1 < grid.height &&
            grid.Cells[x - 1, y - 1] != 0)
        {
            neighbours.Add(new Node(x - 1, y - 1, xh, yh, GC + 15, grid));
        }
        if (x >= 0 && x < grid.width &&
           y - 1 >= 0 && y - 1 < grid.height &&
           grid.Cells[x, y - 1] != 0)
        {
            neighbours.Add(new Node(x, y - 1, xh, yh, GC + 10, grid));
        }
        if (x + 1 >= 0 && x + 1 < grid.width &&
           y - 1 >= 0 && y - 1 < grid.height &&
           grid.Cells[x + 1, y - 1] != 0)
        {
            neighbours.Add(new Node(x + 1, y - 1, xh, yh, GC + 15, grid));
        }
        //****************************************************************************
        if (x - 1 >= 0 && x - 1 < grid.width &&
            y >= 0 && y < grid.height &&
            grid.Cells[x - 1, y - 1] != 0)
        {
            neighbours.Add(new Node(x - 1, y, xh, yh, GC + 10, grid));
        }
        if (x + 1 >= 0 && x + 1 < grid.width &&
           y >= 0 && y < grid.height &&
           grid.Cells[x + 1, y - 1] != 0)
        {
            neighbours.Add(new Node(x + 1, y, xh, yh, GC + 10, grid));
        }
        //****************************************************************************
        if (x - 1 >= 0 && x - 1 < grid.width &&
            y + 1 >= 0 && y + 1 < grid.height &&
            grid.Cells[x - 1, y - 1] != 0)
        {
            neighbours.Add(new Node(x - 1, y + 1, xh, yh, GC + 15, grid));
        }
        if (x >= 0 && x < grid.width &&
           y + 1 >= 0 && y + 1 < grid.height &&
           grid.Cells[x, y + 1] != 0)
        {
            neighbours.Add(new Node(x, y - 1, xh, yh, GC + 10, grid));
        }
        if (x + 1 >= 0 && x + 1 < grid.width &&
           y + 1 >= 0 && y + 1 < grid.height &&
           grid.Cells[x + 1, y - 1] != 0)
        {
            neighbours.Add(new Node(x + 1, y + 1, xh, yh, GC + 15, grid));
        }
    }
}
