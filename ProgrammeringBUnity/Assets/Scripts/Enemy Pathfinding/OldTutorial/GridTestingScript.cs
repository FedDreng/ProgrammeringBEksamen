using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTestingScript : MonoBehaviour
{
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(4, 2, 1, new Vector3(-9, -5));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grid.SetValue(worldPosition, 56);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print(grid.GetValue(worldPosition));
        }
    }
}
