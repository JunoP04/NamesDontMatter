using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 8.5f;
    public float speed = 5f;
    public float acceleration = 1f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width + " " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigid2d = player.GetComponent<Rigidbody2D>();
        //Movement of the ship
        if (Input.GetKey(KeyCode.Mouse1))
        {
            rigid2d.velocity = (transform.up * speed);
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    

        //Gets screen size and coordinates
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0));
        float screenPosX = screenPos.x;
        float screenPosY = screenPos.y;

        //X axis boundaries
        if (transform.position.x <= +1.5f )
        {
            transform.position = new Vector3(1.5f, transform.position.y,0);
            print("Left bounds");
        }

        if (transform.position.x >= (screenPosX -1.5f))
        {
            transform.position = new Vector3(screenPosX-1.5f, transform.position.y,0);
            print("Right bounds");
        }

        //Y axis boundaries
        if (transform.position.y <= +1.5f)
        {
            transform.position = new Vector3(transform.position.x, 1.5f, 0);
            print("Bottom bounds");
        }

        if (transform.position.y >= (screenPosY -1.5f))
        {
            transform.position = new Vector3(transform.position.x, screenPosY -1.5f, 0);
            print("Top bounds");
        }
    }

    private IEnumerator Deaccelerate()
    {
        for (float ft = 3.0f; ft >= 0; ft -= 0.1f)
        {
            moveSpeed = ft;
        }
        yield return null;
    }

}
