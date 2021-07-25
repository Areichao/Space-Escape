using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Box")) 
        {
            AudioManager.Instance.Play("Open"); Invoke("disableDoor", 0.35f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(door.GetComponent<BoxCollider2D>().enabled) { AudioManager.Instance.Play("Open"); Invoke("disableDoor", 0.35f); }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag("Box"))
        {
            AudioManager.Instance.Play("Close"); Invoke("enableAgain", 0.35f);
        }
    }

    private void enableAgain()
    {
        CameraShake.ShakeOnce(0.08f, 0.98f);
        door.GetComponent<BoxCollider2D>().enabled = true;
        door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
    }

    private void disableDoor()
    {
        CameraShake.ShakeOnce(0.15f, 1.15f); door.GetComponent<BoxCollider2D>().enabled = false; door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
        CancelInvoke();
    }
}
