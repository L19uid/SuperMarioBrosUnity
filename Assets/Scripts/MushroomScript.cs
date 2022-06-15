using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public float moveSpeed;
    public bool movingRight;

    public Transform sideCastPos;

    public Vector2 castSize;
    public Vector2 killCastSize;

    public LayerMask mask;
    public LayerMask playerMask;

    public bool sc = false;

    private bool canMove = true;
    public GameObject reward;

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
        if (!canMove) return;

        CheckWhereWalk();
        SwitchSides();
    }

    public void CheckWhereWalk()
    {
        sc = Physics2D.OverlapBox(sideCastPos.position, castSize, 0, (int)mask);

        if (sc)
        {
            movingRight = !movingRight;
        }
    }

    public void SwitchSides()
    {
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

    public void CheckPlayer()
    {
        Collider2D hit = Physics2D.OverlapBox(gameObject.transform.position, killCastSize, 0, (int)playerMask);

        if (hit != null)
        {
            GameObject.Find("Canvas").GetComponent<UISystem>().AddPoints(1000);
            Destroy(Instantiate(reward, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity), .5f);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position, killCastSize);
    }
}
