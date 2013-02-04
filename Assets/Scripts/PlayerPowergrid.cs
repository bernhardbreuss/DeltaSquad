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

