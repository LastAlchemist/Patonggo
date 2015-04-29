using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
    public bool isPause;
    bool  isMute, isRestart, isExit,reset;
    public GameObject pauseScene, pauseButton, spriteRestart, spriteExit, loadingPlane;
    tk2dSprite spriteResume, spriteRetry, spriteMainMenu, spriteMute, spriteYes, spriteNo;
    public bool backToMain;
    float countdownReset = 2.0f;

	void Start () 
    {
        backToMain = false;
        reset = false;
        spriteResume = GameObject.Find("Resume").GetComponent<tk2dSprite>() as tk2dSprite;
        spriteMute = GameObject.Find("Sound").GetComponent<tk2dSprite>() as tk2dSprite;
        spriteRetry = GameObject.Find("Retry").GetComponent<tk2dSprite>() as tk2dSprite;
        spriteMainMenu = GameObject.Find("MainMenu").GetComponent<tk2dSprite>() as tk2dSprite;

        spriteYes = GameObject.Find("YesButton").GetComponent<tk2dSprite>() as tk2dSprite;
        spriteNo = GameObject.Find("NoButton").GetComponent<tk2dSprite>() as tk2dSprite;

        spriteExit.GetComponent<Renderer>().enabled = false;
        spriteRestart.GetComponent<Renderer>().enabled = false;
        spriteYes.GetComponent<Renderer>().enabled = false;
        spriteNo.GetComponent<Renderer>().enabled = false;

        if (AudioListener.volume == 0)
        {
            spriteMute.spriteId = spriteMute.GetSpriteIdByName("Mute");
            isMute = true;
        }
	}
	void Update () 
    {
        if (reset == true)
        {
            countdownReset -= Time.deltaTime;
        }
        Coundown();

        backingToMain();
	}
    private void resumeGame()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 1;
        }
        pauseScene.transform.position = new Vector3(0, -11.5f, -7);
        pauseButton.GetComponent<Renderer>().enabled = true;
        Time.timeScale = 1;
    }
    private void pauseGame()
    {
        if(AudioListener.volume > 0)
        {
            AudioListener.volume = 0.3f;
        }
        pauseScene.transform.position = new Vector3(0, 0, -7);
        pauseButton.GetComponent<Renderer>().enabled = false;
        Time.timeScale = 0;
    }
    private void muteSound()
    {
        if (isMute == false)
        {
            spriteMute.spriteId = spriteMute.GetSpriteIdByName("Mute");
            isMute = true;
            AudioListener.volume = 0;
        }
        else
        {
            spriteMute.spriteId = spriteMute.GetSpriteIdByName("OptionButton");
            isMute = false;
            AudioListener.volume = 1;
        }

    }
    private void restart()
    {
        if(isRestart == false)
        {
            isRestart = true;
            spriteResume.GetComponent<Renderer>().enabled = false;
            spriteRetry.GetComponent<Renderer>().enabled = false;
            spriteMainMenu.GetComponent<Renderer>().enabled = false;
            spriteMute.GetComponent<Renderer>().enabled = false;

            spriteRestart.GetComponent<Renderer>().enabled = true;
            spriteYes.GetComponent<Renderer>().enabled = true;
            spriteNo.GetComponent<Renderer>().enabled = true;
        }
    }
    private void exit()
    {
        if (isExit == false)
        {
            isExit = true;
            spriteResume.GetComponent<Renderer>().enabled = false;
            spriteRetry.GetComponent<Renderer>().enabled = false;
            spriteMainMenu.GetComponent<Renderer>().enabled = false;
            spriteMute.GetComponent<Renderer>().enabled = false;

            spriteExit.GetComponent<Renderer>().enabled = true;
            spriteYes.GetComponent<Renderer>().enabled = true;
            spriteNo.GetComponent<Renderer>().enabled = true;
        }
    }
    private void ConfirmYes()
    {
        if(isRestart == true)
        {
            if (AudioListener.volume > 0)
            {
                AudioListener.volume = 1;
            }
            Application.LoadLevel(Application.loadedLevel);
            Time.timeScale = 1;
        }
        if(isExit == true)
        {
            Time.timeScale = 1;
            iTween.MoveTo(loadingPlane, new Vector3(0, 0, -8), 0.3f);
            if (AudioListener.volume > 0)
            {
                AudioListener.volume = 1;
            }
            pauseScene.transform.position = new Vector3(0, -11.5f, -7);
            spriteResume.GetComponent<Renderer>().enabled = false;
            spriteRetry.GetComponent<Renderer>().enabled = false;
            spriteMainMenu.GetComponent<Renderer>().enabled = false;
            spriteMute.GetComponent<Renderer>().enabled = false;
            reset = true;
            backToMain = true;
        }
    }
    private void ConfirmNo()
    {
        if (isRestart == true)
        {
            isRestart = false;
            spriteResume.GetComponent<Renderer>().enabled = true;
            spriteRetry.GetComponent<Renderer>().enabled = true;
            spriteMainMenu.GetComponent<Renderer>().enabled = true;
            spriteMute.GetComponent<Renderer>().enabled = true;

            spriteRestart.GetComponent<Renderer>().enabled = false;
            spriteYes.GetComponent<Renderer>().enabled = false;
            spriteNo.GetComponent<Renderer>().enabled = false;
        }

        if(isExit == true)
        {
            isExit = false;
            spriteResume.GetComponent<Renderer>().enabled = true;
            spriteRetry.GetComponent<Renderer>().enabled = true;
            spriteMainMenu.GetComponent<Renderer>().enabled = true;
            spriteMute.GetComponent<Renderer>().enabled = true;

            spriteExit.GetComponent<Renderer>().enabled = false;
            spriteYes.GetComponent<Renderer>().enabled = false;
            spriteNo.GetComponent<Renderer>().enabled = false;
        }
    }
    private void OverRestart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    private void OverMainmenu()
    {
        iTween.MoveTo(loadingPlane, new Vector3(0, 0, -8), 0.3f);
        reset = true;
    }

    void Coundown()
    {
       if (countdownReset <= 0)
       {
            Application.LoadLevel("StartGame");
       }
        
    }

    public bool backingToMain()
    {
        return backToMain;
    }
}
