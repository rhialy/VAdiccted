using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Soundbehavior : Main {
	public AudioClip Footsteps;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}
	//zum Abspielen eines Sounds wannimmer erwünscht.

	public void PlaySound(AudioClip clip){
		AudioSource audio;
		audio = GetComponent<AudioSource> ();
		if(!audio.isPlaying){
			audio.clip=clip;
			audio.Play();
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