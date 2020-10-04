using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{
    public float speed = 5;

    public float detectionRadius = 15;

    public GameObject enemyDeathEffect;

    Transform player;

    bool fly = false;

    bool captured = false;

    public bool good = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        if (captured)
            return;


        
            

        if (fly)
            transform.position += -transform.right * speed * Time.deltaTime;
        else
            fly = Vector3.Distance(transform.position, player.position) < detectionRadius;
    }

    public void Capture()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;

        transform.tag = "CapturedArrow";
        gameObject.layer = 10;

        captured = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void Reverse()
    {
        captured = false;
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject go = Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
            Destroy(go, 3);

            if (other.GetComponent<Destroyable>() != null)
                Destroy(other.gameObject);

            Destroy(gameObject);
        }

        
    }
}
