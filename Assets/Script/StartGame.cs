using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
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
    public void Play(int index)
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
