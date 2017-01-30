using UnityEngine;
using System.Collections;

public class NavSertao : MonoBehaviour {

	public int currentSertao;
	public GameObject panelLoad;

	private int numeroSertao;

	public GameObject panelSertao;
	public GameObject panelLevels;

	private GuiSertao guiSertao;
	private CreateDB DB;

	// Use this for initialization
	void Start () {
		guiSertao = FindObjectOfType (typeof(GuiSertao)) as GuiSertao;
		DB = FindObjectOfType (typeof(CreateDB)) as CreateDB;
		currentSertao = 1;
		numeroSertao = 2;
	}
	
	// Update is called once per frame
	void Update () {
		//definir sertao
		PlayerPrefs.SetInt ("sertao", currentSertao);
		//print (currentSertao);
		if (Input.GetKeyDown(KeyCode.Escape) && panelSertao.GetComponent<Animator> ().GetBool("exit")) {
			panelSertao.GetComponent<Animator> ().SetBool("exit", false);
			panelSertao.GetComponent<Animator> ().SetBool("in", true);

		} else if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel ("menu");
		}

		if (Input.GetKeyDown(KeyCode.Escape) && panelLevels.GetComponent<Animator> ().GetBool("panel_in")) {
			panelLevels.GetComponent<Animator> ().SetBool("panel_in", false);
			panelLevels.GetComponent<Animator> ().SetBool("panel_out", true);
			panelSertao.GetComponent<Animator> ().SetBool("exit", false);
			panelSertao.GetComponent<Animator> ().SetBool("in", true);
		}
	}

	public void voltar () {
		panelLevels.GetComponent<Animator> ().SetBool("panel_in", false);
		panelLevels.GetComponent<Animator> ().SetBool("panel_out", true);
		panelSertao.GetComponent<Animator> ().SetBool("exit", false);
		panelSertao.GetComponent<Animator> ().SetBool("in", true);
	}

	public void prev() {
		if (currentSertao != 1) {
			currentSertao -= 1;
		} else {
			currentSertao = numeroSertao;
		}
	}

	public void next() {
		if (currentSertao < numeroSertao) {
			currentSertao += 1;
		} else {
			currentSertao = 1;
		}
	}

	public void selectSertao() {
		/// oculta sertoes
		panelSertao.GetComponent<Animator> ().SetBool("in", false);
		panelSertao.GetComponent<Animator> ().SetBool("exit", true);
		// exibe leveis
		panelLevels.GetComponent<Animator> ().SetBool("panel_in", true);
		panelLevels.GetComponent<Animator> ().SetBool("panel_out", false);
	}

	public void selectLevel(int Id) {
		panelLoad.SetActive(true);
		// definir variaveis para o level
		Level level = DB.getLevel(Id, currentSertao);

		PlayerPrefs.SetInt ("levelId", level.Id);
		PlayerPrefs.SetInt ("levelIdSertao", level.IdSertao);
		PlayerPrefs.SetInt ("levelNumero", level.Numero);
		PlayerPrefs.SetInt ("levelRecorde", level.Recorde);
		PlayerPrefs.SetInt ("levelEstrela", level.Estrela);
		PlayerPrefs.SetInt ("levelEstrela1", level.Estrela1);
		PlayerPrefs.SetInt ("levelEstrela2", level.Estrela2);
		PlayerPrefs.SetInt ("levelEstrela3", level.Estrela3);
		PlayerPrefs.SetInt ("levelTempo", level.Tempo);
		PlayerPrefs.SetFloat ("levelRateSpaw", level.RateSpaw);
		PlayerPrefs.SetFloat ("levelSpace", level.Espaco);
		PlayerPrefs.SetFloat ("levelVelocidade", level.Velocidade);

		Application.LoadLevel ("play");
	}
}
