using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public UISystem ui;
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            ui.points += 100;
            Destroy(Instantiate(text,gameObject.transform),2f);
            Destroy(gameObject);
        }
    }
}
