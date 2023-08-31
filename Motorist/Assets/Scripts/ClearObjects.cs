using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEnemies : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") ||
            collision.gameObject.tag.Equals("Line") ||
            collision.gameObject.tag.Equals("Lap"))
        {
            Destroy(collision.gameObject);
        }
    }
}
