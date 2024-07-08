using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject BeginPanel;
    public GameObject GamePanel;
    public GameObject OverPanel;

    public Player player;

    private int score;
    private Text curScore;
    public int Score {
        get { return score; }
        set
        {
            score = value;
            curScore.text = this.score.ToString();
        }
    }

    public Text totalScore;
    public Text bestScore;
    private E_Game_Status status;
    /*    private E_Game_Status Status { get => status; set => status = value; }*/
    private E_Game_Status Status
    {
        get { return status; }
        set
        {
            this.status = value;
            //status改变就更新UI
            this.UpdateUI();
        }
    }
    enum E_Game_Status
    {
        Begin,
        Game,
        Over
    }
    void Start()
    {
        Status = E_Game_Status.Begin;
        player.OnDeath += GameOver;
        player.OnScore = OnPlayerScore;
    }


    void Update()
    {
        
    }


    void UpdateUI()
    {
        BeginPanel.SetActive(Status == E_Game_Status.Begin);
        GamePanel.SetActive(Status == E_Game_Status.Game);
        OverPanel.SetActive(Status == E_Game_Status.Over);
    }
    public void OnClickStartGame()
    {
        Status = E_Game_Status.Game;
        score = 0;
        player.fly();
        
    }
    private void GameOver()
    {
        Status = E_Game_Status.Over;

    }

    private void OnPlayerScore(int score)
    {
        Score += score;
    }
}
