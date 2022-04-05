using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurrelController : MonoBehaviour
{
    public GameObject enemy;
    
    void FixedUpdate()
    {
        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyController>().DestroyEnemy();
        }
    }
}
