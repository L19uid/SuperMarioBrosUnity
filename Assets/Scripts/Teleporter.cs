using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject secondaryCam;

    public Transform teleportTo;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player pMovement))
        {
            if(Input.GetKey(KeyCode.S))
            {
                secondaryCam.SetActive(true);
                mainCam.SetActive(false);

                pMovement.transform.position = new Vector2(teleportTo.position.x, teleportTo.position.y);
            }
        }
    }
}
