using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapSpawner : MonoBehaviour
{
    [SerializeField] GameObject lapLine;
    [SerializeField] float lapSpawnSpeed = 100;

    public GameObject gameManager;

    private float speed;
    private float speedTotal = 0f;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    private void Update()
    {
        speed = gameManager.GetComponent<GameManagerScript>().enemySpeed;
        SpawnLap();
    }

    private void SpawnLap() 
    {
        if (speedTotal < lapSpawnSpeed)
        {
            speedTotal += speed * Time.deltaTime;
            Debug.Log(speedTotal);
        }
        else
        {
            Instantiate(lapLine, transform.position, transform.rotation);
            speedTotal = 0f;
        }
    }
}
