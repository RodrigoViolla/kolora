using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {

	private Text moedas;

	void Start () {
		moedas = GetComponent<Text> ();
	}

	void Update () {
		moedas.text = PlayerManager.Instancia.GetComponent<GerenciadorDeMoedas> ().Moedas+"";
	}
}
