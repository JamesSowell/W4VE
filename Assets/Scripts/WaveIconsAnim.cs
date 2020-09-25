using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIconsAnim : MonoBehaviour
{
    public static Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Spawner.killCount == 5)
        {
            anim.SetBool("Wave2", true);
        } else if(Spawner.killCount == 15)
        {
            anim.SetBool("Wave3", true);
        } else if (Spawner.killCount == 40){
            anim.SetTrigger("Wave4");
        } else{
            anim.SetBool("Wave2", false);
            anim.SetBool("Wave3", false);
        }
    }
}
