 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject canvas;

    public void triggerDialogue()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerDialogue();
    }
}
