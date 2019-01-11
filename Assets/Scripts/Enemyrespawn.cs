﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyrespawn : MonoBehaviour
{
    public bool Death;
    public float Timer;
    public float Cooldown;
    public GameObject Enemy;
    public string EnemyName;
    GameObject LastEnemy;
    // Use this for initialization
    void Start()
    {
        //If you want, add this line:
        Death = false;
        this.gameObject.name = EnemyName + "spawn point";
    }

    // Update is called once per frame
    void Update()
    {
        if (Death == true)
        {
            //If my enemy is death, a timer will start.
            Timer += Time.deltaTime;

        }
        //If the timer is bigger than cooldown.
        if (Timer >= Cooldown)
        {
            //It will create a new Enemy of the same class, at this position.
            Enemy.transform.position = transform.position;

            GameObject newObject = Instantiate(Enemy);
            newObject.name = EnemyName;
            newObject.GetComponent<MovingEnemy>().spawnpoint = this;

            //My enemy won't be dead anymore.
            Death = false;
            //Timer will restart.
            Timer = 0;
        }
    }
}