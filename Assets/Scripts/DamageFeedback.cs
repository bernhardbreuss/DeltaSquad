using UnityEngine;
using System.Collections.Generic;

public class DamageFeedback: MonoBehaviour {	
	
	public HydroPlant hydroPlant;
	
	public UnityEngine.Color colour;
	//private float defaultRed;
	
	private GameObject pump;
	private GameObject smoke;
	private GameObject smoke1;
	private GameObject smoke2;
	private GameObject light1;
	private GameObject light2;
	private GameObject light3;

	//private float health = this.GetComponent<HydroPlant>().Health;
	
	void Start () 
	{	
		pump = GameObject.Find("illwerkeBuilding");
		smoke = GameObject.Find("Fluffy Smoke Large");
		smoke1 = GameObject.Find("Fluffy Smoke Large1");
		smoke2 = GameObject.Find("Fluffy Smoke Large2");
		light1= GameObject.Find("light1");
		light2 = GameObject.Find("light2");
		light3 = GameObject.Find("light3");
		smoke.particleEmitter.emit = false;
		smoke1.particleEmitter.emit = false;
		smoke2.particleEmitter.emit = false;
		light1.light.enabled=false;
		light2.light.enabled=false;
		light3.light.enabled=false;
			

	}
	
	void Update() 
	{
		//this.GetComponent<HydroPlant>();
		ChangeColour();
		pump.renderer.material.SetColor("_Color", colour);
		
		EmitSmoke();
	
	}
	
	IEnumerator<YieldInstruction> flicker(){
		while (true) {
		light1.light.enabled=false;
		light2.light.enabled=false;
		light3.light.enabled=false;
		yield return new WaitForSeconds(0.2f);
		light1.light.enabled=true;
		light2.light.enabled=true;
		light3.light.enabled=true;
		yield return new WaitForSeconds(0.2f);
		}
		
	}
	
	void ChangeColour()
	{
		float temp = 100 - hydroPlant.Health;
		//colour.r = (temp/100);
		colour.g = (hydroPlant.Health/100);
		colour.b = (hydroPlant.Health/100);
	}
	
	void EmitSmoke()
	{
		if(hydroPlant.Health <= 30) {
			if (!smoke.particleEmitter.emit) {
				StartCoroutine(flicker());
			}
			smoke.particleEmitter.emit = true;
			smoke1.particleEmitter.emit = true;
			smoke2.particleEmitter.emit = true;
		} else {
			StopAllCoroutines();
			smoke.particleEmitter.emit = false;
			smoke1.particleEmitter.emit = false;
			smoke2.particleEmitter.emit = false;
		}
	}
	
}
