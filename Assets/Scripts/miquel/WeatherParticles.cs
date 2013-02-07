using UnityEngine;
using System.Collections;

public class WeatherParticles : MonoBehaviour {
	
	private GameObject clouds;
	private GameObject rain;
	
	// Use this for initialization
	void Start () {
	clouds = GameObject.Find("clouds");
	rain = GameObject.Find("rain");
	clouds.particleEmitter.emit = false;
	rain.particleEmitter.emit = false;
	}
	
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKeyDown("1")) {
			clouds.particleEmitter.emit = true;
			rain.particleEmitter.emit = true;
		}
		 if (Input.GetKeyDown("2")){
			clouds.particleEmitter.emit = false;
			rain.particleEmitter.emit = false;
		}
		//if (Input.GetKeyDown("3"))
			//rain.particleEmitter.emit = true;
			
		
		 //if (Input.GetKeyDown("4"))
			//rain.particleEmitter.emit = false;
			
	}
}
