using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleFinish : MonoBehaviour
{
    public UISystem ui;
    public Transform bottom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position= new Vector2(1000000,1000000);
        gameObject.GetComponent<Animator>().Play("fake_finish");
        StartCoroutine(Wait());
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.9f);
        ui.ShowReloadSceneUI();
    }
}
