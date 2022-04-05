using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    public int hp = 100;
    [SerializeField] GameObject DeathEffect;
    [SerializeField] GameObject DeathSound;
    [SerializeField] GameObject[] Sputnik;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageEarth()
    {
        hp -= 10;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(DeathSound, transform.position, Quaternion.identity);
        }
    }
}
