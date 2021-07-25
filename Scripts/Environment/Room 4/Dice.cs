using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int initValue;

    public int multValue;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal"))
        {
            AudioManager.Instance.Play("Ping1");
            multValue = collision.GetComponent<Crystal>().value;
            BalanceManager.Instance.checkCompletion();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal"))
        {
            multValue = 0;
            BalanceManager.Instance.checkCompletion();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal")) multValue = collision.GetComponent<Crystal>().value;
        
    }


    public int getCurrValue()
    {
        return initValue * (multValue > 0 ? multValue : 1);
    }
}
