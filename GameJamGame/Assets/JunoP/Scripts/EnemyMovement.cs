using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;
    public GameObject enemyShoot;
    public GameObject enemy;
    public GameObject player;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > 2.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        else 
        {
            
        }

    }

    public void ShootPlayer()
    {
        GameObject projectile = Instantiate(enemyShoot, enemy.transform.position, Quaternion.identity);
        Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
        rb2d.velocity = (player.transform.position - transform.position).normalized;
        Destroy(projectile, 3.0f);
        canShoot = false;
    }
}
