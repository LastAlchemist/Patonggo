using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomObs : MonoBehaviour 
{
    public GameObject aPaeStart,aPaeMad;
    public AudioSource paeRoar;
    public bool active1, active2, active3 = false;
    public bool readyDeploy;
	GameObject obtract , obtract2, obtract3, main;
    TextMesh scoreBoard, finalScore;
    public int score;
	float speed =   8.0f;
	int	passCount,createCount;
    Main mainScript;
	float time;
    bool starting;
	
	void Start () 
	{
        starting = false;
		time = 5.0f;
        main = GameObject.Find("Main");
        mainScript = main.GetComponent<Main>();
	}

	void Update () 
	{
        if(starting == false)
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
                scramble();
            }
            
        }

        scoreBoard = GameObject.Find("score").GetComponent<TextMesh>();
        scoreBoard.GetComponent<TextMesh>().text = score.ToString();

        finalScore = GameObject.Find("LastScore").GetComponent<TextMesh>();
        finalScore.GetComponent<TextMesh>().text = score.ToString();

		if (readyDeploy == true) 
		{
			GenerateObstract ();
		}
        if(mainScript.backingToMain() == false)
        {
            FallingObstract();
        }
		
		CheckSpeedUp ();
	}

	IEnumerator MyMethod() 
	{
		yield return new WaitForSeconds(3);
		if (readyDeploy == false) 
        {
			readyDeploy = true;
            createCount = 0;
			passCount = 0;
			speed += 1f;
            iTween.MoveTo(aPaeMad, new Vector3(0, 6, 0), 0.3f);
            yield return new WaitForSeconds(1);
            scramble();
		}
	}

	void CheckSpeedUp()
	{
        if (createCount == 10)
        {
            readyDeploy = false;
        }
		if (passCount == 10) 
		{
            iTween.MoveTo(aPaeMad, new Vector3(0, -2, 0), 0.3f);
			StartCoroutine(MyMethod());
		}
	}
	void FallingObstract() 
	{
		if (active1 == true) 
		{
			obtract.transform.Translate (0, (speed * -1)* Time.deltaTime, 0);
			if(obtract.transform.position.y < -8)
			{
				active1 = false;
				Destroy(obtract);
                passCount += 1;
                score += 1;
                if(passCount == 0)
                {
                    iTween.MoveTo(aPaeMad, new Vector3(0, -2.2f, 0), 0.3f);
                }
			}
		}
		if (active2 == true) 
		{
            obtract2.transform.Translate(0, (speed * -1) * Time.deltaTime, 0);
			if(obtract2.transform.position.y < -8)
			{
				active2 = false;
				Destroy(obtract2);
                passCount += 1;
                score += 1;
                if (passCount == 0)
                {
                    iTween.MoveTo(aPaeMad, new Vector3(0, -2.2f, 0), 0.3f);
                }
			}
		}
		if (active3 == true) 
		{
            obtract3.transform.Translate(0, (speed * -1) * Time.deltaTime, 0);
			if(obtract3.transform.position.y < -8)
			{
				active3 = false;
				Destroy(obtract3);
                passCount += 1;
                score += 1;
                if (passCount == 0)
                {
                    iTween.MoveTo(aPaeMad, new Vector3(0, -2.2f, 0), 0.3f);
                }
			}
		}

	}
	void GenerateObstract()
	{
		if (active1 == true) 
		{
			if(obtract.transform.position.y < -3)
			{
				if(active2 == false)
				{
					scramble2 ();
				}
			}
		}
		
		if (active2 == true) {
			if(obtract2.transform.position.y < -3)
			{
				if(active3 == false)
				{
					scramble3 ();
				}
			}
		}
		
		if (active3 == true) 
		{
			if(obtract3.transform.position.y < -3)
			{
				if(active1 == false)
				{
					scramble();
				}
			}
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
		active1 = true;
	}
	void scramble2()
	{
		int scrambleNum2 = Random.Range(0,4);
		switch (scrambleNum2) 
		{
		case 0:
			obtract2 = (GameObject)Instantiate (Resources.Load ("ObsMiddle"));
            obtract2.transform.position = new Vector3(0, 7.5f, 0);
			break;
		case 1:
            obtract2 = (GameObject)Instantiate(Resources.Load("ObsRight"));
            obtract2.transform.position = new Vector3(1.2f, 7.5f, 0);
			break;
		case 2:
            obtract2 = (GameObject)Instantiate(Resources.Load("ObsLeft"));
            obtract2.transform.position = new Vector3(-1.16f, 7.5f, 0);
			break;
		case 3:
            obtract2 = (GameObject)Instantiate(Resources.Load("ObsBoth"));
            obtract2.transform.position = new Vector3(-0.1f, 7.5f, 0);
			break;
		}
        createCount += 1;
		active2 = true;
	}
	void scramble3()
	{
		int scrambleNum3 = Random.Range(0,4);
		switch (scrambleNum3) 
		{
		case 0:
              obtract3 = (GameObject)Instantiate(Resources.Load("ObsMiddle"));
              obtract3.transform.position = new Vector3(0, 7.5f, 0);
			break;
		case 1:
            obtract3 = (GameObject)Instantiate(Resources.Load("ObsRight"));
            obtract3.transform.position = new Vector3(1.2f, 7.5f, 0);
			break;
		case 2:
            obtract3 = (GameObject)Instantiate(Resources.Load("ObsLeft"));
            obtract3.transform.position = new Vector3(-1.16f, 7.5f, 0);
			break;
		case 3:
            obtract3 = (GameObject)Instantiate(Resources.Load("ObsBoth"));
            obtract3.transform.position = new Vector3(-0.1f, 7.5f, 0);
			break;
		}
        createCount += 1;
		active3 = true;
	}
}
