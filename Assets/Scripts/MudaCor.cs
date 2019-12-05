using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaCor : MonoBehaviour {

	private SpriteRenderer playerSprite;

	void Start(){
		playerSprite = PlayerManager.Instancia.GetComponent<SpriteRenderer> ();
	}

	void Update () {		
		if (PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().PassaroNaMao) {
			playerSprite.color = PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().Cor;
			PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().passaro.color = PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().Cor;
		} else {
			playerSprite.color = Color.white;
			PlayerManager.Instancia.GetComponent<GerenciadorDePassaros> ().passaro.color = Color.white;
		}
		
	}
}
