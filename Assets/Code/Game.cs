using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game : MonoBehaviour
{
    public TMP_Text Score;
    public int score;
    public GuiPointerListener startButton;

    public GameObject startScreen;

    private void Awake()
    {
        startButton.OnClick += data => { EventBus.GetStarted(); };
    }

    private void OnEnable()
    {
        EventBus.startGame += Started;
        EventBus.finishGame += Finished;
        EventBus.catchPoint += CatchPoint;
    }

    private void OnDisable()
    {
        EventBus.startGame -= Started;
        EventBus.finishGame -= Finished;
        EventBus.catchPoint -= CatchPoint;
    }
    

    public void Started()
    {
        startScreen.SetActive(false);
    }

    public void Finished()
    {
        SceneManager.LoadScene(0);
    }

    public void CatchPoint()
    {
        score++;
        Score.text = score.ToString();
    }
}
