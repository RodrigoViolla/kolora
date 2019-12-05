using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour {

	public float velocidade;

	void Update () {
		transform.position = new Vector3 (transform.position.x+velocidade, transform.position.y, transform.position.z);
	}
}
