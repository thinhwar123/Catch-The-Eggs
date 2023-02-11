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
    [SerializeField] private GameObject basket;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private GameObject endPanel;

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
        basket.SetActive(true);
        ingamePanel.SetActive(true);
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        gameState = GameState.Play;

        score = 0;
        textScore.text = $"Score : {score}";
    }
    public void EndGame()
    {
        basket.SetActive(false);
        ingamePanel.SetActive(true);
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        gameState = GameState.End;
    }
    public void Retry()
    {
        basket.SetActive(false);
        ingamePanel.SetActive(false);
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        gameState = GameState.Start;
    }
    private void OnPlayState()
    {
        if (currentTime <= 0)
        {
            SpawnEgg();
            currentTime += Random.Range(0, delaySpawnTime);
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