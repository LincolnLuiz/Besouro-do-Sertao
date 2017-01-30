using UnityEngine;
using System.Collections;

public enum soundGame {
	fly,
	ponto,
	gameover,
	click,
	star,
	bloq
}

public class SoundController : MonoBehaviour {

	public AudioClip fly;
	public AudioClip ponto;
	public AudioClip gameOver;
	public AudioClip click;
	public AudioClip star;
	public AudioClip bloq;

	public static SoundController instance;


	// Use this for initialization
	void Start () {
		instance = this;
	}

	public static void playSound(soundGame currentSound) {
		switch (currentSound) {
			case soundGame.fly :
				instance.audio.PlayOneShot(instance.fly);
			break;
			case soundGame.ponto :
				instance.audio.PlayOneShot(instance.ponto);
			break;
			case soundGame.gameover :
			instance.audio.PlayOneShot(instance.gameOver);
			break;
			case soundGame.click :
			instance.audio.PlayOneShot(instance.click);
			break;
			case soundGame.star :
			instance.audio.PlayOneShot(instance.star);
			break;
			case soundGame.bloq :
			instance.audio.PlayOneShot(instance.bloq);
			break;
		}
	}
}
