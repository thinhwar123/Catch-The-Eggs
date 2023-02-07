using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;   
    [SerializeField] private int score;
    [SerializeField] private float currentTime;
    [SerializeField] private float delaySpawnTime;
    [SerializeField] private GameObject whiteEgg;
    [SerializeField] private GameObject yellowEgg;
    [SerializeField] private GameObject blackEgg;

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private GameObject m_Basket;
    [SerializeField] private GameObject m_ScorePanel;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject retryButton;
    private void Start()
    {

    }
    private void Update()
    {
        if (gameState == GameState.Play)
        {
            OnPlayState();
        }
    }
    public void StartGame()
    {
        m_Basket.SetActive(true);
        m_ScorePanel.SetActive(true);
        startButton.SetActive(false);
        retryButton.SetActive(false);
        gameState = GameState.Play;

        score = 0;
        textScore.text = $"Score : {score}";
    }
    public void EndGame()
    {
        m_Basket.SetActive(false);
        m_ScorePanel.SetActive(true);
        startButton.SetActive(false);
        retryButton.SetActive(true);
        gameState = GameState.End;
    }
    public void Retry()
    {
        m_Basket.SetActive(false);
        m_ScorePanel.SetActive(false);
        startButton.SetActive(true);
        retryButton.SetActive(false);
        gameState = GameState.Start;
    }
    private void OnPlayState()
    {
        if (currentTime <= 0)
        {
            SpawnEgg();
            currentTime += delaySpawnTime;
        }
        currentTime -= Time.deltaTime;
    }
    private void SpawnEgg()
    {
        int randomEgg = Random.Range(0, 10);
        Vector3 randomPosition = new Vector3(Random.Range(-2, 2), 6, 0);
        switch (randomEgg)
        {
            case < 6:
                Instantiate(whiteEgg, randomPosition, Quaternion.identity);
                break;
            case < 8:
                Instantiate(yellowEgg, randomPosition, Quaternion.identity);
                break;
            default:
                Instantiate(blackEgg, randomPosition, Quaternion.identity);
                break;
        }
    }
    public void AddScore(int value)
    {
        score += value;
        textScore.text = $"Score : {score}";
    }
}
public enum GameState
{
    Start,
    Play,
    End,
}