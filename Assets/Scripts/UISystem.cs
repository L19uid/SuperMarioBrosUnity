using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UISystem : MonoBehaviour
{
    public TextMeshProUGUI pointsTMP;
    public TextMeshProUGUI lifesTMP;
    public TextMeshProUGUI worldTMP;
    public TextMeshProUGUI timeTMP;
    public GameObject reloadUI;

    public int points;
    public int lifes;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowReloadSceneUI();
        }
    }
    void Start()
    {
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        timeTMP.text = Mathf.RoundToInt(400 - Time.time).ToString();
    }

    public void AddPoints(int i)
    {
        points += i;
        lifesTMP.text = Mathf.RoundToInt(lifes).ToString();
        if (points == 0) pointsTMP.text = "00000" + Mathf.RoundToInt(points).ToString();
        else if (points <= 99) pointsTMP.text = "000" + Mathf.RoundToInt(points).ToString();
        else if (points <= 999) pointsTMP.text = "00" + Mathf.RoundToInt(points).ToString();
        else if (points <= 9999) pointsTMP.text = "0" + Mathf.RoundToInt(points).ToString();
    }
    public void ShowReloadSceneUI()
    {
        Time.timeScale = 0;
        reloadUI.SetActive(true);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
