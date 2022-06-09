using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public UISystem ui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            ui = GameObject.Find("Canvas").GetComponent<UISystem>();
            if (player.pStatus == Player.PlayerStatus.normal) ui.ShowReloadSceneUI();
            player.ChangeHealth(-1);
        }
    }
}
