using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{

    public Animator musicFade;
    public Animator camTransition;
    public float seconds;
    public GameObject clickSFX;

    public void Restart()
    {
        StartCoroutine(Restarting());
    }


    IEnumerator Restarting()
    {
        Instantiate(clickSFX, transform.position, Quaternion.identity);
        musicFade.SetTrigger("Fade Out");
        camTransition.SetTrigger("Fade Out");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        Instantiate(clickSFX, transform.position, Quaternion.identity);
        musicFade.SetTrigger("Fade Out");
        camTransition.SetTrigger("Fade Out");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Main Menu");
    }
}
