using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject playerProj;
    public GameObject player;
    public GameObject enemy;
    public float bulletSpeed = 10.0f;

    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //follow player until 2.5 units away from player and shoot every second while in range
        float distance = Vector2.Distance(transform.position, enemy.transform.position);

        if (distance < 4.0f && canShoot)
        {
            ShootEnemy();
            Invoke("Reload", 0.2f);
        }
    }

    //Shoots a projectile towards a player
    public void ShootEnemy()
    {
        GameObject projectile = Instantiate(playerProj, player.transform.position, Quaternion.identity);
        Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
        rb2d.velocity = ((enemy.transform.position - transform.position) * bulletSpeed);
        Destroy(projectile, 7.0f);
        canShoot = false;
    }

    //Function to invoke for reload time
    public void Reload()
    {
        canShoot = true;
    }
}
