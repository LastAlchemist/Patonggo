using UnityEngine;
using System.Collections;

public class StartSceneMain : MonoBehaviour 
{

    public GameObject creditPlane, splashPlane, loadindPlane;
    bool isMute;
    tk2dSprite spirteMute;
    int highScore;
    TextMesh finalScore;
    float delay = 1.5f;
    bool start = false;
	void Start () 
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        spirteMute = GameObject.Find("Sound").GetComponent<tk2dSprite>() as tk2dSprite;
        finalScore = GameObject.Find("HightScore").GetComponent<TextMesh>() as TextMesh;
	}

	void Update () 
    {
        finalScore.text = highScore.ToString();
        if (start == true)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                //loadindPlane.transform.position = new Vector3(0, 0, -8);
                delay = 1.5f;
                Application.LoadLevel("Play");
            }
        }
	}

    private void startGame()
    {
        start = true;
        iTween.MoveTo(loadindPlane, new Vector3(0, 0, -8), 0.5f);
    }
    private void Credit()
    {
        iTween.MoveTo(creditPlane, new Vector3(0, -0.5f, -5), 0.5f);
    }
    private void BackToStart()
    {
        iTween.MoveTo(creditPlane, new Vector3(-8, -0.5f, -5), 0.5f);
    }
    private void muteSound()
    {
        if (isMute == false)
        {
            spirteMute.spriteId = spirteMute.GetSpriteIdByName("Mute");
            isMute = true;
            AudioListener.volume = 0;
        }
        else
        {
            spirteMute.spriteId = spirteMute.GetSpriteIdByName("OptionButton");
            isMute = false;
            AudioListener.volume = 1;
        }
       
    }
}
