using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbaScript : MonoBehaviour
{
     public float moveSpeed;
     public bool moovingRight;

     public Transform wallCheck;
     public float wallCheckRadius;
     public LayerMask whatIsWall;
     private bool hittedWall;

     public Transform edgeCheck;
     private bool notOnEdge;

     public Transform groundCheck;
     private bool grounded;

    public Vector2 castPos;
    public Vector2 castPosTwo;

    public LayerMask mask;

    public bool lineCast;
    public bool lineCastTwo;

    // Update is called once per frame
    void Update()
     {
         hittedWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
         notOnEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
         grounded = Physics2D.OverlapCircle(groundCheck.position, wallCheckRadius, whatIsWall);

        lineCast = Physics2D.Linecast(gameObject.transform.position, new Vector2(gameObject.transform.position.x + castPos.x, gameObject.transform.position.y + castPos.y), 0, (int)mask);
        lineCastTwo = Physics2D.Linecast(gameObject.transform.position, new Vector2(gameObject.transform.position.x + castPosTwo.x, gameObject.transform.position.y + castPosTwo.y), 0, (int)mask);
        if (lineCast && !lineCastTwo)
        {
             transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
     }
    //public Rigidbody2D _rb;
    //
    //public Vector2 castPos;
    //public Vector2 castPosTwo;
    //
    //public LayerMask mask;
    //public LayerMask maskTwo;
    //
    //public bool lineCast;
    //public bool lineCastTwo;
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    _rb = gameObject.GetComponent<Rigidbody2D>();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    lineCast = Physics2D.Linecast(gameObject.transform.position, new Vector2(gameObject.transform.position.x + castPos.x, gameObject.transform.position.y + castPos.y), 0, (int)mask);
    //    if(lineCast)
    //    {
    //        gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
    //    }
    //
    //    lineCastTwo = Physics2D.Linecast(gameObject.transform.position, new Vector2(gameObject.transform.position.x + castPosTwo.x, gameObject.transform.position.y + castPosTwo.y), 0, (int)maskTwo);
    //    if (lineCastTwo)
    //    {
    //        gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
    //    }
    //}
    //
    //private void FixedUpdate()
    //{
    //    GetComponent<Rigidbody2D>().velocity = new Vector2(2, GetComponent<Rigidbody2D>().velocity.y);
    //}
    //
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position,new Vector2(gameObject.transform.position.x + castPos.x, gameObject.transform.position.y + castPos.y));
        Gizmos.DrawLine(gameObject.transform.position, new Vector2(gameObject.transform.position.x + castPosTwo.x, gameObject.transform.position.y + castPosTwo.y));

        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
        Gizmos.DrawWireSphere(groundCheck.position, wallCheckRadius);
        Gizmos.DrawWireSphere(edgeCheck.position, wallCheckRadius);
    }
}
