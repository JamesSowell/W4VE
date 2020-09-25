using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPEffects : MonoBehaviour
{
    public static bool playerPickup;
    public static bool playerDamage;
    public static bool enemyDamage;

    public Animator playerPickupEffect;
    public Animator playerDamageEffect;

    private void Start()
    {
        playerDamage = false;
        playerPickup = false;
    }

    private void Update()
    {
        if (playerPickup){
            playerPickupEffect.SetTrigger("Player Health");
            playerPickup = false;
        }

        if (playerDamage)
        {
            playerDamageEffect.SetTrigger("Player Damage");
            playerDamage = false;
        }

        if (enemyDamage)
        {
            playerDamageEffect.SetTrigger("Enemy Damage");
            enemyDamage = false;
        }
    }
}
