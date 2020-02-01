﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisUpgrades : MonoBehaviour
{
    public GameObject player;
    private GameObject debrisItem;

    // Start is called before the first frame update
    void Start()
    {
        debrisItem = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        CollectDebris();
    }

    public void CollectDebris()
    {
        float distance = Vector2.Distance(debrisItem.transform.position, player.transform.position);

        if (distance <= 3.0f)
        {
            debrisItem.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2.0f * Time.deltaTime);
            if (distance <= 0)
            {
                StickToShip(debrisItem);
            }
        }
    }

    void StickToShip(GameObject debris)
    {

        debris.transform.parent = player.transform;
        
    }
}