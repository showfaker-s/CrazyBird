using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    public UnitManager unitManager;
    public PipelineManager pipelineManager;

    public Player2 player2;

    public Slider sliderHP;

    
    /*    public GameObject BeginPanel;
        public GameObject GamePanel;
        public GameObject OverPanel;
        public GameObject PausePanel;


        private int score;
        public Text curScore;
        public int Score
        {
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
        }*/
    void Start()
    {
        player2.Ondeath += Player_OnDeath;
        Screen.SetResolution(1280, 720, true);
        unitManager.StartRun();
        pipelineManager.StartRun();

        sliderHP.maxValue = player2.HP;
    }
    private void Update()
    {
        //player抛出事件，Game监听
        sliderHP.value = Mathf.Lerp(sliderHP.value, player2.HP,0.1f);
    }
    private void Player_OnDeath()
    {
        //Status = E_Game_Status.Over;
        //停止管道生成
        unitManager.StopRun();
        pipelineManager.StartRun();

        //totalScore.text = this.score.ToString();
    }
    /*
        void UpdateUI()
        {
            BeginPanel.SetActive(Status == E_Game_Status.Begin);
            GamePanel.SetActive(Status == E_Game_Status.Game);
            OverPanel.SetActive(Status == E_Game_Status.Over);
        }
        public void OnClickStartGame()
        {
            //player._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

            Status = E_Game_Status.Game;
            score = 0;
            //player.fly();
        }
        public void ReStart()
        {
            //player._rigidbody2D.bodyType = RigidbodyType2D.Static;
            Status = E_Game_Status.Begin;
            unitManager.Init();
            //pipelineManager.StartRun();
            //player.Init();

        }
        public void OnPauseGame()
        {

        }

        public void btnExit()
        {

            SceneManager.LoadScene("Game2");

        }


        private void OnPlayerScore(int score)
        {
            Score += score;
        }*/
}
