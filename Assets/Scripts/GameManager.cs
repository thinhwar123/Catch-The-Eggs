using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public int score;
    public float currentTime;
    public float delaySpawnTime;
    public GameObject whiteEgg;
    public GameObject yellowEgg;

    public TextMeshProUGUI textScore;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (currentTime <= 0)
        {
            SpawnEggs();
            currentTime += delaySpawnTime;
        }
        currentTime -= Time.deltaTime;
    }
    public void SpawnEggs()
    {
        int randomEgg = Random.Range(0, 10);
        Vector3 randomPosition = new Vector3(Random.Range(-2, 2), 6, 0);
        if (randomEgg < 8)
        {
            Instantiate(whiteEgg, randomPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(yellowEgg, randomPosition, Quaternion.identity);
        }
    }
    public void AddScore(int value)
    {
        score += value;
        textScore.text = $"Score : {score}";
    }
}
