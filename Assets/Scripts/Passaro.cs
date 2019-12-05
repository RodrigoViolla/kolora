using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passaro : MonoBehaviour {


	public float tempoRestauracao;

	private Color32 cor;
	private float tempoAtual = 0;

	void Start(){
		cor = GetComponent<SpriteRenderer> ().color;
	}

	void Update(){
		if (GetComponent<Collider2D> ().enabled == false) {
			tempoAtual += Time.deltaTime;
		}

		if (tempoAtual >= tempoRestauracao) {
			GetComponent<Collider2D> ().enabled = true;
			GetComponent<SpriteRenderer> ().enabled = true;
			tempoAtual = 0;
			GetComponent<Animator> ().Play ("Parado");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			if (PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().PassaroNaMao) {
				PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().PassaroNaMao = false;
				transform.GetChild (0).GetComponent<SpriteRenderer> ().color = cor;
				transform.GetChild (1).GetComponent<SpriteRenderer> ().color = PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().Cor;
				GetComponent<Animator> ().Play ("Voando");
				GetComponent<Collider2D> ().enabled = false;
				PlayerManager.Instancia.GetComponents<AudioSource> () [4].Play ();
			} else {
				PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().PassaroNaMao = true;
				PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().Cor = cor;
				GetComponent<Collider2D> ().enabled = false;
				GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}
}
