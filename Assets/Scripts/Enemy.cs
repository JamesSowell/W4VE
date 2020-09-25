using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 3;
    public int damage;

    public float speed;
    private Transform target;

    private Animator anim;

    public GameObject deathEffect;
    public GameObject DeathSFX;

    private float attackTime;

    public float timeBtwAttacks;

    public float attackSpeed;

    public float stoppingDistance;

    private void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        speed = 3;
    }

    void Update()
    {
        if(health == 2)
        {
            anim.SetTrigger("Hit01");
        }
        if(health == 1)
        {
            anim.SetTrigger("Hit02");
        }
        if(health <= 0)
        {
            DestroyEnemy();
        }


        if(target != null)
        {
             if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
             {
                 transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
             }
             else
             {
                 if(Time.time >= attackTime)
                 {
                     StartCoroutine(Attack());
                     attackTime = Time.time + timeBtwAttacks;
                 }
             }
        }
        else
        {
            EndGameDestroyAllEnemies();
        }

        if(Spawner.killCount >= 25 && Spawner.killCount < 80)
        {
           // Debug.Log("speed up1");
            speed = 4;
        } else if(Spawner.killCount >= 80)
        {
            //Debug.Log("speed up2");
            speed = 5;
        }

        if (Spawner.wonGame)
        {
            DestroyEnemy();
        }
    }

    

    IEnumerator Attack()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        float percent = 0;
        while(percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }

    void DestroyEnemy()
    {
        Spawner.killCount++;
        PPEffects.enemyDamage = true;
        Instantiate(DeathSFX, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void EndGameDestroyAllEnemies()
    {
        PPEffects.enemyDamage = true;
        Instantiate(DeathSFX, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
