<<<<<<< HEAD
using UnityEngine;

public class PlayerPowergrid : Powergrid
{
	public NPCPowergrid windPowergrid;
	public NPCPowergrid solarPowergrid;
	public HydroPlant hydroPlant;
	
	
	public override void ProduceLessEnergy ()
	{
		UpdatePlant(-1);
	}
	
	public override void ProduceMoreEnergy ()
	{
		UpdatePlant(1);
	}
	
	private void UpdatePlant(int factor) {
		float difference = (CurrentChange() * factor);
		
		if ((ProducedEnergy + difference + ForeignEnergy) < 0.0f) {
			return;
		}
		
		ProducedEnergy = (ProducedEnergy + difference);
		
		if (ProducedEnergy > ConsumedEnergy) {
			hydroPlant.Pump();
		} else {
			hydroPlant.GenerateEnergy();
		}
	}
}

=======
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

>>>>>>> 06a48d2b38d75d5504754e81a30e0cbc61a62f61
