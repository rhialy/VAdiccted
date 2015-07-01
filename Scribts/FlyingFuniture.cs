using UnityEngine;
using System.Collections;

public class FlyingFuniture : MonoBehaviour {

	private bool LSD;
	private bool Heroine;
	private bool Ecstasy;
	private bool bodyGood;
	private bool soulGood;
	private int thirdQuestion;

	//Variables to save, if a Function is active
	private bool size=false;
	private bool fly=false;
	private bool jump=false;

	//The Number of things, that should react to the Functions
	private int anzahl;
	private int anzahl3;
	private int anzahl2;

	//Counter, to check these Number
	private int zaehler=0;
	private int zaehler2 = 0;
	private int zaehler3 = 0;

	private float c = 0;
	private int framerate=150;




	private Vector3 [] vecSize= new Vector3[27];
	private Vector3[] vec= new Vector3[27];
	//List of airworthy Objects
	public GameObject[] F;
	//List, to list the Objects, needed for the room to fall
	public GameObject[] Endlist;

	public GameObject boden;

	// Use this for initialization
	void Start () {
		//set a Startvector vor every used Object
		for (int y = 0; y<27; y++) {
			vec [y] = new Vector3 (0, 0.05F, 0);
			vecSize [y] = new Vector3 (0.2F, 0.2F, 0.2F);
		}
		LSD = Main.Parameters[0];
		Heroine = Main.Parameters[1];
		Ecstasy = Main.Parameters[2];
		bodyGood = Main.Parameters[3];
		soulGood = Main.Parameters[4];
		thirdQuestion = Main.getThirdQuestion();
	}
	
	// Update is called once per frame
	void Update () {

		if (size == true || fly == true || jump == true) {
			c += c + 1*Time.deltaTime;
		}
	
		//if one of the Functions is set active, this loops activates all Objects from the Lists
			if (size == true) {
					while (zaehler<anzahl) {
							vecSize[zaehler]=FunitureSize(vecSize[zaehler],F[zaehler]);
							zaehler+=2;
					}
					if(zaehler>=anzahl){
						zaehler=0;
					}
			}
			if (fly == true) {
					while (zaehler2<anzahl2) {
						vec [zaehler2] = FunitureFly (vec [zaehler2], F [zaehler2]);
						zaehler2 += 1;
					}
					if (zaehler2 == anzahl2) {
						zaehler2 = 0;
					}
			}
			if (jump == true) {
					while (zaehler3<anzahl3) {
						FunitureJumping (new Vector3 (0,0.03F,0), F [zaehler3]);
						zaehler3 += 1;

					}
					if (zaehler3 == anzahl3) {
						zaehler3 = 0;
					}
			}
	//	}
		 
	}
	//changes the size of the Funiture
	 private Vector3 FunitureSize(Vector3 V, GameObject g){
		if (LSD == true || Heroine == true || thirdQuestion==3) {
		if (c >= 1) {
			V = new Vector3 (Random.Range (-0.1F, 0.1F), Random.Range (-0.1F, 0.1F), Random.Range (-0.1F, 0.1F));
		}

		g.transform.localScale += V;
		
		if (c >= 4.0F) {
			c = 0;
		}
	
	}
		return V;
	}
	//lets the Funiture fly
	private Vector3 FunitureFly( Vector3 V,GameObject g){

		if (LSD==true){
			if(c>=2F){
				V=new Vector3 (Random.Range (-0.5F,0.5F),Random.Range (-0.5F,0.5F),Random.Range (-0.5F,0.5F));
			}
		if (c>= 4.0F) {
			c = 0F;
		}
			g.transform.position += V;
			}
		return V;
	}
	//lets the Funiture jump a little bit
	private Vector3 FunitureJumping( Vector3 V,GameObject g){
		
		if (LSD==true || thirdQuestion==1){
		g.transform.position += V;	
		}
		return V;
	}
	//ends the first szene 
	public void End(){
		foreach (GameObject g in Endlist) {
			Rigidbody r= g.GetComponent<Rigidbody>();
			//Transform t=g.GetComponent<Transform>();
			//r.AddExplosionForce(50,t.position,10);
			r.isKinematic=false;
		}
		Destroy (boden);
	}

	//Activatorfunctions 
	public void SizeSetActive(int i, bool b){
		if (b == true) {
			size = true;
		} else {
			size = false;
		}
		anzahl = i;

	}

	public void FlySetActive(int i, bool b){
		if (b == true) {
			fly = true;
		} else {
			fly = false;
		}
		anzahl2 = i;
	}
	public void JumpSetActive(int i,bool b){
		if (b == true) {
			jump = true;
		} else{
			jump = false;
	}
		anzahl3 = i;
	}

}
