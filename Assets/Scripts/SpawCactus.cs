using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawCactus : MonoBehaviour {

	public float maxHeight;
	public float minHeight;

	public float rateSpaw;
	public int max;
	
	private float currentRateSpaw;
	
	public GameObject cactu;
	public List<GameObject> cactus;

	public GameObject cactoMenor;
	public List<GameObject> cactosMenor;

	public GameObject palma;
	public List<GameObject> palmas;

	private GameController game;
	
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("sertao") == 2) {
			maxHeight = 2.1f;
			minHeight = -0.8f;
		}
		game = FindObjectOfType (typeof(GameController)) as GameController;

		for (int i = 0; i <= max; i++) {
			GameObject tmpCactu;
			if (PlayerPrefs.GetInt("sertao") == 2) {
				tmpCactu = Instantiate(cactoMenor) as GameObject;
			} else {
				tmpCactu = Instantiate(cactu) as GameObject;
			}

			tmpCactu.SetActive(false);
			cactus.Add(tmpCactu);
		}
		if (PlayerPrefs.GetFloat ("levelRateSpaw") != 0) {
			rateSpaw = PlayerPrefs.GetFloat ("levelRateSpaw");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY) {
			currentRateSpaw += Time.deltaTime;
			if (currentRateSpaw > rateSpaw) {
				currentRateSpaw = 0;
				spaw ();
			}
		}
	}
	
	private void spaw() {
		float randHeight = Random.Range (minHeight, maxHeight);
		GameObject tmpCactu = null;
		// procurar cenario inativo para serem lancados
		for (int i = 0; i <= max; i++) {
			if (cactus[i].activeSelf == false) {
				tmpCactu = cactus[i];
				break;
			}
		}
		
		if (tmpCactu != null) {
			tmpCactu.transform.position = new Vector3(transform.position.x, randHeight, transform.position.z);
			tmpCactu.SetActive(true);
		}
	}
}
