using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Setting the speed and rigidbody of the player
    [SerializeField] float speed = 3f;
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource cam;
    [SerializeField] AudioClip crashSound;
 
    // Customization of the limits the player can't pass through
    [Header("Move Limits")]
    [SerializeField] float upLimit = -1.8f;
    [SerializeField] float leftLimit = -4.4f;
    [SerializeField] float downLimit = 1.8f;
    [SerializeField] float rightLimit = 4.4f;

    public bool playerCrashed;
    public float speedEnemy;
    public float lapCounter = 1f;

    private float crashCounter = 0f;

    private void Start()
    {
        //Freeze the rotation of the player
        rb.freezeRotation = true;
    }

    void Update() 
    {
        KeysAndMovement();
        // Call the function to not let the player cross the limits
        OutOfBoundsCheck();
        CrashCheck();
    }

    private void KeysAndMovement()
    {
        // Gets the Horizontal keys (<- and ->, A and D)
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Gets the Vertical keys (^ and v, W and S)
        float moveVertical = Input.GetAxis("Vertical");

        // Gives the direction the player will have based on the keys pressed
        Vector3 movement = new Vector3(-moveVertical, 0f, moveHorizontal);
        // Multiply the movement with the speed chosen 
        rb.velocity = movement * speed;
    }

    private void OutOfBoundsCheck() 
    {
        // Clamp both x and z axis of the player to the limits chosen
        Vector3 clampedPosition = new Vector3(
        Mathf.Clamp(transform.position.x, upLimit, downLimit),
        transform.position.y,
        Mathf.Clamp(transform.position.z, leftLimit, rightLimit)
    );
        transform.position = clampedPosition;
    }

    private void CrashCheck() 
    {
        if (playerCrashed)
        {
            crashCounter += Time.deltaTime;
            if (crashCounter >= 1)
            {
                playerCrashed = false;
                crashCounter = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) 
    { 
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            playerCrashed= true;
            cam.PlayOneShot(crashSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Lap"))
        {
            lapCounter++;
        }
    }
}
