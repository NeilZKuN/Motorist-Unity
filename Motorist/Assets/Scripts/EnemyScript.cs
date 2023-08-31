using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float upCarStart;
    [SerializeField] float backCarSpeedMultiplier = 0.7f;

    private float speed;
    private float speedMax;
    private float speedCheck;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager");
        rb.freezeRotation = true;
    }

    private void Update()
    {
        speed = gameManager.GetComponent<GameManagerScript>().enemySpeed;
        speedMax = gameManager.GetComponent<GameManagerScript>().enemySpeedLimit;

        FrontAndBackCar();

        rb.velocity = Vector3.back * Mathf.Clamp(speedCheck, upCarStart, speedMax);
    }

    private void FrontAndBackCar() 
    { 
        if (upCarStart == -5)
        { 
            speedCheck = upCarStart + speed;
        }
        else if (upCarStart == 5) { speedCheck = speed * backCarSpeedMultiplier; }
        else { speedCheck = speed; }
    }
}
