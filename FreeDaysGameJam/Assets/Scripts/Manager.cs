using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public int blancScore;
	public int vertScore;
	public int bleuScore;
	public int roseScore;

	public Text blancScoreUI;
	public Text vertScoreUI;
	public Text bleuScoreUI;
	public Text roseScoreUI;


	void Update(){

		blancScoreUI.text = "Blanc : " + blancScore;
		vertScoreUI.text = "Vert : " + vertScore;
		bleuScoreUI.text = "Bleu : " + bleuScore;
		roseScoreUI.text = "Rose : " + roseScore;

	}


}
