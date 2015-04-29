using UnityEngine;
using System.Collections;

public class BoxCollision : MonoBehaviour 
{
    public GameObject overScene , apaeStart;
    GameObject theBox, obstract;

    TheBox boxScript;
    RandomObs obScript;

    public AudioSource playingSound, overSound, apaeLaughterSound;

	void Start()
    {
        theBox = GameObject.Find("TheBox");
        boxScript = theBox.GetComponent<TheBox>();

       

        obstract = GameObject.Find("Main");
        obScript = obstract.GetComponent<RandomObs>();



        apaeLaughterSound.Play(0);
        boxScript.isAlive(true);
    }
    void Update()
    {
        if (boxScript.mainSprite.transform.position.y <= -6.5f)
        {
            iTween.MoveTo(overScene, new Vector3(0, 0, -6), 0.3f);
            playingSound.Stop();
            overSound.Play(22050);
            apaeLaughterSound.Play(0);
            boxScript.mainSprite.transform.position = new Vector3(boxScript.mainSprite.transform.position.x, -6.0f, boxScript.mainSprite.transform.position.z);
        }
    }
	void OnTriggerEnter(Collider other) 
	{
        if (other.gameObject.tag == "Obs")
		{
            /*iTween.MoveTo(overScene, new Vector3(0, 0, -7), 0.3f);
            apaeStart.GetComponent<Renderer>().enabled = true;
            iTween.MoveTo(apaeStart, new Vector3(0, -2, 2), 0.3f);*/

            boxScript.isAlive(false);
            obScript.readyDeploy = false;
            obScript.active1 = false;
            obScript.active2 = false;
            obScript.active3 = false;
            iTween.MoveTo(boxScript.mainSprite, new Vector3(0, -6.5f, 0), 1.0f);
            iTween.MoveTo(boxScript.boxLeft, new Vector3(boxScript.boxLeft.transform.position.x, -6.5f, 0), 1.0f);
            iTween.MoveTo(boxScript.boxRight, new Vector3(boxScript.boxRight.transform.position.x, -6.5f, 0), 1.0f);
        }
	}
}
