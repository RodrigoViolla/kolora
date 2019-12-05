using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

	public Vector3 ultimoCheckpoint;

	void Start () {
		ultimoCheckpoint = transform.position;
	}
	
	void Update () {
		if (PlayerManager.Estado == EnumEstados.MORTO) {
			PlayerManager.Instancia.transform.position = ultimoCheckpoint;
			PlayerManager.Estado = EnumEstados.PARADO;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Checkpoint") {
			ultimoCheckpoint = coll.transform.position;
			coll.GetComponentInChildren<Animator> ().Play ("checkpoint");
		}
	}
}
