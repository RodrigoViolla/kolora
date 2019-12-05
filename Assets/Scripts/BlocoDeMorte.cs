using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoDeMorte : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player")
			PlayerManager.Matar ();
	}
}
