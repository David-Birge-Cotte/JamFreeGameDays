using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour {

	[SyncVar]
	private Vector3 syncPos;
	
	public float lerpRate = 15;
	
	void FixedUpdate()
	{
		TransmitPosition();
		LerpPosition();
	}
	
	void LerpPosition()
	{
		if(!isLocalPlayer)
		{
			transform.position = Vector3.Lerp(transform.position, syncPos, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvidePositionToServer(Vector3 pos)
	{
		syncPos = pos;
	}

	[ClientCallback]
	void TransmitPosition()
	{
		CmdProvidePositionToServer(transform.position);
	}
}
