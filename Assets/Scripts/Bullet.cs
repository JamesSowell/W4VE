using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    public float distance;

    public LayerMask whatIsSolid;

    public GameObject bulletImpact;
    public GameObject EnemyDamageSFX;

    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().health--;
                Instantiate(EnemyDamageSFX, transform.position, Quaternion.identity);
            }
            DestroyBullet();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Instantiate(bulletImpact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
