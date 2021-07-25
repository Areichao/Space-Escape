using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisablePull : MonoBehaviour
{
    public GameObject timerText;
    public TMP_Text time;
    private float timer = 90;
    private bool startTimer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //start timer
            timerText.SetActive(true);
            startTimer = true;
            collision.GetComponent<Pull>().enabled = false;
        }
    }

    private void Update()
    {
        if (startTimer)
        {
            CameraShake.ShakeOnce(0.01f, 0.1f);
            timer -= Time.deltaTime;
            if (timer > 60)
                time.text = "" + (int)(timer / 60) + " : " + (timer < 70 ? "0" + (int)(timer - 60) : "" + (int)(timer - 60));
            else
                time.text = "0 : " + (timer < 10 ? "0" : "") + (int)timer;

            if (timer < 0) { timerText.SetActive(false); startTimer = false; GameObject.Find("late").SetActive(true); GameObject.Find("on time").SetActive(false); }
        }
    }

    public void stopTimer()
    {
        startTimer = false;
        timerText.SetActive(false);
    }

    public void resetTimer()
    {
        timer = 90;
    }
}
