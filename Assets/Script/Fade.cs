using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public float _delayTime = 0.1f;
	private bool _isTimeComplete = false;

	public SpriteRenderer thisobj;


	private float _fadeSpeed = 0.3f;
	private int _drawDepth = -1000;
	private Color _guiColor;
    public float _alpha = 0;
	private float _fadeDir = 1.0f;


	public bool OnReady = false;
	void Start () 
	{
		//logo = GameObject.Find("logo").GetComponent<SpriteRenderer>() as SpriteRenderer;
		_guiColor = thisobj.color;
	}


	private void _UpdateDelay()
	{
		_delayTime -= Time.deltaTime;
	}
	// Update is called once per frame
	void Update () 
	{
        if(_alpha >= 0.9)
        {
            Application.LoadLevel("StartGame");
        }
		_UpdateDelay ();
		if(_delayTime <= 0 && !_isTimeComplete)
		{
			_isTimeComplete = true;
			
		}
		else if(_isTimeComplete){
			if(OnGui() >= 1f){

				Event_AfterFade();
				//Application.LoadLevel("MainPage");
			}
		}
	}
	private float OnGui()
	{
		_alpha += 0.009f;
		_guiColor.a = _alpha;
		thisobj.color = _guiColor;
		return _alpha;
	}

	void Event_AfterFade()
	{
		OnReady = true;
	}
	
}
