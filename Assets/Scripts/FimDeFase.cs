using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FimDeFase : MonoBehaviour {

	public int umaEstrela, duasEstrelas, tresEstrelas;
	public GameObject telaFim;
	public Image estrela1, estrela2, estrela3;

	private Vector3 ultimoCheckpoint;
	private int resultado = 0;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			int moedas = PlayerManager.Instancia.GetComponent<GerenciadorDeMoedas> ().Moedas;

			if (moedas >= tresEstrelas) {				
				resultado = 3;
				PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name, resultado);
				MostrarFim (resultado);
				return;
			}
			if(moedas >= duasEstrelas){
				resultado = 2;
				if(PlayerPrefs.GetInt (SceneManager.GetActiveScene ().name) < 2)
					PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name, resultado);
				MostrarFim (resultado);
				return;
			}
			if (moedas >= umaEstrela) {
				resultado = 1;
				if(PlayerPrefs.GetInt (SceneManager.GetActiveScene ().name) < 1)
					PlayerPrefs.SetInt (SceneManager.GetActiveScene ().name, resultado);
				MostrarFim (resultado);
				return;
			}
			MostrarFim (resultado);
		}
	}

	void printScore(){
		print("Atual: "+resultado+" Maior:"+PlayerPrefs.GetInt (SceneManager.GetActiveScene ().name));
	}

	void Start(){
		ultimoCheckpoint = PlayerManager.Instancia.transform.position;	
	}

	public void MostrarFim(int pontos){

		Time.timeScale = 0;
		telaFim.SetActive(true);

		if(pontos >= 3){
			estrela1.color = Color.yellow;
			estrela2.color = Color.yellow;
			estrela3.color = Color.yellow;
			return;
		}
		if(pontos >= 2){
			estrela1.color = Color.yellow;
			estrela2.color = Color.yellow;
			estrela3.color = Color.white;
			return;
		}
		if(pontos >= 1){
			estrela1.color = Color.yellow;
			estrela2.color = Color.white;
			estrela3.color = Color.white;
			return;
		}

		estrela1.color = Color.white;
		estrela2.color = Color.white;
		estrela3.color = Color.white;
	}

	public void Restart(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Default");
	}
}
