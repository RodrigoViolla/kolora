using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour {

	public float velocidade;
	public float alturaDoPulo;
	public int quantidadeDePulosNoAr;
	public float detectorDoChao;
	public float detectorDaParede;
	public int folego;

	private int quantidadeDePulosAtual;
	private Rigidbody2D rigidBody; 
	private bool noChao;
	private EnumEstados estado = EnumEstados.PARADO;
	private float agachadoY;
	private float velocidadeAgachado;
	private SpriteRenderer sprite;
	private float emBaixoDagua = 0;
	private bool submerso = false;

	void Start () {
		quantidadeDePulosAtual = quantidadeDePulosNoAr;
		rigidBody = GetComponent<Rigidbody2D> ();
		agachadoY = GetComponent<CapsuleCollider2D>().size.y / 2;
		velocidadeAgachado = velocidade / 2;
		sprite = GetComponent<SpriteRenderer> ();
	}

	void Update () { 
		if (estado == EnumEstados.MORTO)
			return;
		
		estado = EnumEstados.PARADO;

		if (ChaoAoLado (1, "Chao") || ChaoAoLado (-1, "Chao")) {
			quantidadeDePulosAtual = quantidadeDePulosNoAr;
			if (rigidBody.velocity.y < 0) {
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, rigidBody.velocity.y / 2);
				estado = EnumEstados.ARRASTANDO_PAREDE;
			}
		}

		if ((!ChaoAoLado (1, "Obstaculo") && !ChaoAoLado (-1, "Obstaculo")) || EstaNoChao()) {			
			if (Input.GetButton ("Horizontal")) {
				float sub = submerso ? velocidade / 2 : 0;
				if (Input.GetAxis ("Horizontal") > 0) {
					if (!ChaoAoLado (1, "Chao")) {										
						rigidBody.velocity = new Vector2 (velocidade-sub, rigidBody.velocity.y);
						sprite.flipX = false;
						if (ChaoAoLado (1, "Chao"))
							estado = EnumEstados.PARADO_PAREDE;
						else
							estado = EnumEstados.ANDANDO;
					}
				
				} else {
					if (!ChaoAoLado (-1, "Chao")) {
						rigidBody.velocity = new Vector2 (-velocidade+sub, rigidBody.velocity.y);
						sprite.flipX = true;
						if (ChaoAoLado (-1, "Chao"))
							estado = EnumEstados.PARADO_PAREDE;
						else
							estado = EnumEstados.ANDANDO;
					}
				}
			} else {
				rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
			}
		} 
		if (Input.GetButtonDown ("Jump") && estado != EnumEstados.PARADO_PAREDE) {
			if (submerso || EstaNoChao () || ChaoAoLado (1, "Chao") || ChaoAoLado (-1, "Chao")) {
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 0);
				rigidBody.AddForce (new Vector2 (0, alturaDoPulo), ForceMode2D.Impulse);
				quantidadeDePulosAtual = quantidadeDePulosNoAr;
				estado = EnumEstados.CAINDO;
			} else {
				if (quantidadeDePulosAtual > 0) {
					rigidBody.velocity = new Vector2 (rigidBody.velocity.x , 0);
					rigidBody.AddForce (new Vector2 (0, alturaDoPulo), ForceMode2D.Impulse);
					quantidadeDePulosAtual--;
					estado = EnumEstados.CAINDO;
				}
			}
		}

		if (EstaNoChao ())
			quantidadeDePulosAtual = quantidadeDePulosNoAr;

		if (!EstaNoChao () && !ChaoAoLado(1, "Chao") && !ChaoAoLado(-1, "Chao") || rigidBody.velocity.y > 0)
			estado = EnumEstados.CAINDO;

		if (Input.GetButton ("Agachar") && estado != EnumEstados.ARRASTANDO_PAREDE) {
			GetComponent<CapsuleCollider2D>().size = new Vector2 (GetComponent<CapsuleCollider2D>().size.x, agachadoY);
			velocidade = velocidadeAgachado;
			if (rigidBody.velocity.y < -2f) {
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, rigidBody.velocity.y * 1.1f);
				estado = EnumEstados.AGACHADO_CAINDO;
			} else {
				estado = EnumEstados.AGACHADO;
			}
		} else {
			GetComponent<CapsuleCollider2D>().size = new Vector2 (GetComponent<CapsuleCollider2D>().size.x, agachadoY*2);
			velocidade = velocidadeAgachado * 2;
		}

		if (rigidBody.velocity.y < 0 && EstaNoChao () && !submerso)
			GetComponent<AudioSource> ().Play ();

		if ((int)(folego-(emBaixoDagua/100)) <= 0)
			estado = EnumEstados.MORTO;

		if (submerso) {
			GetComponents<AudioSource> () [0].pitch = 0.3f;
			GetComponents<AudioSource> () [1].enabled = false;
			GetComponents<AudioSource> () [2].pitch = 0.8f;
		} else {
			GetComponents<AudioSource> () [0].pitch = 0.4f;
			GetComponents<AudioSource> () [1].enabled = true;
			GetComponents<AudioSource> () [2].pitch = 1f;
		}
	}

	private bool EstaNoChao(){
		RaycastHit2D ray = Physics2D.Linecast (new Vector2(transform.position.x+0.1f, transform.position.y-detectorDoChao), new Vector2(transform.position.x-0.1f, transform.position.y-detectorDoChao));
		Debug.DrawLine (new Vector2(transform.position.x+0.1f, transform.position.y-detectorDoChao), new Vector2(transform.position.x-0.1f, transform.position.y-detectorDoChao), Color.red);

		if (ray.collider != null && ray.collider.tag == "Chao") {
			return true;
		}

		return false;
	}

	private bool ChaoAoLado(int lado, string tag){
		float corretorY = GetComponent<CapsuleCollider2D>().size.y == agachadoY ? 0 : 0.2f;

		RaycastHit2D ray = Physics2D.Linecast (new Vector2 (transform.position.x + (lado*detectorDaParede), transform.position.y-corretorY), new Vector2 (transform.position.x + (0.05f*lado)+ (detectorDaParede*lado), transform.position.y-corretorY));
		Debug.DrawLine (new Vector2 (transform.position.x + (lado*detectorDaParede), transform.position.y-corretorY), new Vector2 (transform.position.x + (0.05f*lado)+ (detectorDaParede*lado), transform.position.y-corretorY), Color.blue);

		if (ray.collider != null && ray.collider.tag == tag) {
			return true;
		}

		return false;
	}

	public EnumEstados Estado{
		get{ return estado; }
		set{ estado = value; }
	}

	public void Matar(){
		estado = EnumEstados.MORTO;
	}

	IEnumerator OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Agua") {
			submerso = true;
			emBaixoDagua += 1;
			if(rigidBody.velocity.y<0)
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, rigidBody.velocity.y / 1.3f);
			else
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, rigidBody.velocity.y * 1.01f);
			yield return new WaitForSeconds (1); 
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Agua") {
			emBaixoDagua = 0;
			submerso = false;
		}
	}

	public int Folego{
		get{return (int)(folego-(emBaixoDagua/100));}
	}

	public void ResetaFolego(){
		emBaixoDagua = 0;
	}

	public bool Submerso{
		get{return submerso;}
	}
}

public enum EnumEstados{
	ANDANDO,
	CORRENDO,
	CAINDO,
	ARRASTANDO_PAREDE,
	PARADO_PAREDE,
	PARADO,
	PULANDO,
	MORTO,
	AGACHADO,
	AGACHADO_CAINDO
}
