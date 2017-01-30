using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject sol;
	public GameObject panelLoad;

	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	// Use this for initialization
	void Start () {
		// definir posicao do sol
		float x = Random.Range (minX, maxX);
		float y = Random.Range (minY, maxY);
		PlayerPrefs.SetFloat ("solX", x);
		PlayerPrefs.SetFloat ("solY", y);

		sol.transform.position = new Vector3 (x, y, sol.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		// verifica botao voltar
		if (Input.GetKeyDown(KeyCode.Escape)) {
			print("o");
			Application.Quit();
		}
	}

	public void iniciar() {
		SoundController.playSound(soundGame.click);
		panelLoad.SetActive (true);
		Application.LoadLevel ("stage");
	}
}
