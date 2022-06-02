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
    public GameObject floatText;
    public int rewardPoints;
    public Sprite changeSprite;
    public GameObject ui;

    private bool used;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player pScript))
        {
            GetComponent<Animator>().Play("block_PopUp");
            
            if(coin || msuhroom && !used)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().sprite = changeSprite;

                if (coin)
                {
                    Destroy(Instantiate(coinGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity),.4f);
                    StartCoroutine(WaitForText());
                }

                if (msuhroom) Instantiate(msuhroomGO, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity);
            }

            if (destroyable)
            {
                Destroy(Instantiate(blockBreakP, new Vector2(transform.position.x, transform.position.y + .5f), Quaternion.identity), .4f);
                Destroy(gameObject);
            }
        }
    }
    public IEnumerator WaitForText()
    {
        yield return new WaitForSeconds(.39f);
        Destroy(Instantiate(floatText, new Vector2(coinGO.transform.position.x, coinGO.transform.position.y), Quaternion.identity), .4f);
        floatText.transform.SetParent(ui.transform);
        ui.transform.GetComponent<UISystem>().AddPoints(100);
        floatText.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPoints.ToString();
        floatText.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 5;
    }
}
