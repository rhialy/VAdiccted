using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Soundbehavior : MonoBehaviour {

	private bool LSD;
	private bool Heroine;
	private bool Ecstasy;
	private bool bodyGood;
	private bool soulGood;
	private int thirdQuestion;

	// Use this for initialization
	void Start () {
		// Initialize the Main parameters
		LSD = Main.Parameters[0];
		Heroine = Main.Parameters[1];
		Ecstasy = Main.Parameters[2];
		bodyGood = Main.Parameters[3];
		soulGood = Main.Parameters[4];
		thirdQuestion = Main.getThirdQuestion();
	}
	
	// Update is called once per frame
	void Update () {


	}
	//Play a Sound whenever you want,without repeating itself while  playing

	public AudioSource PlaySound(AudioSource source){
		AudioSource audio;
		audio = source;
		if(!audio.isPlaying){
			audio.Play();
		}
		return audio;

	}
	//stop a playing sound 
	public void StopSound(AudioSource source){
		AudioSource audio;
		audio = source;
		if (audio.isPlaying) {
			audio.Stop ();
		}
	}
	//make the speed of a sound faster(and higher) or slower
	public void speed(AudioSource source, float Pitch,bool max){
		if (max == true) {
			if (source.pitch <= Pitch) {
				source.pitch += 0.1F;

			}
		} else {
			if (source.pitch >= Pitch) {
				source.pitch-=0.1F;
			}
		}
	}
}
