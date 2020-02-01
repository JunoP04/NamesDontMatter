using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width + " " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of the ship
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(moveHorizontal * Time.deltaTime, moveVertical * Time.deltaTime, 0);

        //Gets screen size and coordinates
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0));
        float screenPosX = screenPos.x;
        float screenPosY = screenPos.y;

        //X axis boundaries
        if (transform.position.x <= 0)
        {
            transform.position = new Vector3(0, transform.position.y,0);
            print("Left bounds");
        }

        if (transform.position.x >= (screenPosX * 2 ))
        {
            transform.position = new Vector3(screenPosX * 2, transform.position.y,0);
            print("Right bounds");
        }

        //Y axis boundaries
        if (transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
            print("Bottom bounds");
        }

        if (transform.position.y >= (screenPosY * 2))
        {
            transform.position = new Vector3(transform.position.x, screenPosY * 2, 0);
            print("Top bounds");
        }
    }
}
