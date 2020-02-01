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
        //follow player until 2.5 units away from player and shoot every second while in range
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > 2.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        else if(distance < 2.5 && canShoot)
        {
            ShootPlayer();
            Invoke("Reload", 1.0f);
        }

    }

    //Shoots a projectile towards a player
    public void ShootPlayer()
    {
        GameObject projectile = Instantiate(enemyShoot, enemy.transform.position, Quaternion.identity);
        Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
        rb2d.velocity = (player.transform.position - transform.position).normalized;
        Destroy(projectile, 7.0f);
        canShoot = false;
    }

    //Function to invoke for reload time
    public void Reload()
    {
        canShoot = true;
    }
}
