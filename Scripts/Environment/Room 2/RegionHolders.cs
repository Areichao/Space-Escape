using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionHolders : MonoBehaviour
{
    public int targetNum;
    public int regionNum;

    private int currentNum = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            currentNum++;
            if (currentNum == targetNum) GetComponentInParent<RegionManager>().complete[regionNum] = true;
            else GetComponentInParent<RegionManager>().complete[regionNum] = false;
            GetComponentInParent<RegionManager>().checkComplete();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            currentNum--;
            if (currentNum == targetNum) GetComponentInParent<RegionManager>().complete[regionNum] = true;
            else GetComponentInParent<RegionManager>().complete[regionNum] = false;
            GetComponentInParent<RegionManager>().checkComplete();
        }
    }
}
