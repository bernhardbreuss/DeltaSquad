using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	
	public AudioClip Gameover;
	public AudioClip Weather;
	public AudioClip Hp50;
	public AudioClip Hp25;
	public AudioClip Hp10;
	public AudioClip Honking;
	public AudioClip Reservoir;
	public AudioClip BuildChargingStation;
	
	public static AudioManager Get { get; set; }
	
	public AudioManager ()
	{
		Get = this;
	}
	
	// Use this for initializationusic

	public enum SoundEffects
	{
		Gameover,
		Weather,
		Reservoir,
		Hp50,
		Hp25,
		Hp10,
		Honking,
		BuildChargingStation
	}
	
	public void playSound (SoundEffects sound)
	{
		switch (sound) {
		case SoundEffects.Gameover:
			audio.PlayOneShot(Gameover);
			break;
		case SoundEffects.Weather:
			audio.PlayOneShot(Weather);
			break;
		case SoundEffects.Reservoir:
			audio.PlayOneShot(Reservoir);
			break;
		case SoundEffects.Hp50:
			audio.PlayOneShot(Hp50);
			break;
		case SoundEffects.Hp25:
			audio.PlayOneShot(Hp25);
			break;
		case SoundEffects.Hp10:
			audio.PlayOneShot(Hp10);
			break;
		case SoundEffects.Honking:
			audio.PlayOneShot(Honking);
			break;
		case SoundEffects.BuildChargingStation:
			audio.PlayOneShot(BuildChargingStation);
			break;
		default:
			Debug.LogWarning("Unknown sound  " + sound.ToString());
			break;
		}
	}
  

	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void Start ()
	{
		//audio.PlayOneShot(alert);	
	}
}
