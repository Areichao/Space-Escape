using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Image image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        StartCoroutine(fadeLeave());
    }

    IEnumerator fadeLeave()
    {
        for (float i = 0; i < 1; i += 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            image.color = new Vector4(0, 0, 0, i);
        }
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
