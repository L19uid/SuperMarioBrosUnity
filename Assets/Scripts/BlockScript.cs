using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public bool destroyable;
    public GameObject blockBreakP;
    public bool msuhroom;
    public GameObject msuhroomGO;
    public bool coin;
    public GameObject coinGO;
    private int points;
    public GameObject floatText;
    public int rewardPoints;
    public Sprite changeSprite;
    public GameObject ui;
    public int usesCount;
    private int usedCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player pScript))
        {
            GetComponent<Animator>().Play("block_PopUp");
            
            if(usedCount < usesCount && coin || msuhroom )
            {
                usedCount++;
                if(usedCount >= usesCount)
                    gameObject.GetComponentInChildren<SpriteRenderer>().sprite = changeSprite;

                if (coin)
                {
                    Destroy(Instantiate(coinGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity),.5f);
                    StartCoroutine(WaitForText());
                }

                if (msuhroom) 
                    Instantiate(msuhroomGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
                if (destroyable)
                {
                    Destroy(Instantiate(blockBreakP, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity), .4f);
                    Destroy(gameObject);
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
