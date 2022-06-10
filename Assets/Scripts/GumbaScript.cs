using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbaScript : MonoBehaviour
{
     public float moveSpeed;
     public bool movingRight;

    public Transform cornerCastPos;
    public Transform sideCastPos;

    public Vector2 castSize;

    public LayerMask mask;

    public bool cc = false;
    public bool sc = false;

    // Update is called once per frame
    void Update()
     {
        cc = Physics2D.OverlapBox(cornerCastPos.position, castSize, 0, (int)mask);
        sc = Physics2D.OverlapBox(sideCastPos.position, castSize, 0, (int)mask);

        if (cc && sc)
        {
            movingRight = !movingRight;
        }
        else if (cc == false)
        {
            movingRight = !movingRight;
        }
        

        if (movingRight)
        {
            gameObject.transform.localScale = new Vector2(1, 1);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
        }
        else
        {
            gameObject.transform.localScale = new Vector2(-1, 1);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
        }
    }
    private void OnDrawGizmos()
    {
    }
}
