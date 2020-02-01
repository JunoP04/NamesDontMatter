using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float speed = 5f;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(0, moveSpeed * Time.deltaTime, 0);
         dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
         Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
         transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
