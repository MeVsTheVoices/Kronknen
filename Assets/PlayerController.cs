using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2.0f;
    public Vector3 movePoint;
    public Vector3Int moveGrid;

    public Tilemap tilemap;

    private Vector3Int currentGrid = new Vector3Int(0, 0, 0);

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movePoint != transform.position) {
            transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
            return;
        }

        currentGrid = moveGrid;

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            moveGrid = currentGrid + new Vector3Int(0, 1, 0);
            movePoint =  tilemap.GetCellCenterWorld(moveGrid);
            animator.SetTrigger("Walk up");
            setPositionToCell();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            moveGrid = currentGrid + new Vector3Int(0, -1, 0);
            movePoint =  tilemap.GetCellCenterWorld(moveGrid);
            animator.SetTrigger("Walk down");
            setPositionToCell();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            moveGrid = currentGrid + new Vector3Int(-1, 0, 0);
            movePoint =  tilemap.GetCellCenterWorld(moveGrid);
            animator.SetTrigger("Walk left");
            setPositionToCell();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            moveGrid = currentGrid + new Vector3Int(1, 0, 0);
            movePoint =  tilemap.GetCellCenterWorld(moveGrid);
            animator.SetTrigger("Walk right");
            setPositionToCell();
        }

    }

    void setPositionToCell() {
        transform.position = tilemap.GetCellCenterWorld(currentGrid);
    }
}
