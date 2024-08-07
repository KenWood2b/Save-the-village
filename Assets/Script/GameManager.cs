using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;
    public Image RaidTimerImg;
    public Image PeasantTimerImg;
    public Image FootmanTimerImg;

    public Button peasantButton;
    public Button footmanButton;
    public Text resourcesText;
    

    public int peasantCount;
    public int footmanCount;
    public int wheatCount;
    public int waveCount;

    public int wheatPerPeasant;
    public int wheatToFootman;

    public int peasantCost;
    public int footmanCost;

    public float peasantCreateTime;
    public float footmanCreateTime;
    public float raidMaxTime;
    public int raidIncrease;
    public int nextRaid;
    public GameObject ScreenPauseGame;
    

    private float peasantTimer = -2;
    private float footmanTimer = -2;
    private float raidTimer;
    private bool pause;

    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    public AudioSource audio5;
    public AudioClip ClickFX;
    public AudioClip ClickFX2;

    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;
        audio1.Play();
    }


    void Update()
    {
        UpdateText();
        Condition();
        RaidTimer();
        HarvesTimer();
        EatTimer();
        peasTimer();
        footTimer();
        ButtonExit();
    }
    public void RaidTimer()
    {
        raidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = raidTimer / raidMaxTime;

        if (raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            footmanCount -= nextRaid;
            nextRaid += raidIncrease;
            waveCount += 1;
            audio4.Play();

        }
    }


    public void HarvesTimer()
    {
        if (HarvestTimer.Tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
            audio5.Play();
        }
    }


    public void EatTimer()
    {
        if (EatingTimer.Tick)
        {
            wheatCount -= footmanCount * wheatToFootman;
        }
    }

    public void peasTimer()
    {
        
        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            PeasantTimerImg.fillAmount = peasantTimer / peasantCreateTime;
            audio2.Play();
        }

        else if (peasantTimer > -1)
        {
            PeasantTimerImg.fillAmount = 0;
            peasantButton.interactable = true;
            peasantCount += 1;
            peasantTimer = -2;
        }

        else if (wheatCount < peasantCost)
        {
            peasantButton.interactable = false;
        }

        else if (wheatCount > peasantCost)
        {
            peasantButton.interactable = true;
        }

    }


    public void footTimer()
    {

        if (footmanTimer > 0)
        {
            footmanTimer -= Time.deltaTime;
            FootmanTimerImg.fillAmount = footmanTimer / footmanCreateTime;
            audio3.Play();
        }

        else if (footmanTimer > -1)
        {
            FootmanTimerImg.fillAmount = 0;
            footmanButton.interactable = true;
            footmanCount += 1;
            footmanTimer = -2;
        }

        else if (wheatCount < footmanCost)
        {
            footmanButton.interactable = false;
        }

        else if (wheatCount > footmanCost)
        {
            footmanButton.interactable = true;
        }


    }


    public void ButtonExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Condition()
    {
        if (waveCount >= 10)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(3);
        }

        else if (footmanCount < 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(2);
        }
    }

    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;

    }

    public void CreateFootman()
    {
        wheatCount -= footmanCost;
        footmanTimer = footmanCreateTime;
        footmanButton.interactable = false;
    }

    public void UpdateText()
    {
        resourcesText.text = wheatCount + "\n" + peasantCount + "\n" + footmanCount + "\n\n" + waveCount;
        
    }

    public void MeniGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickSoud()
    {
        audio1.PlayOneShot(ClickFX);
    }

    public void ClickSound2()
    {
        audio1.PlayOneShot(ClickFX2);
    }

    public void PauseGame()
    {
        if (pause)
        {
            Time.timeScale = 1;
            ScreenPauseGame.SetActive(false);
            footmanButton.interactable = true;
            peasantButton.interactable = true;
        }

        else
        {
            Time.timeScale = 0;
            ScreenPauseGame.SetActive(true);
            footmanButton.interactable = false;
            peasantButton.interactable = false;
            audio2.Pause();
            audio3.Pause();
            audio4.Pause();
            audio5.Pause();
        }

        pause = !pause;
    }

}
