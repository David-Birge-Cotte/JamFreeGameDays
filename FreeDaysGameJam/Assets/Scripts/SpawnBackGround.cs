using UnityEngine;
using System.Collections;

public class SpawnBackGround : MonoBehaviour {

	public GameObject Beach;
	public GameObject Sea01;

	bool LastBackGroundIsSea =true;
	bool LastBackGroundIsbeach = false;

	Vector3 pos;

	// Use this for initialization
	void Start () {
		 pos = new Vector3(transform.position.x, -9, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnBackground ()
	{
		if(LastBackGroundIsSea)
		{
			Instantiate(Beach, pos, Quaternion.identity);
			LastBackGroundIsSea =false;
			LastBackGroundIsbeach = true;
		}
		else if(LastBackGroundIsbeach)
		{
			Instantiate(Sea01, pos, Quaternion.identity);
			LastBackGroundIsSea =true;
			LastBackGroundIsbeach = false;
		}

	}

}