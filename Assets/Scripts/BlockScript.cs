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
    public bool multipleUses;
    public int usesCount;
    private int usedCount;

    private bool notUsed = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player pScript))
        {
            GetComponent<Animator>().Play("block_PopUp");
            
            if(coin || msuhroom && notUsed)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().sprite = changeSprite;
                if (multipleUses) 
                {
                    if (usedCount < usesCount) usedCount++;
                    else multipleUses = false;
                }
                else notUsed = false;

                if (coin)
                {
                    Destroy(Instantiate(coinGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity),.5f);
                    StartCoroutine(WaitForText());
                }

                if (msuhroom) Instantiate(msuhroomGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
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
