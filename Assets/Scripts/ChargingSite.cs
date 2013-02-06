using UnityEngine;
using System.Collections;

public class ChargingSite: MonoBehaviour {
	
	private bool isOccupied = false;
	public PlayerPowergrid powergrid;
	
	public float chargeStationCost = 100;
	
	public Transform chargingStation;
	
	public UnityEngine.Color colour;
	public UnityEngine.Color hoverColour;
	
	// Use this for initialization
	void Start () 
	{		
    	// Switch to the transparent diffuse shader
    	renderer.material.shader = Shader.Find ("Transparent/Diffuse");
    
		renderer.material.SetColor("_Color", colour);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseOver () 
	{
		renderer.material.SetColor ("_Color", hoverColour);    
	}
		
	void OnMouseExit()
	{
		renderer.material.SetColor ("_Color", colour);
	
	}	
	
	void OnMouseDown()
	{
		if(!isOccupied)
		{
			isOccupied = true;
			AddChargingStation();
		}
	}
	
	void AddChargingStation()
	{
		powergrid.changeAmountEuro(-chargeStationCost);
		Instantiate(chargingStation, transform.position, transform.rotation);
		
				
		
	}


}
