using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    private Grid grid;
    private Tilemap tilemap;
    public Tile tile;

    private Vector3Int previousMousePos = new Vector3Int();

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        tilemap = gameObject.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int mousePos = getMousedOverTile();
        if (!mousePos.Equals(previousMousePos)) {
            
        }

        if (Input.GetMouseButton(0)) {
            Debug.Log("Selected tile (" + mousePos.x + ", " + mousePos.y + ", " + mousePos.z + ")");
            tilemap.SetTile(mousePos, tile);
        }
    }

    Vector3Int getMousedOverTile() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
