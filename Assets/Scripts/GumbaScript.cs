using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbaScript : MonoBehaviour
{
    private Rigidbody2D _rb;

    public Vector2 castPos;

    public LayerMask mask;

    public bool lineCast;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lineCast = Physics2D.Linecast(gameObject.transform.position, new Vector2(gameObject.transform.position.x + castPos.x, gameObject.transform.position.y + castPos.y), 0, (int)mask);
        if(lineCast)
        {
            gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector2.right * 100);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position,new Vector2(gameObject.transform.position.x + castPos.x, gameObject.transform.position.y + castPos.y));
    }
}
