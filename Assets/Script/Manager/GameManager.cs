using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool GameIsOver;

    [SerializeField] private GameObject gameOverUI;         // canva lose
    [SerializeField] private GameObject completeLevelUI;    // canva win

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameIsOver = false;
        EventManager.instance.OnGameLosed.AddListener(IsAlive);
        EventManager.instance.OnGameWin.AddListener(WinLevel);
    }

    private void IsAlive()
    {
        if (GameIsOver)
            return;

        if (Stage.Instance.health <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
