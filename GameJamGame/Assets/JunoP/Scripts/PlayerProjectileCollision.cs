using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("You hit the Enemy");
            Destroy(gameObject);
        }
    }
}
