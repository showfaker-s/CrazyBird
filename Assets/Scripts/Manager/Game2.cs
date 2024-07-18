using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2 : MonoSingleton<Game2>
{


    public PipelineManager pipelineManager;

    public int curLevelId = 1;

    public Player2 player2;

    public Slider sliderhp;
    public Text uiLevelName;

    public GameObject BeginPanel;
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
    }
    void Start()
    {

        player2.OnDeath += Player_OnDeath;
        Screen.SetResolution(1280, 720, true);
        Status = E_Game_Status.Begin;
        pipelineManager.StartRun();

        sliderhp.maxValue = player2.hp;

        //Level level1 = Resources.Load<Level>("Level1");
    }
    private void Update()
    {
        
        //player抛出事件，Game监听
        sliderhp.value = Mathf.Lerp(sliderhp.value, player2.hp, 0.1f);
        UpdateUI();
    }
    public void Player_OnDeath()
    {
        Status = E_Game_Status.Over;
        //停止管道生成
        pipelineManager.StartRun();
        UnitManager.Instance.Stop();
        LevelManager.Instance.level.StopRun();
        LevelManager.Instance.level.result = Level.LEVEL_RESULT.FAILD;

    }
    void UpdateUI()
    {
        BeginPanel.SetActive(Status == E_Game_Status.Begin);
        GamePanel.SetActive(Status == E_Game_Status.Game);
        OverPanel.SetActive(Status == E_Game_Status.Over);
    }
    public void OnClickStartGame()
    {

        LoadLevel();
        player2._rigidbodyBird.bodyType = RigidbodyType2D.Kinematic;
        Status = E_Game_Status.Game;
        score = 0;
        player2.Fly();
        LevelManager.Instance.level.OnLevelEnd = OnLevelEnd;
    }

    private void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(this.curLevelId);
        uiLevelName.text = string.Format("LEVEL {0} {1}", LevelManager.Instance.level.LevelID, LevelManager.Instance.level.Name);
        

    }

    public void ReStart()
    {
        player2._rigidbodyBird.bodyType = RigidbodyType2D.Static;
        Status = E_Game_Status.Begin;
        pipelineManager.StartRun();
        player2.Init();

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
    }

    void OnLevelEnd(Level.LEVEL_RESULT result)
    {
        if(result == Level.LEVEL_RESULT.SUCCESS)
        {

            this.curLevelId++;
            Debug.Log(string.Format("curLv: {0}", curLevelId));
            this.LoadLevel();
        }
        else
        {
            this.Status = E_Game_Status.Over;

        }
        //pipelineManager.StartRun();
    }
}
