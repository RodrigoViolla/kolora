using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorFolego : MonoBehaviour {

	TextMesh text;

	void Start () {
		text = GetComponent<TextMesh> ();
	}

	void Update () {
		if (PlayerManager.Instancia.GetComponent<Movimentacao> ().Submerso) {
			text.text = PlayerManager.Instancia.GetComponent<Movimentacao> ().Folego+"";
		} else {
			text.text = "";
		}
	}
}
