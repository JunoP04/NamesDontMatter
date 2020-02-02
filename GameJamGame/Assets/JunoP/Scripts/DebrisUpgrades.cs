using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisUpgrades : MonoBehaviour
{
    public GameObject player;
    private GameObject debrisItem;
    public Transform shipAnchor;
    public Transform debrisPoint;
    public Vector3 debrisStickPoint;
    public bool isDebrisOrbiting = false;

    public int debrisCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        debrisItem = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {

        shipAnchor.Rotate(0, 0, .5f);
        CollectDebris();
        Vector3[] originalPos = new Vector3[debrisCount];

        if (Input.GetKey(KeyCode.Mouse1))
        {
            RepairShip();
            
        }
        else
        {
            isDebrisOrbiting = false;
            
        }

    }

    public void CollectDebris()
    {
        float distance = Vector2.Distance(debrisItem.transform.position, player.transform.position);

        if (distance <= 3.0f && debrisItem.transform.parent != player.transform && Input.GetKey(KeyCode.Mouse1) == false)
        {
            debrisItem.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2.0f * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StickToShip();
        }
        else if (col.gameObject.tag == "Debris" && col.transform.parent == player.transform)
        {
            StickToShip();
        }
    }

    void StickToShip()
    {
        debrisStickPoint = debrisItem.transform.position;
        debrisItem.transform.parent = player.transform;
        debrisCount = debrisCount + 1;
        Debug.Log(debrisCount);
    }

    public void RepairShip()
    {

        //debrisItem.transform.parent = orbitPos.transform;
        if (debrisItem.transform.parent == player.transform)
        {
            //Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();
            //rb2d.velocity = new Vector2(0f, 0f);
            isDebrisOrbiting = true;
            debrisItem.transform.parent = shipAnchor.transform;
            float radius = 1f;
            for (int i = 0; i < 4; i++)
            {
                float angle = i * Mathf.PI * 2f / 4;
                Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius,0) ;
                debrisItem.transform.position = debrisPoint.position;
            }
        }


    }
}
