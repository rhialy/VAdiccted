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
	//zum Abspielen eines Sounds wannimmer erwünscht.

	public AudioSource PlaySound(AudioSource source){
		AudioSource audio;
		audio = source;
		if(!audio.isPlaying){
			audio.Play();
		}
		return audio;

	}
	public void StopSound(AudioSource source){
		AudioSource audio;
		audio = source;
		if (audio.isPlaying) {
			audio.Stop ();
		}
	}
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
/*
 * AudioSource.panStereo	(einstellen der herkunftsrichtung)
 * AudioSource.spatialBlend (2D oder 3D sound .0 bis 1.0)
 * AudioRolloffMode.Logarithmic (real world roll of)
 * PlayerSettings.PS3.soundPath
 * AudioListener.volume (0.0 bia 0.1)
 * 
 * 
public class ExampleClass : MonoBehaviour {
    public AudioClip impact;
    AudioSource audio;
    
    void Start() {
    	audio = GetComponent<AudioSource>();
 *audio.PlayOneShot(AudioClip clip, float volumeScale = 1.0F);
 * 
 * 
 * */