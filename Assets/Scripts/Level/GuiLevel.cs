using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiLevel : MonoBehaviour {

	private Level level;

	public int id;
	public GameObject txtRecorde;
	public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;
	public GameObject cadeado;
	public Sprite estrela;
	public Sprite localEstrela;
	private bool bloqueio;
	public string nomeLevel;

	private int currentSertao;

	private CreateDB DB;	
	private NavSertao navSertao;

	// Use this for initialization
	void Start () {
		nomeLevel = "recordeLevel" + id;

		DB = FindObjectOfType (typeof(CreateDB)) as CreateDB;
		navSertao = FindObjectOfType (typeof(NavSertao)) as NavSertao;
		currentSertao = 1;

		this.level = DB.getLevel(id, currentSertao);
		//print ("level " + level.Id);

		PlayerPrefs.SetInt(nomeLevel, level.Recorde);
		atualizar ();
	}
	
	// Update is called once per frame
	void Update () {
		//print ("Sertao ID " + PlayerPrefs.GetInt ("sertao"));
		if (currentSertao != PlayerPrefs.GetInt("sertao") && PlayerPrefs.GetInt("sertao") != 0) {
			//print ("LoadDB " + DB.loadDB);

			currentSertao = PlayerPrefs.GetInt("sertao");
			this.level = DB.getLevel(id, currentSertao);

			PlayerPrefs.SetInt(nomeLevel, level.Recorde);
			atualizar ();
		}

		if (id != 1) { 
			string tmpNomeLevel = "recordeLevel" + (id - 1);
			//print ("level base de bloqueio " + PlayerPrefs.GetInt (nomeLevel));
			if (PlayerPrefs.GetInt(tmpNomeLevel) > level.Bloqueio) {
				bloqueio = false;
				cadeado.SetActive(false);
			} else {
				bloqueio = true;
				cadeado.SetActive(true);
			}
		} else {
			bloqueio = false;
			cadeado.SetActive(false);
		}

	}

	public void atualizar() {
		txtRecorde.GetComponent<Text>().text = level.Recorde.ToString();
		print (level.Numero);
		// estrelas
		if (level.Estrela >= 1) {
			estrela2.GetComponent<Image>().sprite = estrela;
		} else {
			estrela2.GetComponent<Image>().sprite = localEstrela;
		}
		if (level.Estrela >= 2) {
			estrela3.GetComponent<Image>().sprite = estrela;
		} else {
			estrela3.GetComponent<Image>().sprite = localEstrela;
		}
		if (level.Estrela == 3) {
			estrela1.GetComponent<Image>().sprite = estrela;
		} else {
			estrela1.GetComponent<Image>().sprite = localEstrela;
		}

	}

	public void selectLevel() {
		if (bloqueio == false) {
			SoundController.playSound(soundGame.click);
			navSertao.selectLevel (id);
		} else {
			SoundController.playSound(soundGame.bloq);
		}
	}
}
