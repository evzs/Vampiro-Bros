using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Game Objects
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject HUD;

    // Buttons
    public Button startButton;
    public Button startMenuQuit;
    public Button resumeButton;
    public Button pauseMenuBackButton;
    public Button pauseMenuQuitButton;
    public Button tryAgainButton;
    public Button gameOverBackButton;
    public Button gameOverQuitButton;

    // Text
    public TextMeshProUGUI crystalCountText;

    public HealthManager hm;
    public int crystalsCount = 0;
    private bool isPaused = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
        startMenu.SetActive(true);
        HUD.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    private void Start()
    {
        // Button Listeners
        startButton.onClick.AddListener(StartGame);
        startMenuQuit.onClick.AddListener(QuitGame);
        resumeButton.onClick.AddListener(ResumeGame);
        pauseMenuBackButton.onClick.AddListener(BackToMenu);
        pauseMenuQuitButton.onClick.AddListener(QuitGame);
        tryAgainButton.onClick.AddListener(TryAgain);
        gameOverBackButton.onClick.AddListener(BackToMenu);
        gameOverQuitButton.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // Game Control Methods
    public void StartGame()
    {
        ResumeGame();
        ResetGameState();
        startMenu.SetActive(false);
        HUD.SetActive(true);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Game Started!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        StartGame();
    }

    public void BackToMenu()
    {
        ResetGameState();
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        HUD.SetActive(false);
    }

    // Game State Methods
    private void ResetGameState()
    {
        foreach (var enemy in FindObjectsOfType<EnemyMovement>())
        {
            enemy.gameObject.SetActive(true);
            enemy.ResetEnemy();
        }

        foreach (var block in FindObjectsOfType<BlockController>())
        {
            block.ResetBlock();
        }

        PlayerState playerState = FindObjectOfType<PlayerState>();
        if (playerState != null)
        {
            playerState.ResetPosition();
        }

        if (hm != null)
        {
            hm.ResetHealth();
        }

        crystalsCount = 0;
        UpdateCrystalCountUI();
    }

    public void AddCrystal()
    {
        crystalsCount++;
        UpdateCrystalCountUI();
        Debug.Log("Crystal collected! Total: " + crystalsCount);
    }

    public int GetCrystalCount()
    {
        return crystalsCount;
    }

    void UpdateCrystalCountUI()
    {
        int crystalCount = Instance.GetCrystalCount();
        crystalCountText.text = "x " + crystalCount.ToString();
    }

    // Pause Methods
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Debug.Log("Game Resumed");
    }
}