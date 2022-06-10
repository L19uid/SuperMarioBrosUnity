using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    public GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player pMovement))
        {
            // Makes the player jump.
            pMovement.Jump(2000);

            parent.GetComponent<Animator>().Play("gumba_death");

            // Destroys the parent.
            Destroy(parent, 0.4f);
        }
    }
}
