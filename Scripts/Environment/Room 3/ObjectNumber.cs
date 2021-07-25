using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNumber : MonoBehaviour
{
    public int number;

    public bool stayActive;

    private void Update()
    {
        if(stayActive) 
            GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GridManager.Instance.updateList(number);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GridManager.Instance.updateList(number);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
