using UnityEngine;

public class PlayerPowergrid : Powergrid
{
	public float EnergyChange = 10.0f;
	public int euro = 10;
	
	public NPCPowergrid windPowergrid;
	public NPCPowergrid solarPowergrid;
	public HydroPlant hydroPlant;
	
	public override void ProduceLessEnergy ()
	{
		UpdatePlant(-1);
	}
	
	public override void ProduceMoreEnergy ()
	{
		UpdatePlant (1);
	}
	
	private void UpdatePlant(int factor) {
		float difference = (factor * Time.deltaTime * EnergyChange);
		ProducedEnergy = (ProducedEnergy + difference);
		
		if (ProducedEnergy > ConsumedEnergy) {
			hydroPlant.Pump();
		} else {
			hydroPlant.GenerateEnergy();
		}
	}
	
	//To decrease or increase the money by a certain amount.
	public void changeAmountEuro(int amount){ 
		euro += amount;
	}
	
}

