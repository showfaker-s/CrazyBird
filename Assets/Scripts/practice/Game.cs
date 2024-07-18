using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game : MonoBehaviour
{

    public PipelineManager pipelineManager;

    public GameObject BeginPanel;
    public GameObject GamePanel;
    public GameObject OverPanel;
    public GameObject PausePanel;

    public Player player;

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
    }
    void Start()
    {
        Screen.SetResolution(540, 960, false);

        BeginPanel.SetActive(true);
        Status = E_Game_Status.Begin;


        player._rigidbody2D.velocity = Vector2.zero;

        player.OnDeath += Player_OnDeath;
        player.OnScore = OnPlayerScore;


    }

    /*    public bool IsGameStarted()
        {
            return gameStarted;
        }*/


    void UpdateUI()
    {
        BeginPanel.SetActive(Status == E_Game_Status.Begin);
        GamePanel.SetActive(Status == E_Game_Status.Game);
        OverPanel.SetActive(Status == E_Game_Status.Over);
    }
    public void OnClickStartGame()
    {
        player._rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        Status = E_Game_Status.Game;
        score = 0;
        //player.fly();
        pipelineManager.StartRun();
    }
    public void ReStart()
    {
        //player._rigidbody2D.bodyType = RigidbodyType2D.Static;
        Status = E_Game_Status.Begin;
        pipelineManager.Init();
        //pipelineManager.StartRun();
        player.Init();

    }
    public void OnPauseGame()
    {

    }

    public void btnExit()
    {

        SceneManager.LoadScene("Game2");

    }
    private void Player_OnDeath()
    {
        Status = E_Game_Status.Over;
        //停止管道生成
        pipelineManager.StopRun();


        totalScore.text = this.score.ToString();
    }

    private void OnPlayerScore(int score)
    {
        Score += score;
    }
}
