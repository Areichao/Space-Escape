using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    public bool[] complete = new bool[4];
    public GameObject door;

    public void checkComplete()
    {
        if (!door.GetComponent<BoxCollider2D>().enabled)
        { AudioManager.Instance.Play("Close"); Invoke("enableAgain", 0.35f); }

        foreach (bool condition in complete) if (!condition) return;
        AudioManager.Instance.Play("Open"); Invoke("disableDoor", 0.35f);
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
    }
}
