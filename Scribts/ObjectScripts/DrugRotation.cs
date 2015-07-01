using UnityEngine;
using System.Collections;

public class DrugRotation : MonoBehaviour {

	public GameObject drug;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		drug.transform.Rotate(0f, 0.18f, 0f);
	}
}
