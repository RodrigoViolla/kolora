using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPersonagem : MonoBehaviour {

	public float distanciaZ, correcaoY;
	
	void Update () {
		Vector3 player = PlayerManager.Instancia.transform.position;
		transform.position = new Vector3 (player.x, player.y+correcaoY, distanciaZ);
	}
}
