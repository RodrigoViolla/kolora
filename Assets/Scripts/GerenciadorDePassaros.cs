using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDePassaros : MonoBehaviour {

	public float tempoRestauracao;
	public SpriteRenderer passaro;

	private Color32 cor;
	private float tempoAtual = 0;
	private int passaros = 0;
	private bool passaroNaMao = false;

	void Update(){
		if (passaroNaMao) {
			tempoAtual += Time.deltaTime;
			passaro.enabled = true;
		} else {
			passaro.enabled = false;
		}

		if (tempoAtual >= tempoRestauracao) {
			cor = Color.white;
			passaroNaMao = false;
			tempoAtual = 0;
		}
	}

	public int Passaros{
		get{return passaros;}
		set{passaros = value;}
	}

	public bool PassaroNaMao{
		get{ return passaroNaMao; }
		set{ 
			if (value)
				tempoAtual = 0;
			else
				tempoAtual = tempoRestauracao;
			passaroNaMao = value; }
	}

	public Color32 Cor{
		get{ return cor; }
		set{ cor = value; }
	}
}
