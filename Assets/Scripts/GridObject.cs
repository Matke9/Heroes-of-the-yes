using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridObject : MonoBehaviour
{
    public Gridd grid;

    void Start()
    {
        grid = new Gridd(50,30,0.32f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
