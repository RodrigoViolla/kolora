using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private static GameObject instancia;
	private static Movimentacao movimentacao;
	private static EnumEstados estado;

	void Start () {
		if (instancia == null) {
			instancia = gameObject;
			movimentacao = GetComponent<Movimentacao> ();
		}
	}
	
	public static GameObject Instancia{
		get{return instancia;}
		set{ instancia = value; }
	}

	public static EnumEstados Estado{
		get{ return movimentacao.Estado; }
		set{ movimentacao.Estado = value; }
	}
	public static void Matar(){
		movimentacao.Matar ();
	}
}
