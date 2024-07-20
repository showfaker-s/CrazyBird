using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2 : MonoSingleton<Game2>
{


    public PipelineManager pipelineManager;

    public int curLevelId = 1;

    public Player2 player2;


    private int score;
    private int totalScore;
    private int bestScore;
    
    
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UIManager.Instance.UpdateScore(score);
        }
    }

    private E_Game_Status status;
    public E_Game_Status Status
    {
        get { return status; }
        set
        {
            this.status = value;
            //status改变就更新UI
            UIManager.Instance.UpdateUI();
            DataManager();
        }
    }

    void Start()
    {
        this.Status = E_Game_Status.Begin;

        this.player2.OnDeath += Player_OnDeath;

    }
    public void Player_OnDeath(Unit target)
    {
        Status = E_Game_Status.Over;
        //停止管道生成
        pipelineManager.StopRun();
        UnitManager.Instance.Clear();
        LevelManager.Instance.level.StopRun();
        LevelManager.Instance.level.result = Level.LEVEL_RESULT.FAILD;

    }
    public void OnClickStartGame()
    {
        
        pipelineManager.StartRun();
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
    }

    public void ReStart()
    {
        /*        player2._rigidbodyBird.bodyType = RigidbodyType2D.Static;
                Status = E_Game_Status.Begin;
                pipelineManager.StartRun();
                player2.Init();*/
        SceneManager.LoadScene("Game2");
    }
    public void OnPauseGame()
    {

    }

    public void btnExit()
    {
        Application.Quit();
    }

    public void OnPlayerScore(int score)
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
    
    public void DataManager()
    {
        PlayerPrefs.SetInt("totalScore", Score);
        if (Score > bestScore)
        {
            bestScore = Score;
            PlayerPrefs.SetInt("bestScore", bestScore); // 保存最高分
        }
        PlayerPrefs.Save();
    }
}
