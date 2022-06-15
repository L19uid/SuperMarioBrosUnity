using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public UISystem ui;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ui.ShowReloadSceneUI();
    }
}
