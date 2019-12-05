using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeAnimacoes : MonoBehaviour {

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update () {		
		switch (PlayerManager.Estado) {
			case EnumEstados.ANDANDO:
				animator.SetTrigger ("andando");
				break;
			case EnumEstados.ARRASTANDO_PAREDE:
				animator.SetTrigger ("arrastando_parede");
				break;
			case EnumEstados.PARADO_PAREDE:
				animator.SetTrigger ("parado_parede");
				break;
			case EnumEstados.CAINDO:
				animator.SetTrigger ("caindo");
				break;
			case EnumEstados.AGACHADO:
				animator.SetTrigger ("agachado");
				break;
			case EnumEstados.AGACHADO_CAINDO:
				animator.SetTrigger ("agachado");
				break;
			default:
				animator.SetTrigger ("parado");
				break;
		}
	}
}
