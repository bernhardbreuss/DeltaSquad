using System;

public class NPCPowergrid : Powergrid
{
	public float SellingFrequency = 50.5f;
	public float BuyingFrequency = 49.5f;
	
	public PlayerPowergrid PlayerPowergrid;
	
	public override void ProduceLessEnergy ()
	{
		UpdateForeignEnergy(-1);
	}
	
	public override void ProduceMoreEnergy ()
	{
		UpdateForeignEnergy(1);
	}
	
	private void UpdateForeignEnergy(int factor)
	{
		float difference = (CurrentChange() * factor);
		
		if (Frequency >= SellingFrequency && difference > 0.0f) {
			return;
		}
		if (Frequency < BuyingFrequency && difference < 0.0f) {
			return;
		}
		
		if ((PlayerPowergrid.ProducedEnergy + PlayerPowergrid.ForeignEnergy - difference) < 0.0f) {
			return;
		}
		
		ForeignEnergy += difference;
		PlayerPowergrid.ForeignEnergy -= difference;	
	}
}

