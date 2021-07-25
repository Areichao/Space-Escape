using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public static SwitchManager Instance { get; set; }
    public List<bool> switches = new List<bool>();
    public GameObject[] plates;
    [SerializeField]
    private GameObject door;

    private void Awake()
    {
        Instance = this;
    }

    public void checkCompletion()
    {
        for (int i = 0; i < switches.Count; i++) {
            if (!switches[i]) return;
        }
        AudioManager.Instance.Play("Open"); Invoke("disableDoor", 0.35f);
        foreach (GameObject plate in plates)
        {
            if (plate.GetComponent<BoxCollider2D>() != null)
                plate.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            else
                plate.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void enableAgain()
    {
        CameraShake.ShakeOnce(0.08f, 0.5f);
        door.GetComponent<BoxCollider2D>().enabled = true;
        door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
    }

    private void disableDoor()
    {
        FindObjectOfType<DisablePull>().stopTimer();
        CameraShake.ShakeOnce(0.15f, 1.15f); door.GetComponent<BoxCollider2D>().enabled = false; door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
    }
}
