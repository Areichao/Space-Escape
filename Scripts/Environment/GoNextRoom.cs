using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class GoNextRoom: MonoBehaviour
{
    public GameObject wall;
    public string song;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveCamera.Instance.moveCamera(gameObject.transform.GetChild(0).GetComponent<Transform>().position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x > transform.position.x) stuff();
            else 
                MoveCamera.Instance.moveCamera(gameObject.transform.GetChild(1).GetComponent<Transform>().position);
        }
    }

    private void stuff()
    {
        AudioManager.Instance.ChangeSong(song);
        Instantiate(wall, transform.position, Quaternion.identity);
        CameraShake.ShakeOnce(0.15f, 1.15f);
        Destroy(gameObject);
    }

}
