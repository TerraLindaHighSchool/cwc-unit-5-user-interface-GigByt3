using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public GameObject restartButton;
    public GameObject ScoreUI;
    public GameObject TitleUI;
    private float spawnRate = 0.6f;
    private int score;
    private bool gameOn;
    // Start is called before the first frame update

    public void StartGame(int diff)
    {
        ScoreUI.SetActive(true);
        TitleUI.SetActive(false);
        restartButton.SetActive(false);
        gameOver.gameObject.SetActive(false);
        spawnRate *= diff;
        gameOn = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score: " + score;
        Debug.Log("CLicked/Started!");
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;

    }

    public void EndGame()
    {
        gameOver.gameObject.SetActive(true);
        gameOn = false;
        restartButton.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while(gameOn)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
