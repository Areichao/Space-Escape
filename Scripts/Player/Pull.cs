using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 0.35f, PlayerMovement.Instance.getMovement(), 1f);
            foreach (RaycastHit2D thing in hit)
            {
                if (thing.collider.CompareTag("Box") || thing.collider.CompareTag("Crystal"))
                {
                    PlayerMovement.Instance.thingToPull = thing.transform;
                    return;
                }
            }

            //RaycastHit2D ray = Physics2D.Raycast(transform.position, PlayerMovement.Instance.getMovement());
            
            //if (ray.collider.CompareTag("Box")) ray.transform.parent = gameObject.transform;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            PlayerMovement.Instance.thingToPull = null;
        }
    }
}
