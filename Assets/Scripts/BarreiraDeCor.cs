using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraDeCor : MonoBehaviour {

	public EnumEstados estado;

	private SpriteRenderer sprite;
	private MudaCor playerCor;
	private Color32 cor;

	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		playerCor = PlayerManager.Instancia.GetComponent<MudaCor> ();
		cor = sprite.color;
	}

	void Update () {
		if (PlayerManager.Instancia.GetComponent<SpriteRenderer>().color == cor) {
			GetComponent<Collider2D> ().isTrigger = true;
		} else {
			GetComponent<Collider2D> ().isTrigger = false;
		}
	}
}
