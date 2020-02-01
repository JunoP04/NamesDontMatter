using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of the ship
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(moveHorizontal * Time.deltaTime, moveVertical * Time.deltaTime, 0);

        // X axis
        if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector2(-10.0f, transform.position.y);
        }
        else if (transform.position.x >= 10.0f)
        {
            transform.position = new Vector2(10.0f, transform.position.y);
        }

        // Y axis
        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }
        else if (transform.position.y >= 6.5f)
        {
            transform.position = new Vector2(transform.position.x, 6.5f);
        }
    }
}
