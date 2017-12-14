using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	
	//Recomendaram por o script na camera;
	public Button startBotao; // botao start;
	public Button quitBotao; // botao quit;

	// Use this for initialization
	void Start () {
		startBotao.onClick.AddListener (() => {SceneManager.LoadScene("EntradaInferno"); }); //A referencia entre aspas é o nome da sua cena.
		quitBotao.onClick.AddListener (() => {Application.Quit();}); // paramertro pra sair do jogo, so funciona depois da build;
	}


}