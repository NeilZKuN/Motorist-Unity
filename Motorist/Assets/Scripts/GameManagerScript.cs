using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float maxKmhCounter = 200;
    [SerializeField] GameObject youWinScreen;

    public PlayerMovement player;
    public Text kmhCounter;
    public Text timeCounter;
    public Text lapCounter;
    public Text timeFinal;

    public float enemySpeed = 1f;
    public float enemySpeedLimit = 15f;

    private GameObject playerObject;
    private float time;
    private float seconds;
    private float timeTotal = 0f;
    
    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = playerObject.GetComponent<PlayerMovement>();

        GameSpeed();
        CountSeconds();
        ShowTexts();

        if (Input.GetKey(KeyCode.R)) {SceneManager.LoadScene(SceneManager.GetActiveScene().name);}
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowTexts() 
    {
        kmhCounter.text = ((int)((enemySpeed * maxKmhCounter) / enemySpeedLimit)).ToString();

        if (player.lapCounter < 4){lapCounter.text = player.lapCounter.ToString();}
        timeCounter.text = seconds.ToString();

        if (player.lapCounter == 4)
        {
            if (timeTotal == 0)
            {
                timeTotal = seconds;
                timeFinal.text = timeTotal.ToString();
            }
            youWinScreen.SetActive(true);
        }
    }

    private void CountSeconds()
    {
        if (time >= 1)
        {
            seconds++;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void GameSpeed() 
    {
        enemySpeed += Time.deltaTime;
        if (player.playerCrashed == true) { enemySpeed = 0; }
        enemySpeed = Mathf.Clamp(enemySpeed, 1f, enemySpeedLimit);
    }
}
