using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform camPos;
    public static MoveCamera Instance { get; set; }

    private Vector3 newPos;
    private bool move = false;

    private void Start()
    {
        Instance = this;
        camPos = transform;
    }

    private void Update()
    {
        if (move) {
            PlayerMovement.Instance.canMove = false;
            camPos.position = Vector3.Lerp(camPos.position, newPos, 5 * Time.deltaTime);
            if (camPos.position.x > newPos.x - 0.15f && camPos.position.x < newPos.x + 0.15f) { move = false; PlayerMovement.Instance.canMove = true; }
        }
    }

    public void moveCamera(Vector2 position)
    {
        newPos = new Vector3(position.x, position.y, -10);
        move = true;
    }
}
