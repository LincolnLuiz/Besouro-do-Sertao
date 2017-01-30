using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiSertao : MonoBehaviour {

	public GameObject txtSertao;
	public GameObject txtSertaoLevel;
	public GameObject txtEstrela;

	private int currentSertao;

	public GameObject imgSertao;
	public GameObject cadeado;
	public Sprite sertao1;
	public Sprite sertao2;

	private CreateDB DB;

	// Use this for initialization
	void Start () {
		DB = FindObjectOfType (typeof(CreateDB)) as CreateDB;
		currentSertao = 1;
		txtEstrela.GetComponent<Text> ().text = DB.getEstrelas (1).ToString();
	}

	// Update is called once per frame
	void Update () {
		// definir estrelas
		if (currentSertao != PlayerPrefs.GetInt("sertao")) {
			currentSertao = PlayerPrefs.GetInt("sertao");

			txtEstrela.GetComponent<Text> ().text = DB.getEstrelas (currentSertao).ToString();
		}

		txtSertao.GetComponent<Text>().text = "Sertão " + PlayerPrefs.GetInt("sertao");
		txtSertaoLevel.GetComponent<Text>().text = "Sertão " + PlayerPrefs.GetInt("sertao");

		// definir imagem do sertao
		switch (PlayerPrefs.GetInt("sertao")) {
			case 1 :
			//PlayerPrefs.SetInt("estrelasTotais", 0);
			imgSertao.GetComponent<Image> ().sprite = sertao1;
			break;

			case 2 :
			imgSertao.GetComponent<Image> ().sprite = sertao2;
			break;
		}
	}
}
