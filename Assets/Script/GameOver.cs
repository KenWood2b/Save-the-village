using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public AudioSource SoundMain;
    public AudioClip ClickFX;

    private void Start()
    {
        SoundMain.Play();
    }

    public void ClickSound()
    {
        SoundMain.PlayOneShot(ClickFX);
    }
    public void PlayGame(int index)
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
