using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public GameObject[] boxes;
    public List<Vector3> positions;
    public Image bg;
    public GameObject[] interactables;
    [SerializeField] private GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(fade());
        Time.timeScale = 0;
    }

    IEnumerator fade()
    {
        for(float i = 0; i < 1; i+= 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            bg.color = new Vector4(0, 0, 0, i);
        }

        PlayerMovement.Instance.canMove = false;
        PlayerMovement.Instance.getRigidBody().velocity = Vector2.zero;
        int j = 0;
        foreach (GameObject box in boxes)
        {
            box.transform.localPosition = positions[j++];
        }
        PlayerMovement.Instance.getTransform().position = positions[boxes.Length];
        for (int i = 0; i < SwitchManager.Instance.switches.Count; i++) SwitchManager.Instance.switches[i] = false;
        door.GetComponent<BoxCollider2D>().enabled = true; door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
        for (float i = 1; i > -0.1; i -= 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            bg.color = new Vector4(0, 0, 0, i);
        }

        foreach (GameObject thing in interactables) if (thing.GetComponent<BoxCollider2D>() != null) thing.GetComponent<BoxCollider2D>().enabled = true; else thing.GetComponent<CircleCollider2D>().enabled = true;

        PlayerMovement.Instance.canMove = true;

        Time.timeScale = 1;
        StopCoroutine(fade());
    }

}
