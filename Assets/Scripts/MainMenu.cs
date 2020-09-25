using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float seconds;

    public Animator aboutPanel;
    public Animator camTransitions, musicTransitions;
    public GameObject clickSFX, boomSFX;

    public void Play()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
        Instantiate(boomSFX, transform.position, Quaternion.identity);
        camTransitions.SetTrigger("Close");
        musicTransitions.SetTrigger("Fade Out");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("GamePlay");
    }

    public void AboutOpen()
    {
        Instantiate(clickSFX, transform.position, Quaternion.identity);
        aboutPanel.SetTrigger("Open");
    }

    public void AboutClose()
    {
        Instantiate(clickSFX, transform.position, Quaternion.identity);
        aboutPanel.SetTrigger("Close");
    }
}
