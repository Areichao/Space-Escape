using System.Collections;
using System.Collections.Generic;
using Audio;    
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; set; }
    public List<int> path = new List<int>();
    public List<int> playerPath;
    [SerializeField]
    private List<GameObject> grid;
    [SerializeField]
    private GameObject startingPoint;
    [SerializeField]
    private GameObject door;


    private int gridNum;

    private void Start()
    {
        Instance = this;
    }

    public void updateList(int num) {

        playerPath.Add(num);

        for(int i = 0; i < playerPath.Count; i++) {
            if (playerPath[i] != path[i]) {
                gridNum = playerPath[i];
                PlayerMovement.Instance.canMove = false;
                StartCoroutine(flash());
                return;
            }
        }
        if (playerPath.Count == path.Count) roomComplete();
        grid[playerPath[playerPath.Count - 1] - 1].GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 0.5f);
    }

    private void roomComplete()
    {
        foreach (GameObject cell in grid) cell.GetComponent<BoxCollider2D>().enabled = false;
        AudioManager.Instance.Play("Open"); Invoke("disableDoor", 0.35f);
    }

    private void resetRoom()
    {
        playerPath.Clear();
        foreach (GameObject box in grid) { if (box.GetComponent<ObjectNumber>().stayActive) box.GetComponent<SpriteRenderer>().color = Color.white; else box.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0.5f); box.GetComponent<BoxCollider2D>().enabled = true; }
        PlayerMovement.Instance.getTransform().position = startingPoint.transform.position;
        PlayerMovement.Instance.canMove = true;
    }

    private void disableDoor()
    {
        CameraShake.ShakeOnce(0.15f, 1.15f); door.GetComponent<BoxCollider2D>().enabled = false; door.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
    }

    IEnumerator flash() {
        AudioManager.Instance.Play("Ping2");
        for(int i = 0; i < 4; i++) {
            yield return new WaitForSeconds(0.2f);
            grid[gridNum - 1].GetComponent<SpriteRenderer>().color = new Vector4(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.2f);
            grid[gridNum - 1].GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0.5f);
        }
        yield return new WaitForSeconds(0.35f);
        resetRoom();
        StopCoroutine(flash());
    }
}
