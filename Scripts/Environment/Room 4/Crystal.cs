using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public int value;

    private void Start()
    {
        GetComponent<Rigidbody2D>().mass = value * 7;
    }
}
