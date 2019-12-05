using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMoedas : MonoBehaviour {

	private int moedas = 0;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Moeda") {
			moedas++;
			GetComponents<AudioSource> () [3].Play ();
			Destroy (col.gameObject);
		}
	}

	public int Moedas{
		get{ return moedas; }
		set{ moedas = value; }
	}
}
