using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public bool msuhroom;
    public GameObject msuhroomGO;
    public bool coin;
    public GameObject coinGO;
    public bool breakable;
    public GameObject breakableGO;
    private int points;
    public GameObject floatText;
    public int rewardPoints;
    public Sprite changeSprite;
    public GameObject ui;
    public int usesCount;
    public int usedCount = 0;
    public bool used = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player pScript))
        {
            GetComponent<Animator>().Play("block_PopUp");

            if (coin || msuhroom )
            {
                if (usedCount >= usesCount) used = true;

                if(usedCount+1 >= usesCount) gameObject.GetComponent<SpriteRenderer>().sprite = changeSprite;
                usedCount++;

                if (!used)
                {
                    if (breakable)
                    {
                        Destroy(Instantiate(breakableGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity), .4f);
                        Destroy(gameObject);
                    }

                    if (coin)
                    {
                        GameObject.Find("Canvas").GetComponent<UISystem>().AddPoints(100);
                        Destroy(Instantiate(coinGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity),.5f);
                        StartCoroutine(WaitForText());
                    }

                    if (msuhroom)
                    {
                        Instantiate(msuhroomGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
                    }
                }
            }
        }
    }
    public IEnumerator WaitForText()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(Instantiate(floatText, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2), Quaternion.identity), .4f);
        ui.transform.GetComponent<UISystem>().AddPoints(points);
    }
}
