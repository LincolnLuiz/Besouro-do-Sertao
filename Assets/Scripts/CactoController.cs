using UnityEngine;
using System.Collections;

public class CactoController : MonoBehaviour {

	public float speed;

	public GameObject direita;
	public GameObject esquerda;
	public GameObject estrela;
	public GameObject cactoCima;

	private bool estrela1;
	private bool estrela2;
	private bool estrela3;

	private PlayerController player;
	private GameController game;
	private bool passou;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType (typeof(PlayerController)) as PlayerController;
		game = FindObjectOfType (typeof(GameController)) as GameController;

		if (PlayerPrefs.GetFloat ("levelVelocidade") != 0) {
			speed = PlayerPrefs.GetFloat ("levelVelocidade");
		}
	}

	void OnEnable() {
		passou = false;
		estrela.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY) { 
			transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
			
			if (transform.position.x <= -6.31) {
				// fim do objeto
				this.gameObject.SetActive(false);
			}

			// pontuar
			if (transform.position.x <= -2.75) {
				if (passou == false) {
					player.addPonto();
					// play song
					SoundController.playSound(soundGame.ponto);
				}
				passou = true;
			}

			// estrela
			if (transform.position.x > 3.5f && transform.position.x < 4) {
				if (estrela1 == false) {
					if (PlayerPrefs.GetInt("levelEstrela") == 0) {
						if (player.ponto == PlayerPrefs.GetInt("levelEstrela1")) {
							estrela.SetActive(true);
							estrela1 = true; 
						}
					}
				}
				if (estrela2 == false) {
					if (PlayerPrefs.GetInt("levelEstrela") == 1) {
						if (player.ponto == PlayerPrefs.GetInt("levelEstrela2")) {
							estrela.SetActive(true);
							estrela2 = true;
						}
					}
				}
				if (estrela3 == false) {
					if (PlayerPrefs.GetInt("levelEstrela") == 2) {
						if (player.ponto == PlayerPrefs.GetInt("levelEstrela3")) {
							estrela.SetActive(true);
							estrela3 = true;
						}
					}
				}
			}
		}
	}
}
