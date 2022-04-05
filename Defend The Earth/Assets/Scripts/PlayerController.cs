using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int hp = 100;
    public float speed = 18;

    int turrelAdded;
    int turrelNumber;

    [SerializeField] Animator animator;
    [SerializeField] Camera cam;
    [SerializeField] GameObject turrelPrefab;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletSpawnPoint;

    [SerializeField] GameObject ShootSound;
    [SerializeField] GameObject HurtSound;

    [SerializeField] Text PlayerUI;

    Vector2 direction;
    Vector2 difference;
    public float fireDelay = 0.3f;
    float lastFire;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = moveInput.normalized;

        difference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference = new Vector2(difference.x, difference.y);
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90f);

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > lastFire + fireDelay )
        {
            Instantiate(ShootSound, transform.position, Quaternion.identity);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(difference.normalized * speed * 20 * Time.fixedDeltaTime, ForceMode2D.Impulse);
            lastFire = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (turrelNumber > 0 )
            {
                Instantiate(turrelPrefab, transform.position, transform.rotation);
                turrelNumber--;
            }
        }
        UpdatePlayerUI();
    }
    void UpdatePlayerUI()
    {
        int earthHp;
        if (GameObject.FindGameObjectWithTag("Earth") == null)
        {
            earthHp = 0;
        }
        else
        {
            earthHp = GameObject.FindGameObjectWithTag("Earth").GetComponent<EarthController>().hp;
        }
        PlayerUI.text = "Earth HP: " + earthHp + "\r\nPlayer HP: " + hp + "\r\nTurretNumber: " + turrelNumber;
    }
    void FixedUpdate()
    {
        rb.AddForce(direction * speed * 0.7f, ForceMode2D.Force);
    }
    public void AddTurrel()
    {
        if (turrelAdded < 3)
        {
            turrelAdded++;
            turrelNumber++;
        }
    }
    public void DamagePlayer(int damage) 
    {
        Instantiate(HurtSound, transform.position, Quaternion.identity);
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameController.PlayerDead();
        }
    }
}
