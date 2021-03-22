using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
       Instance = this;
    }

    #endregion
    [Header("Sphere Spawn")]
    public int maxNumberOfSpheres;
    public Vector2 planeSize;
    public int totalSphereNumbers;
    public GameObject sphere;

    [Header("Others")]
    public Text score;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    public GameObject scoreText;
    public Player playerScript;
    public Enemy enemyScript;
    public ChainSphere sphereScript;

    private void Start()
    {
        SphereSpawn();
    }

    private void Update()
    {
        score.text = "More "+ totalSphereNumbers + " to go!! ".ToString();
    }

    void SphereSpawn()
    {
        while (totalSphereNumbers < maxNumberOfSpheres)
        {
            Instantiate(sphere, new Vector3(Random.Range(-(planeSize.x), (planeSize.x)), 1.5f, Random.Range(-(planeSize.y), (planeSize.y))), Quaternion.identity);
            totalSphereNumbers++;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        Time.timeScale = 0;
        playerScript.enabled = false;
        sphereScript.enabled = false;
        enemyScript.enabled = false;
    }

    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        scoreText.SetActive(false);
        Time.timeScale = 0;
        playerScript.enabled = false;
        sphereScript.enabled = false;
        enemyScript.enabled = false;
    }

    public void GameOverMenu()
    {
        playerScript.enabled = true;
        sphereScript.enabled = true;
        enemyScript.enabled = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
