using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{

    GameObject bgOil, bgOil2, bgOil3;
    float speed = 5.0f;

	void Start () 
    {

        bgOil = (GameObject)Instantiate(Resources.Load("Oil"));
        bgOil.transform.position = new Vector3(0, 12, 3);

        bgOil2 = (GameObject)Instantiate(Resources.Load("Oil"));
        bgOil2.transform.position = new Vector3(0, 24, 3);

       /* bgOil3 = (GameObject)Instantiate(Resources.Load("Oil"));
        bgOil3.transform.position = new Vector3(0, 36, 3);*/
	}
	
	void Update () 
    {
        bgOil.transform.Translate(0, (speed * -1) * Time.deltaTime, 0);
        bgOil2.transform.Translate(0, (speed * -1) * Time.deltaTime, 0);
       /* bgOil3.transform.Translate(0, (speed * -1) * Time.deltaTime, 0);*/


        if(bgOil.transform.position.y <= -12)
        {
            bgOil.transform.position = new Vector3(0, 12, 3);
        }
        if (bgOil2.transform.position.y <= -12)
        {
            bgOil2.transform.position = new Vector3(0, 12, 3);
        }
       /* if (bgOil3.transform.position.y <= -12)
        {
            bgOil3.transform.position = new Vector3(0, 12, 3);
        }*/
	}
}
