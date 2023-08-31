using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] float minRange = -1.9f;
    [SerializeField] float maxRange = 0f;

    [SerializeField] float minTime = 1f;
    [SerializeField] float maxTime = 2f;
    
    private float time = 0;

    public float speed;
    public float speedMax;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    private void Update()
    {
        speed = gameManager.GetComponent<GameManagerScript>().enemySpeed;
        speedMax = gameManager.GetComponent<GameManagerScript>().enemySpeedLimit;
        SpawnEnemy();
    }

    private void SpawnEnemy() 
    {
        if (time >= Random.Range(minTime / (speed / speedMax), maxTime) / (speed / speedMax))
        {
            Instantiate(enemy, transform.position + new Vector3(Random.Range(minRange, maxRange), 0, 0), transform.rotation);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
