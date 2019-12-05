using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour {

	public float tempoRestauracao;

	private float tempoAtual = 0;

	void Update(){
		if (GetComponent<Collider2D> ().enabled == false) {
			tempoAtual += Time.deltaTime;
		}

		if (tempoAtual >= tempoRestauracao) {
			GetComponent<Collider2D> ().enabled = true;
			GetComponent<SpriteRenderer> ().enabled = true;
			tempoAtual = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			PlayerManager.Instancia.GetComponent<Movimentacao> ().ResetaFolego ();
			GetComponent<Collider2D> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}
