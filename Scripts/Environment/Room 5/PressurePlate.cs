using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int num;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            SwitchManager.Instance.switches[num] = true;
            SwitchManager.Instance.checkCompletion();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            SwitchManager.Instance.switches[num] = false;
        }
    }
}
