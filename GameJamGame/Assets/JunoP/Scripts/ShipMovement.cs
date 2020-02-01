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
    }
}
