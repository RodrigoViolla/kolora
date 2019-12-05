using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReguladorDeDistorcao : MonoBehaviour {

	public float profundidade;
	public float distorcao;
	public float velocidadeTransicao;

	private float suavizador = 1.5f;
	private Material material;

	void Start () {
		material = GetComponent<MeshRenderer> ().material;
	}

	void Update () {
		if (PlayerManager.Instancia.transform.position.y <= profundidade) {
			if (suavizador > distorcao) {
				suavizador -= velocidadeTransicao;
			}
		} else {
			if (suavizador <= 1.5) {
				suavizador += velocidadeTransicao;
			}
		}
		material.SetFloat("_RefrDistort", suavizador);
	}
}
