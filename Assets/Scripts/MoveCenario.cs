using UnityEngine;
using System.Collections;

public class MoveCenario : MonoBehaviour {

	public float speed;

	private GameController game;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.status == GameStatus.PLAY || game.status == GameStatus.TUTORIAL) {
			transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
			
			if (transform.position.x <= -4.5) {
				// fim do objeto
				this.gameObject.SetActive(false);
			}
		}
	}
}
