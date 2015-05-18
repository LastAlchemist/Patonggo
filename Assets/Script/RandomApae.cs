using UnityEngine;
using System.Collections;

public class RandomApae : MonoBehaviour 
{
	public GameObject aPaeStart, aPaeMad;
	public AudioSource paeRoar;
	public int score;
	public bool readyDeploy;
	GameObject main;
	GameObject obtract,obtract2,obtract3;

	float speed =   8.0f;
	int	passCount,createCount;

	TextMesh scoreBoard, finalScore;

	Main mainScript;
	float time;
	bool starting;

	float timeForDeploy = 3.0f;

	void Start () 
	{
		starting = false;
		time = 5.0f;
		main = GameObject.Find("Main");
		mainScript = main.GetComponent<Main>();

		scramble ();
	}

	void Update () 
	{
		if (starting == false) 
		{
			time -= Time.deltaTime;
			if(time < 3)
			{
				aPaeStart.transform.Translate(0, (7 * -1) * Time.deltaTime, 0);
				if(aPaeStart.transform.position.y < -17)
				{
					aPaeStart.GetComponent<Renderer>().enabled = false;
				}
			}

			if(time < 1)
			{
				starting = true;
				time = 0;
				readyDeploy = true;
				passCount = 0;
				createCount = 0;
				score = 0;
			}
		}

		scoreBoard = GameObject.Find("score").GetComponent<TextMesh>();
		scoreBoard.GetComponent<TextMesh>().text = score.ToString();
		
		finalScore = GameObject.Find("LastScore").GetComponent<TextMesh>();
		finalScore.GetComponent<TextMesh>().text = score.ToString();
		
		if (readyDeploy == true) 
		{
			obtract.transform.Translate (0, (speed * -1)* Time.deltaTime, 0);
			
			if (obtract.transform.position.y < -8) 
			{
				Destroy(obtract);
				scramble ();
				passCount += 1;
				score += 1;
			}
		}
		if(mainScript.backingToMain() == false)
		{

		}

		CheckSpeedUp ();
	}

	void CheckSpeedUp()
	{
		if (passCount == 10) 
		{
			readyDeploy = false;
			timeForDeploy -= Time.deltaTime;
			iTween.MoveTo(aPaeMad, new Vector3(0, -2, 1), 0.3f);
		}

		if(timeForDeploy <= 0)
		{
			passCount = 0;
			iTween.MoveTo(aPaeMad, new Vector3(0, 6, 1), 0.3f);
			readyDeploy = true;
			if(speed < 17)
			{
				speed += 1f;
			}
			timeForDeploy = 3;
		}
	}

	void scramble()
	{
		int scrambleNum = Random.Range(0,4);
		switch (scrambleNum) 
		{
			case 0:
				obtract = (GameObject)Instantiate (Resources.Load ("ObsMiddle"));
				obtract.transform.position = new Vector3 (0, 7.5f, 0);
				break;
			case 1:
				obtract = (GameObject)Instantiate (Resources.Load ("ObsRight"));
				obtract.transform.position = new Vector3 (1.2f, 7.5f, 0);
				break;
			case 2:
				obtract = (GameObject)Instantiate (Resources.Load ("ObsLeft"));
				obtract.transform.position = new Vector3 (-1.16f, 7.5f, 0);
				break;
			case 3:
				obtract = (GameObject)Instantiate (Resources.Load ("ObsBoth"));
				obtract.transform.position = new Vector3(-0.1f, 7.5f, 0);
				break;
		}
		createCount += 1;
		//active1 = true;
	}
}
