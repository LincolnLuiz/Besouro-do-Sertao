using UnityEngine;
using System.Collections;

public class moveOffset : MonoBehaviour {

	private Material currentMaterial;
	public float speedX;
	public float speedY;
	private float offsetX;
	private float offsetY;

	// Use this for initialization
	void Start () {
		currentMaterial = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1) {
			if (speedX != 0) {
				offsetX = Time.time * speedX;
				currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (offsetX, 0));
			}

			if (speedY != 0) {
				offsetY = Time.time * speedY;
				currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (0, offsetY));
			}
		}
	}
}
