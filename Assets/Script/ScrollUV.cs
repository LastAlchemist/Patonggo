using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour 
{
    GameObject GameObj;
    //MainControl MainSc;
    void Start()
    {
    
       // GameObj = GameObject.FindGameObjectWithTag("GameController");
       // MainSc = GameObj.GetComponent<MainControl>();

    }
	// Update is called once per frame
	void Update () 
    {
      //  if(!MainSc.StopGame)
      //  { 
            MeshRenderer mr = GetComponent<MeshRenderer>();

            Material mat = mr.material;

            Vector2 offset = mat.mainTextureOffset;

            offset.y += Time.deltaTime / 2f;

            mat.mainTextureOffset = offset;
    //    }
	
	}
}
