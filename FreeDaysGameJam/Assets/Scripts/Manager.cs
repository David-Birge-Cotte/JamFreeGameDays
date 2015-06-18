using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Manager : NetworkBehaviour {

	[SyncVar]
	public int test;
	

	[Command]
	public void CmdSetTest(int i){
		test = i;
	}
}
