using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraMoedas : MonoBehaviour {

	public int moedas;
	public TextMesh text;

	void Update () {
		text.text = ""+moedas;

		if (PlayerManager.Instancia.GetComponent<GerenciadorDeMoedas> ().Moedas >= moedas)
			Destroy (gameObject);	
	}
}
