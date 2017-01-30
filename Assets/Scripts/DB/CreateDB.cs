using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var DS = new DataService ("besouro_do_sertao.db");
		DS.CreateDB ();
	}
	
	public int getEstrelas(int sertao) {
		var DS = new DataService ("besouro_do_sertao.db");
		return DS.getEstrelas(sertao);
	}

	public Level getLevel(int Numero, int IdSertao) {
		var DS = new DataService ("besouro_do_sertao.db");
		return DS.getLevel (Numero, IdSertao);
	}
}
