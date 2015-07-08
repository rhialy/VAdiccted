using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {

	public Light lt;

	private int firstCounter;
	private int secondCounter;

	// Use this for initialization
	void Start () {
		lt.GetComponent<Light> ();
		firstCounter = 0;
		secondCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (firstCounter <= 300) {
			lt.color -= Color.white / 3.0F * Time.deltaTime;
			firstCounter++;
		}
		if (firstCounter >= 300) {
			lt.color += Color.white / 3.0F * Time.deltaTime;
			secondCounter++;
		}
		if (firstCounter >= 300 && secondCounter >= 300) {
			firstCounter = 0;
			secondCounter = 0;
		}
	}
}
