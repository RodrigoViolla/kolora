using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void TrocaCena(string cena){
		if (cena == "sair") {
			Application.Quit();
		} else {
			SceneManager.LoadScene (cena);
		}
	}
}
