using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPopUp : MonoBehaviour
{
    public GameObject parent;
    public bool mystery;
    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player pScript))
        {
            parent.GetComponent<Animator>().Play("block_popUp");
            if (mystery) Instantiate(reward, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
        }
    }
}
