using UnityEngine;
using System.Collections;

public class TheBox : MonoBehaviour 
{
	public GameObject boxLeft,boxRight,mainSprite;
    float distance;
	Animator anim;
	bool staying,slidingLeft,slidingRight,spliting,splitBack,life;
    public AudioSource slideSound, splitSound, backSplitSound;

    GameObject obstract;
	RandomApae obScript;

    GameObject mainPause;
    Main mainScript;

    float time = 5.0f;
    public bool starting;

    int highScore = 0;

	void Start () 
	{
        obstract = GameObject.Find("Main");
        obScript = obstract.GetComponent<RandomApae>();

        mainPause = GameObject.Find("Main");
        mainScript = mainPause.GetComponent<Main>();

        starting = false;
		slidingLeft = false;
		slidingRight = false;
		spliting = false;
        splitBack = false;
		anim = mainSprite.GetComponent<Animator> ();
        boxLeft.GetComponent<Renderer>().enabled = false;
        boxRight.GetComponent<Renderer>().enabled = false;
	}
	void FixedUpdate()
	{
		anim.SetBool ("slidingLeft",slidingLeft);
		anim.SetBool ("slidingRight",slidingRight);
        anim.SetBool("spliting", spliting);
        anim.SetBool ("splitBack", splitBack);
	}
    public void isAlive(bool living)
    {
        life = living;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
       //PlayerPrefs.SetInt("MyScore", obScript.score);
      if( obScript.score > highScore)
      {
          PlayerPrefs.SetInt("HighScore", obScript.score);
      }

       // PlayerPrefs.SetInt("HighScore", );
    }
	void Update () 
	{
        if (starting == false)
        {
            time -= Time.deltaTime;
            if (time < 3)
            {
                starting = true;
                time = 0;
            }
        }
        distance = Mathf.Abs (boxLeft.transform.position.x - boxRight.transform.position.x);
        if (starting == true && life == true)
        {
            if (Input.touches.Length == 1)
            {
                if (Input.GetTouch(0).position.x > (Screen.width / 2))
                {
                    if (mainSprite.transform.position.x <= 0)
                    {
                        slideSound.Play(0);
                    }
                       
                    iTween.MoveTo(boxLeft, new Vector3(1.59f, -3, 0), 0.3f);
                    iTween.MoveTo(boxRight, new Vector3(2.34f, -3, 0), 0.3f);
                    iTween.MoveTo(mainSprite, new Vector3(2, -3, 0), 0.3f);

                    slidingRight = true;
                    slidingLeft = false;
                    spliting = false;
                }
                else if (Input.GetTouch(0).position.x < (Screen.width / 2) && Input.GetTouch(0).position.y < 650)
                {
                    if (mainSprite.transform.position.x >= 0)
                    {
                        slideSound.Play(0);
                    }

                    iTween.MoveTo(boxLeft, new Vector3(-2.34f, -3, 0), 0.3f);
                    iTween.MoveTo(boxRight, new Vector3(-1.59f, -3, 0), 0.3f);
                    iTween.MoveTo(mainSprite, new Vector3(-2, -3, 0), 0.3f);

                    slidingRight = false;
                    slidingLeft = true;
                    spliting = false;
                }

                if (distance > 0.1f)
                {
                    splitBack = true;
                    mainSprite.GetComponent<Renderer>().enabled = true;
                    boxLeft.GetComponent<Renderer>().enabled = false;
                    boxRight.GetComponent<Renderer>().enabled = false;
                }
            }

            else if (Input.touches.Length == 0)
            {
                iTween.MoveTo(boxLeft, new Vector3(-0.375f, -3, 0), 0.3f);
                iTween.MoveTo(boxRight, new Vector3(0.375f, -3, 0), 0.3f);
                iTween.MoveTo(mainSprite, new Vector3(0, -3, 0), 0.3f);
                
                slidingRight = false;
                slidingLeft = false;
                spliting = false;

                if (distance > 0.1f)
                {
                    splitBack = true;
                    mainSprite.GetComponent<Renderer>().enabled = true;
                    boxLeft.GetComponent<Renderer>().enabled = false;
                    boxRight.GetComponent<Renderer>().enabled = false;
                }
            }

            if (Input.touches.Length == 2)
            {
                if (distance < 1)
                {
                    slideSound.Play(0);
                }

                iTween.MoveTo(boxLeft, new Vector3(-2.1f, -3, 0), 0.3f);
                iTween.MoveTo(boxRight, new Vector3(2.1f, -3, 0), 0.3f);
                iTween.MoveTo(mainSprite, new Vector3(0, -3, 0), 0.3f);

                slidingRight = false;
                slidingLeft = false;
                spliting = true;
                splitBack = false;

                if (spliting == true && distance > 0.5f)
                {
                    mainSprite.GetComponent<Renderer>().enabled = false;
                    boxLeft.GetComponent<Renderer>().enabled = true;
                    boxRight.GetComponent<Renderer>().enabled = true;
                }
            }
            if (Input.touches.Length == 3)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}
