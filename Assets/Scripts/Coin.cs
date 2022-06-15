using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            GameObject.Find("Canvas").GetComponent<UISystem>().AddPoints(100);
            Destroy(Instantiate(text,gameObject.transform),2f);
            Destroy(gameObject);
        }
    }
}
