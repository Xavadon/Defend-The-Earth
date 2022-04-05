using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Earth;
    Vector2 direction;
    Rigidbody2D rb;
    float speed = 2f;
    bool isGameOver;
    [SerializeField] GameObject DeathEffect;
    [SerializeField] GameObject DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectWithTag("Earth") == null)
        {
            isGameOver = true;
        }
        else
        {
            Earth = GameObject.FindGameObjectWithTag("Earth");
            direction = Earth.transform.position - transform.position;
            direction = direction.normalized;
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Earth") == null)
        {
            isGameOver = true;
        }
        if (isGameOver)
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                return;
            }
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            direction = Player.transform.position - transform.position;
            rb.AddForce(direction.normalized * Player.GetComponent<PlayerController>().speed / 30, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().DamagePlayer(10);
            DestroyEnemy();
}
        if (collision.tag == "Sputnik")
        {
            collision.GetComponent<SputnikController>().hitCounter += 1;
            DestroyEnemy();
        }
        if (collision.tag == "Earth")
        {
            collision.GetComponent<EarthController>().DamageEarth();
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        if (Random.Range(0,4) == 2)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddTurrel();
        }
        Destroy(gameObject);
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Instantiate(DeathSound, transform.position, Quaternion.identity);
    }
}
