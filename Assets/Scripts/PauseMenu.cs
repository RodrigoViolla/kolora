using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject tela;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			AtivaTela ();
		}
		if(tela.activeSelf)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	public void AtivaTela(){
		if (tela.activeSelf) {
			tela.SetActive (false);
		} else {
			tela.SetActive (true);
		}
	}

	public void IrParaMenu(){
		SceneManager.LoadScene ("MainMenu");	
	}

	public void Restart(){
		PlayerManager.Instancia.GetComponent<Movimentacao> ().Matar ();
	}
}
