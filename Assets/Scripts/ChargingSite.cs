using UnityEngine;
using System.Collections;

public class ChargingSite: MonoBehaviour {
	
	private bool isOccupied = false;
	public PlayerPowergrid powergrid;
	
	private float chargeStationCost = 10;
	
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
		if (!isOccupied && powergrid.Euro >= chargeStationCost && !powergrid.hydroPlant.GameOver) {
			renderer.material.SetColor ("_Color", hoverColour);
		}
		else
			renderer.material.SetColor("_Color", colour);
			
	}
		
	void OnMouseExit()
	{
		renderer.material.SetColor ("_Color", colour);
	}	
	
	void OnMouseDown()
	{
		if(!isOccupied && powergrid.Euro >= chargeStationCost && !powergrid.hydroPlant.GameOver)
		{
			isOccupied = true;
			AddChargingStation();
		}
	}
	
	void AddChargingStation()
	{
		Vector3 position = transform.position;
		position.y += 30;
		
		powergrid.changeAmountEuro(-chargeStationCost);
		Instantiate(chargingStation, position, chargingStation.rotation);
		chargingStation.GetComponent<ChargingStation>().SetPowergrid(powergrid);				
		//Destroy(gameObject);
	}


}
