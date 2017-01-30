using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawCenario : MonoBehaviour {

	public float minRateSpaw;
	public float maxRateSpaw;
	private float rateSpaw;
	public int max;
	
	private float currentRateSpaw;
	
	public GameObject cenario;
	public List<GameObject> cenarios;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i <= max; i++) {
			GameObject tmpCen = Instantiate(cenario) as GameObject;
			tmpCen.SetActive(false);
			cenarios.Add(tmpCen);
		}
		rateSpaw = Random.Range(minRateSpaw, maxRateSpaw);
	}
	
	// Update is called once per frame
	void Update () {
		currentRateSpaw += Time.deltaTime;
		if (currentRateSpaw > rateSpaw) {
			currentRateSpaw = 0;
			spaw ();
			rateSpaw = Random.Range(minRateSpaw, maxRateSpaw);
		}
	}
	
	private void spaw() {
		
		GameObject tmpCen = null;
		// procurar cenario inativo para serem lancados
		for (int i = 0; i <= max; i++) {
			if (cenarios[i].activeSelf == false) {
				tmpCen = cenarios[i];
				break;
			}
		}
		
		if (tmpCen != null) {
			tmpCen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			tmpCen.SetActive(true);
		}
	}
}
