using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    public static BalanceManager Instance { get; set; }
    public List<Dice> left;
    public List<Dice> right;
    public TMP_Text leftText;
    public TMP_Text rightText;
    [SerializeField]
    private GameObject door;

    private void Awake()
    {
        Instance = this;
    }

    public void checkCompletion()
    {
        int leftVal = 0, rightVal = 0;
        for(int i = 0; i < left.Count; i++)
        {
            leftVal += left[i].getCurrValue();
        }
        for(int i = 0; i < right.Count; i++)
        {
            rightVal += right[i].getCurrValue();
        }

        leftText.text = leftVal.ToString();
        rightText.text = rightVal.ToString();

        if(leftVal == rightVal)
        {
            AudioManager.Instance.Play("Open"); Invoke("disableDoor", 0.35f);
        }
        else
        {
            if (!door.GetComponent<BoxCollider2D>().enabled)
            {
                AudioManager.Instance.Play("Close"); Invoke("enableAgain", 0.35f);
            }
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
        CameraShake.ShakeOnce(0.15f, 1.15f); door.GetComponent<BoxCollider2D>().enabled = false; door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
    }
}
