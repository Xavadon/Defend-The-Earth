using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SputnikController : MonoBehaviour
{
    public int hitCounter = 0;
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] GameObject DeathSound;
    [SerializeField] GameObject DeathEffect;
    SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (hitCounter == 1)
        {
            spriterenderer.sprite = sprite1;
        }
        if (hitCounter == 2)
        {
            spriterenderer.sprite = sprite2;
        }
        if (hitCounter == 3)
        {
            Destroy(gameObject);
            Instantiate(DeathSound, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }
    }
}
