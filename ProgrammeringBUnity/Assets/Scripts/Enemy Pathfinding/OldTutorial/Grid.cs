using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;
using System;

public class Grid : MonoBehaviour
{
    private GameObject gridText;

    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private GameObject[,] debugTextArray;


    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new GameObject[width, height];

        //grid text
        gridText = new GameObject("I am not here");
        gridText.AddComponent<TextMesh>();
        gridText.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        gridText.GetComponent<TextMesh>().characterSize = 1.5f;
        gridText.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;


        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //funktion der laver et grid, med x & y.

                debugTextArray[x,y] = Instantiate(gridText, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, Quaternion.identity);
                debugTextArray[x,y].name = $"{x}, {y}";
                debugTextArray[x, y].GetComponent<TextMesh>().text = "0";

                //Optional display number on TextMesh: (don't need it rn)
                //debugTextArray[x,y].GetComponent<TextMesh>().text = $"{x}, {y}";
                
                //grid boxes
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        //grid boxes final
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

    }

    public void SetValue(int x, int y, int value)
    {
        if(x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x,y].GetComponent <TextMesh>().text = gridArray[x,y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        } else
        {
            return 0;
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

}
