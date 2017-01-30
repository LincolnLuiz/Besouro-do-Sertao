using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiController : MonoBehaviour {

	private GameController game;
	private PlayerController player;
	public GameObject panel;
	
	public GameObject panelGameOver;
	public GameObject pontosGameOver;
	public GameObject recordeGameOver;
	public GameObject txtToquePlay;
	public GameObject txtSertao;
	public GameObject txtLevel;

	public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;
	public Sprite spriteEstrela;
	public Sprite localEstrela;

	public GameObject pontos;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType (typeof(GameController)) as GameController;
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;

		txtSertao.GetComponent<Text> ().text = "Sertão - " + PlayerPrefs.GetInt ("levelIdSertao");
		txtLevel.GetComponent<Text> ().text = "level - " + PlayerPrefs.GetInt ("levelNumero");
	}
	
	// Update is called once per frame
	void Update () {
		pontos.GetComponent<Text> ().text = player.ponto.ToString();

		if (game.status == GameStatus.PLAY) {
			txtToquePlay.SetActive(false);
			txtSertao.SetActive(false);
			txtLevel.SetActive(false);
		}

		if (game.status == GameStatus.PLAY || game.status == GameStatus.PAUSE) {
			pontos.SetActive(true);
			estrela1.SetActive(true);
			estrela2.SetActive(true);
			estrela3.SetActive(true);
		} else {
			pontos.SetActive(false);
			estrela1.SetActive(false);
			estrela2.SetActive(false);
			estrela3.SetActive(false);
		}

		// verifica botao voltar
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (game.status == GameStatus.PLAY || game.status == GameStatus.PAUSE) {
				pausar();
			} else {
				sair ();
			}
		}

		// atualizar estrelas
		if (PlayerPrefs.GetInt("levelEstrela") >= 1) {
			estrela1.GetComponent<Image>().sprite = spriteEstrela;
		} else {
			estrela1.GetComponent<Image>().sprite = localEstrela;
		}
		if (PlayerPrefs.GetInt("levelEstrela") >= 2) {
			estrela2.GetComponent<Image>().sprite = spriteEstrela;
		} else {
			estrela2.GetComponent<Image>().sprite = localEstrela;
		}
		if (PlayerPrefs.GetInt("levelEstrela") == 3) {
			estrela3.GetComponent<Image>().sprite = spriteEstrela;
		} else {
			estrela3.GetComponent<Image>().sprite = localEstrela;
		}
	}

	public void sair() {
		Application.LoadLevel ("stage");
	}

	public void pausar() {
		if (game.status == GameStatus.PAUSE) {
			panel.GetComponent<Animator> ().SetBool("outPanel" , true);
			panel.GetComponent<Animator> ().SetBool("inPanel" , false);
			//panel.GetComponent<Animator> ().SetBool("outPanel" , false);
			game.pause ();
		} else {
			panel.GetComponent<Animator> ().SetBool("inPanel" , true);
			panel.GetComponent<Animator> ().SetBool("outPanel" , false);
			//panel.GetComponent<Animator> ().SetBool("inPanel" , false);
			game.pause ();
		}
		/*if (panel.activeSelf) {
			panel.SetActive (false);
		} else {
			panel.SetActive (true);
		}*/
	}

	public void gameOver() {
		SoundController.playSound(soundGame.gameover);
		panelGameOver.SetActive (true);
		pontosGameOver.GetComponent<Text> ().text = player.ponto.ToString ();
		recordeGameOver.GetComponent<Text> ().text = PlayerPrefs.GetInt ("levelRecorde").ToString();
		game.gameOver ();
	}

	public void voltarLevel() {
		game.voltarLevel ();
	}
}
