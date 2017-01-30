using UnityEngine;
using System.Collections;

public enum GameStatus {
	PLAY,
	PAUSE,
	RESTART,
	GAMEOVER,
	TUTORIAL
}

public class GameController : MonoBehaviour {

	public GameStatus status;

	public GameObject sol;

	// Use this for initialization
	void Start () {
		// definir posicao do sol
		sol.transform.position = new Vector3 (PlayerPrefs.GetFloat("solX"), PlayerPrefs.GetFloat("solY"), sol.transform.position.z);

		status = GameStatus.TUTORIAL;
	}
	
	// Update is called once per frame
	void Update () {
		// RESTART
		if (status == GameStatus.RESTART) {
			status = GameStatus.PLAY;
		}
	}

	public void pausar() {
		if(Time.timeScale == 0) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
	}

	public void start() {
		status = GameStatus.PLAY;
	}
	public void pause() {
		SoundController.playSound(soundGame.click);
		if (status == GameStatus.PAUSE) {
			status = GameStatus.RESTART;
		} else {
			status = GameStatus.PAUSE;
		}
	}
	public void gameOver() {
		salvar ();
		PlayerPrefs.SetInt("estrelasTotais", 0);
		status = GameStatus.GAMEOVER;
	}
	public void reinicar() {
		SoundController.playSound(soundGame.click);
		Application.LoadLevel ("play");
		Time.timeScale = 1;
	}
	public void voltarLevel() {
		Application.LoadLevel ("stage");
	}
	protected void salvar() {
		var DS = new DataService ("besouro_do_sertao.db");
		int pId = PlayerPrefs.GetInt ("levelId");
		print (pId);
		Level level = DS._connection.Table<Level>().Where(x => x.Id == pId).FirstOrDefault();
		level.Recorde = PlayerPrefs.GetInt ("levelRecorde");
		level.Estrela = PlayerPrefs.GetInt ("levelEstrela");
		DS._connection.Update(level);
	}
}
