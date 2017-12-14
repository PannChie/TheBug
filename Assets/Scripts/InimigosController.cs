using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosController : MonoBehaviour {
	
	public Transform Player;
	private UnityEngine.AI.NavMeshAgent naveMesh;
	private float DistanciaPlayer, DistanciaPoint;
	public float DistanciaPercepcao = 30, DistanciaSeguir = 20, DistanciaAtacar = 2, VelocidadePasseio = 3, VelocidadePerseguicao = 6, TempoAtaque = 1.5f;
	private bool VendoPlayer;
	public Transform [] DestinosAleatorios;
	private int PointAtual;
	private bool PerseguindoAlgo, contadorPerseguindoAlgo,atacandoAlgo;
	private float cronometroDaPerseguicao,cronometroAtaque;
	void Start (){
		PointAtual = Random.Range (0, DestinosAleatorios.Length);
		naveMesh = transform.GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	void Update (){
		DistanciaPlayer = Vector3.Distance(Player.transform.position,transform.position);
		DistanciaPoint =  Vector3.Distance(DestinosAleatorios[PointAtual].transform.position,transform.position);
		//============================== RAYCAST ===================================//
		RaycastHit hit;
		Vector3 deOnde = transform.position;
		Vector3 paraOnde = Player.transform.position;
		Vector3 direction = paraOnde - deOnde;
		if(Physics.Raycast (transform.position,direction,out hit,1000) && DistanciaPlayer < DistanciaPercepcao ){
			if(hit.collider.gameObject.CompareTag("Player")){
				VendoPlayer = true;
			}else{
				VendoPlayer = false;
			}
		}
		//================ CHECHAGENS E DECISOES DO INIMIGO ================//
		if(DistanciaPlayer > DistanciaPercepcao){
			Passear();
		}
		if (DistanciaPlayer <= DistanciaPercepcao && DistanciaPlayer > DistanciaSeguir) {
			if(VendoPlayer == true){
				Olhar ();
			}else{
				Passear();
			}
		}
		if (DistanciaPlayer <= DistanciaSeguir && DistanciaPlayer > DistanciaAtacar) {
			if(VendoPlayer == true){
				Perseguir();
				PerseguindoAlgo = true;
			}else{
				Passear();
			}
		}
		if (DistanciaPlayer <= DistanciaAtacar) {
			Atacar();
		}
		//COMANDOS DE PASSEAR
		if (DistanciaPoint <= 2) {
		PointAtual = Random.Range (0, DestinosAleatorios.Length);
			Passear();
		}
		//CONTADORES DE PERSEGUICAO
		if (contadorPerseguindoAlgo == true) {
			cronometroDaPerseguicao += Time.deltaTime;
		}
		if (cronometroDaPerseguicao >= 5 && VendoPlayer == false) {
			contadorPerseguindoAlgo = false;
			cronometroDaPerseguicao = 0;
			PerseguindoAlgo = false;
		}
		// CONTADOR DE ATAQUE
		if (atacandoAlgo == true) {
			cronometroAtaque += Time.deltaTime;
		}
		if (cronometroAtaque >= TempoAtaque && DistanciaPlayer <= DistanciaAtacar) {
			atacandoAlgo = true;
			cronometroAtaque = 0;
			Debug.Log ("recebeuAtaque");
		} else if (cronometroAtaque >= TempoAtaque && DistanciaPlayer > DistanciaAtacar) {
			atacandoAlgo = false;
			cronometroAtaque = 0;
			Debug.Log ("errou");
		}
	}
	void Passear (){
		if (PerseguindoAlgo == false) {
			naveMesh.acceleration = 5;
			naveMesh.speed = VelocidadePasseio;
			naveMesh.destination = DestinosAleatorios [PointAtual].position;
		} else if (PerseguindoAlgo == true) {
			contadorPerseguindoAlgo = true;
		}
	}
	void Olhar(){
		naveMesh.speed = 0;
		transform.LookAt (Player);
	}
	void Perseguir(){
		naveMesh.acceleration = 8;
		naveMesh.speed = VelocidadePerseguicao;
		naveMesh.destination = Player.position;
	}
	void Atacar (){
		atacandoAlgo = true;
	}
}