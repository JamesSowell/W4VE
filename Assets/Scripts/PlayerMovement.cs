using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public int health;

    private Rigidbody2D rb;

    
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Vector2 moveDashVelocity;

    public float offSet;

    public GameObject bullet;
    public Transform gunPoint;

    public GameObject deathEffect;
    public GameObject damageEffect;
    public GameObject pickUpEffect;
    public GameObject dashEffect;


    private Animator anim;

    public Text healthDisplay;

    public Image[] hearts;

    public Sprite threeHeart, twoHeart, oneHeart;
    public GameObject SwishSFX, StarSFX, ExplosionSFX, SubSFX, DashSFX, PlayerDamageSFX, ShootSFX;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Spawner.isPause == false)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            moveDashVelocity = moveInput.normalized * dashSpeed;

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offSet);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, gunPoint.position, gunPoint.rotation);
                Instantiate(ShootSFX, gunPoint.position, gunPoint.rotation);
            }
        }

        if(health == 1)
        {
            anim.SetBool("Three Health", true);
            
        }

        if(health == 2)
        {
            anim.SetBool("Two Health", true);
            anim.SetBool("Three Health", false);
            anim.SetBool("Full Health", false);
        }

        if(health >= 3)
        {
            health = 3;
            anim.SetBool("Two Health", false);
            anim.SetBool("Full Health", true);
        }

        healthDisplay.text = "HEALTH: ";

        for (int i = 0; i < hearts.Length; i++)
        {
            if (health == 3)
            {
                hearts[i].sprite = threeHeart;
            }
            else if (health == 2)
            {
                hearts[i].sprite = twoHeart;
            }
            else hearts[i].sprite = oneHeart;

            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void FixedUpdate()
    {
        if (Spawner.isPause == false)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                Instantiate(DashSFX, transform.position, Quaternion.identity);
                rb.MovePosition(rb.position + moveDashVelocity * Time.fixedDeltaTime);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(PlayerDamageSFX, transform.position, Quaternion.identity);
        Instantiate(damageEffect, transform.position, Quaternion.identity);
        PPEffects.playerDamage = true;
        if (health <= 0)
        {
            Spawner.playerIsDead = true;
            Instantiate( ExplosionSFX, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickup"))
        {
            health++;
            PPEffects.playerPickup = true;
            Instantiate(StarSFX, transform.position, Quaternion.identity);
            Instantiate(SubSFX, transform.position, Quaternion.identity);
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

}