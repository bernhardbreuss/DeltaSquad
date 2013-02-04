using UnityEngine;

public class PlayerPowergrid : Powergrid
{
	public float EnergyChange = 10.0f;
	
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
		float energy = (ProducedEnergy - ConsumedEnergy + difference);
		
		if (energy < 0) {
			ConsumedEnergy = energy;
			ProducedEnergy = 0;
			hydroPlant.Pump();
		} else {
			ConsumedEnergy = 0;
			ProducedEnergy = energy;
			hydroPlant.GenerateEnergy();
		}
	}
}

