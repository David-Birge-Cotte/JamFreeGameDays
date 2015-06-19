using UnityEngine;
using System.Collections;

public class SpawnBackGround : MonoBehaviour {

	public GameObject Beach;
	public GameObject Sea01;
	public GameObject TransitionBeachToSea;
	public GameObject TransitionSeaToBeach;


	enum LastBackGround
	{
		LastBackGroundIsSea,
		LastBackGroundIsBeach,
		LastBackGroundIsTransitionBeachToSea,
		LastBackGroundIsTransitionSeaToBeach,
	}

	LastBackGround myLastBackGround = LastBackGround.LastBackGroundIsSea;


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
		switch(myLastBackGround)
		{
		case LastBackGround.LastBackGroundIsBeach:
			Instantiate(TransitionBeachToSea, pos, Quaternion.identity);
			myLastBackGround = LastBackGround.LastBackGroundIsTransitionBeachToSea;
			break;
			
		case LastBackGround.LastBackGroundIsTransitionBeachToSea:
			Instantiate(Sea01, new Vector3(transform.position.x, -8.75f, 0), Quaternion.identity);
			myLastBackGround = LastBackGround.LastBackGroundIsSea;
			break;
			
		case LastBackGround.LastBackGroundIsSea:
			Instantiate(TransitionSeaToBeach, pos, Quaternion.identity);
			myLastBackGround = LastBackGround.LastBackGroundIsTransitionSeaToBeach;
			break;
			
		case LastBackGround.LastBackGroundIsTransitionSeaToBeach:
			Instantiate(Beach, new Vector3(transform.position.x, -7.4f, 0), Quaternion.identity);
			myLastBackGround = LastBackGround.LastBackGroundIsBeach;
			break;

		/*
		switch(myLastBackGround)
		{
		case LastBackGround.LastBackGroundIsBeach:
			if (i==1)
			{
				Instantiate(Beach, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsBeach;
			}
			else
			{
				Instantiate(TransitionBeachToSea, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsTransitionBeachToSea;
			}
			break;

		case LastBackGround.LastBackGroundIsTransitionBeachToSea:
			if (i==1)
			{
				Instantiate(Beach, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsBeach;
			}
			else
			{
				Instantiate(TransitionBeachToSea, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsTransitionBeachToSea;
			}
			break;

		case LastBackGround.LastBackGroundIsSea:
			if (i==1)
			{
				Instantiate(Beach, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsBeach;
			}
			else
			{
				Instantiate(TransitionBeachToSea, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsTransitionBeachToSea;
			}
			break;

		case LastBackGround.LastBackGroundIsTransitionSeaToBeach:
			if (i==1)
			{
				Instantiate(Beach, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsBeach;
			}
			else
			{
				Instantiate(TransitionBeachToSea, pos, Quaternion.identity);
				myLastBackGround = LastBackGround.LastBackGroundIsTransitionBeachToSea;
			}
			break;*/


		}
	}
}