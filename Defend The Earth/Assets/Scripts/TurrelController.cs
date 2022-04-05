using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelController : MonoBehaviour
{
    GameObject[] enemy;
    GameObject closset;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSound;

    Vector2 target;
    [SerializeField] float distance;
    float curDistance;

    GameObject nearest;
    bool isReloading;


    GameObject FindClosestEnemy()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - transform.position;
            curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closset = go;
            }
        }
        return closset;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        isReloading = false;
    }
    void Update()
    {
        nearest = FindClosestEnemy();
        if (nearest == null)
            return;
        target = nearest.transform.position - transform.position;
        float angle = Mathf.Atan2(target.x, target.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        if (!isReloading)
        {
            Instantiate(bulletSound, transform.position, Quaternion.identity);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletTurrelController>().enemy = closset;
            StartCoroutine(Reload());
        }
    }
}
