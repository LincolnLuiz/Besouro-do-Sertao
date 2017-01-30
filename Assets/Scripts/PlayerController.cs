using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool inAnim;
	private float currentTimeAnim;

	public int ponto;

	private GuiController gui;
	private GameController game;

	// Use this for initialization
	void Start () {
		gui = FindObjectOfType (typeof(GuiController)) as GuiController;
		game = FindObjectOfType (typeof(GameController)) as GameController;

		rigidbody2D.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// iniciar jogo
		if (Input.GetMouseButtonDown(0) && game.status == GameStatus.TUTORIAL) {
			rigidbody2D.gravityScale = 1;
			game.start();
		}

		// difine posicao fixa
		transform.position = new Vector2 (-1.23f, transform.position.y);

		// bloqueia voos altos
		if (transform.position.y > 5) {
			transform.position = new Vector2 (transform.position.x, 5);
			rigidbody2D.velocity = Vector2.zero;
		}

		// VOAR
		if(Input.GetMouseButtonDown(0)) {
			if (game.status == GameStatus.PLAY) {
				currentTimeAnim = 0;
				inAnim = true;
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce(new Vector2(0, 250));
				SoundController.playSound(soundGame.fly);
			}
		}

		// verifica pausa
		if (game.status == GameStatus.PAUSE || game.status == GameStatus.GAMEOVER) {
			rigidbody2D.gravityScale = 0;
			rigidbody2D.Sleep();
			GetComponent<Animator>().speed = 0;
		}
		if (game.status == GameStatus.PLAY) {
			rigidbody2D.gravityScale = 1;
			rigidbody2D.WakeUp();
			GetComponent<Animator>().speed = 1;
		}

		// tratamento da animacao
		if (inAnim) {
			currentTimeAnim += Time.deltaTime;

			if (currentTimeAnim > 0.55f) {
				currentTimeAnim = 0;
				inAnim = false;
			}
		}
		GetComponent<Animator>().SetBool("voar", inAnim);

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (PlayerPrefs.GetInt("levelRecorde") < ponto) {
			PlayerPrefs.SetInt("levelRecorde", ponto);
		}
		gui.gameOver ();
	}

	void OnTriggerEnter2D (Collider2D coll) {
		SoundController.playSound (soundGame.star);
		coll.gameObject.SetActive (false);
		int quatEstrelas = PlayerPrefs.GetInt ("levelEstrela");
		PlayerPrefs.SetInt ("levelEstrela", quatEstrelas + 1);
	}

	public void addPonto() {
		ponto += 1;
	}


}
