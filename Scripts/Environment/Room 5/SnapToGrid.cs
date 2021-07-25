using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            collision.transform.position = transform.position;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
