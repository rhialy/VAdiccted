using UnityEngine;
using System.Collections;

public class FlyingFuniture : MonoBehaviour {

	private bool LSD;
	private bool Heroine;
	private bool Ecstasy;
	private bool bodyGood;
	private bool soulGood;
	private int thirdQuestion;

	private bool size=false;
	private int anzahl;
	int anzahl3;
	private bool fly=false;
	private int anzahl2;
	private int c = 0;
	private int zaehler=0;
	private int zaehler2 = 0;

	private bool jump=false;




	private Vector3[] vec= new Vector3[30];
	public GameObject[] F;

	// Use this for initialization
	void Start () {
		for (int y = 0; y<30; y++) {
			vec[y]=new Vector3 (0,0.05F,0);

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
		//if (LSD == true || Heroine == true) {
			c ++;

			if (size = true) {
				FunitureSize (anzahl);
			}

			if (fly = true) {
				while (zaehler<anzahl2) {
					vec [zaehler] = FunitureFly (vec [zaehler], F [zaehler]);
					zaehler += 1;
				}
				if (zaehler == anzahl2) {
					zaehler = 0;
				}
		}
		if (jump = true) {

			while (zaehler2<anzahl3) {
				FunitureJumping (new Vector3 (0,0.03F,0), F [zaehler2]);
				zaehler2 += 1;

			}
			if (zaehler2 == anzahl3) {
				zaehler2 = 0;
			}
			
		}
	//	}
		 
	}

	public void FunitureSize(int a){

				for(int i=0; i < a; i++){

			}

	}

	Vector3 FunitureFly( Vector3 V,GameObject g){
		//if LSD (maybe Heroin)
		//if (LSD==true){
			if(c>=175){
				V=new Vector3 (Random.Range (-0.1F,0.1F),Random.Range (-0.1F,0.1F),Random.Range (-0.1F,0.1F));
			}
		if (c > 200) {
			c = 0;
		}
			g.transform.position += V;
		return V;
			//}
	}

	Vector3 FunitureJumping( Vector3 V,GameObject g){
		//if LSD (maybe Heroin)
		//if (LSD==true){
		g.transform.position += V;
		return V;
		//}
	}


	public void SizeSetActive(int i){
		size=true;
		anzahl = i;
	}

	public void FlySetActive(int i){
		fly=true;
		anzahl2 = i;
	}
	public void JumpSetActive(int i){
		jump=true;
		anzahl3 = i;
	}

}
