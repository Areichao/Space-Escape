using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Audio;

public class DialogueManager : MonoBehaviour
{
    public GameObject canvas;
    public Image dialogueBox;
    public TMP_Text text;
    public Sprite[] characters;
    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        AudioManager.Instance.StopAllButSong();
        if (sentences.Count == 0) { endDialogue(); return; }
        string sentence = sentences.Dequeue();
        if (sentence[0] == '1') { dialogueBox.sprite = characters[0]; AudioManager.Instance.Play("Voice1"); }
        else { dialogueBox.sprite = characters[1]; AudioManager.Instance.Play("Voice2"); }
        string s = "";
        for(int i = 1; i < sentence.Length; i++)
        {
            s += sentence[i];
        }
        StopAllCoroutines();
        StartCoroutine(typeSentence(s));
    }

    private void endDialogue()
    {
        text.text = "";
        canvas.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator typeSentence(string n)
    {
        text.text = "";
        foreach(char letter in n.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSecondsRealtime(0.04f);
        }
        AudioManager.Instance.StopAllButSong();
    }
}
