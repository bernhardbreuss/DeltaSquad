using UnityEngine;

public class PlayerPowergrid : Powergrid
{
	public NPCPowergrid windPowergrid;
	public NPCPowergrid solarPowergrid;
	public HydroPlant hydroPlant;
	
	public float Euro = 10;
	public float FrequencyTolerance = 1.0f;
	public float DamageFactor = 3.0f;
	
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
	}
	
	//To decrease or increase the money by a certain amount.
	public void changeAmountEuro(float amount){ 
		Euro += amount;
	}
	
	protected override void Update ()
	{
		base.Update ();
		
		float tempFrequency = Mathf.Abs(50.0f - Frequency);
		if (Mathf.Abs(50.0f - Frequency) > FrequencyTolerance) {
			hydroPlant.Health -= (tempFrequency - FrequencyTolerance) * Time.deltaTime * DamageFactor;
		}
	}
	
	public override void ResetGrid() {
		
		base.ResetGrid();
		
		windPowergrid.ForeignEnergy = 0.0f;
		solarPowergrid.ForeignEnergy = 0.0f;
		ForeignEnergy = 0.0f;
		hydroPlant.Stop();
		
	}
}
