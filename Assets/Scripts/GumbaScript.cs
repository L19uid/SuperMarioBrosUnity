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
    public Vector2 killCastSize;

    public LayerMask mask;
    public LayerMask playerMask;

    public bool cc = false;
    public bool gc = false;

    public GameObject reward;

    private bool canMove = true;

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
        cc = Physics2D.OverlapBox(cornerCastPos.position, castSize, 0, (int)mask);
        gc = Physics2D.OverlapBox(sideCastPos.position, castSize, 0, (int)mask);

        if (cc && gc)
        {
            movingRight = !movingRight;
        }
        else if (cc == false)
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

    public void Die()
    {
        GameObject.Find("Canvas").GetComponent<UISystem>().AddPoints(200);
        Debug.Log(200);
        Destroy(Instantiate(reward, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity), .5f);
        gameObject.GetComponent<Animator>().Play("gumba_death");
        Destroy(gameObject, .5f);
    }

    public void CheckPlayer()
    {
        Collider2D hit = Physics2D.OverlapBox(gameObject.transform.position, killCastSize, 0, (int)playerMask);

        if (hit != null)
        {
            GameObject.Find("Canvas").GetComponent<UISystem>().ShowReloadSceneUI();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position, killCastSize);
    }
}
