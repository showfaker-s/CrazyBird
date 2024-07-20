using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Slider sliderhp;
    public Text uiLevelName;
    public Text uiLvStaTex;


    public GameObject BeginPanel;
    public GameObject GamePanel;
    public GameObject OverPanel;
    public GameObject PausePanel;
    public GameObject uiLevelStart;
    public GameObject uiLevelEnd;

    public Text curScore;
    public Text totalScore;
    public Text bestScore;



    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        BeginPanel.SetActive(true);
        sliderhp.maxValue = Game2.Instance.player2.hp;
        bestScore.text = PlayerPrefs.GetInt("bestScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //playerÅ×³öÊÂ¼þ£¬Game¼àÌý
        sliderhp.value = Mathf.Lerp(sliderhp.value, Game2.Instance.player2.hp, 0.1f);
        UpdateUI();
    }

    public void UpdateUI()
    {
        BeginPanel.SetActive(Game2.Instance.Status == E_Game_Status.Begin);
        GamePanel.SetActive(Game2.Instance.Status == E_Game_Status.Game);
        OverPanel.SetActive(Game2.Instance.Status == E_Game_Status.Over);
    }
    public void UpdateScore(int score)
    {
        curScore.text = score.ToString();
        totalScore.text = curScore.text.ToString();
    }
    public void ShowLevelStart(string name)
    {
        this.uiLvStaTex.text = name;
        this.uiLevelName.text = name;
        uiLevelStart.SetActive(true);
    }
}
