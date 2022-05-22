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

            // Plays the death animation
            parent.GetComponent<Animator>().SetBool("dead", true);
            // Destroys the rigidbody and boxcollider and then the whole gumba.
            Destroy(parent.GetComponent<Rigidbody2D>());
            Destroy(parent.GetComponent<BoxCollider2D>());
            Destroy(parent, 0.6f);
        }
    }
}
