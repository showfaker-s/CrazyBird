using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;

    private bool gameStarted = false;

    public PipelineManager pipelineManager;

    public GameObject BeginPanel;
    public GameObject GamePanel;
    public GameObject OverPanel;
    public GameObject PausePanel;

    public Player player;

    private int score;
    public Text curScore;
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
        instance = this;

        BeginPanel.SetActive(true);
        Status = E_Game_Status.Begin;


        player._rigidbody2D.velocity = Vector2.zero;

        player.OnDeath += Player_OnDeath;
        player.OnScore = OnPlayerScore;


    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }


    void UpdateUI()
    {
        BeginPanel.SetActive(Status == E_Game_Status.Begin);
        GamePanel.SetActive(Status == E_Game_Status.Game);
        OverPanel.SetActive(Status == E_Game_Status.Over);
    }
    public void OnClickStartGame()
    {
        gameStarted = true;
        Status = E_Game_Status.Game;
        score = 0;
        player.fly();
        pipelineManager.StartRun();
    }
    public void ReStart()
    {
        Status = E_Game_Status.Begin;

    }
    public void OnPauseGame()
    {

    }
    private void Player_OnDeath()
    {
        Status = E_Game_Status.Over;
        //停止管道生成
        pipelineManager.StopRun();

        gameStarted = false;

        totalScore.text = this.score.ToString();
    }

    private void OnPlayerScore(int score)
    {
        Score += score;
    }
}
