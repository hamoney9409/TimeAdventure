using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

	public GameObject tileSet_A;
	public GameObject tileSet_B;



	void Start(){

        tileSet_A = GameObject.FindWithTag("tileSet_A");
        tileSet_B = GameObject.FindWithTag("tileSet_B");

        tileSet_A.SetActive (true);
		tileSet_B.SetActive (false);
	}
		
	public void TimeSkill(){
        Debug.Log(tileSet_A);
		if (tileSet_A.activeSelf == true) {	// A -> B

			tileSet_B.SetActive (true);
			tileSet_A.SetActive (false);

		
		}

		else if (tileSet_B.activeSelf == true) {	// B -> A

			tileSet_A.SetActive (true);
			tileSet_B.SetActive (false);

		
		}
	}

}
