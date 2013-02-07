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
		WaveManager wm = (WaveManager) GameObject.FindObjectOfType(typeof(WaveManager));
		if (!isOccupied && powergrid.Euro >= (chargeStationCost * (wm.builtChargeStations+1)) && !powergrid.hydroPlant.GameOver) {
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
		WaveManager wm = (WaveManager) GameObject.FindObjectOfType(typeof(WaveManager));
		if(!isOccupied && powergrid.Euro >= (chargeStationCost * (wm.builtChargeStations+1)) && !powergrid.hydroPlant.GameOver)
		{
			isOccupied = true;
			AddChargingStation();
		}
	}
	
	void AddChargingStation()
	{
		WaveManager wm = (WaveManager) GameObject.FindObjectOfType(typeof(WaveManager));
		wm.builtChargeStations++;
		Vector3 position = transform.position;
		position.y += 30;	
		
		Transform chargeStation = Instantiate(chargingStation, position, chargingStation.rotation) as Transform;
		chargeStation.GetComponent<ChargingStation>().SetPowergrid(powergrid);		

		powergrid.changeAmountEuro(-chargeStationCost * wm.builtChargeStations);
	}


}
