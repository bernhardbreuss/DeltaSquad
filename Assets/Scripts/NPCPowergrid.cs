using UnityEngine;

public class NPCPowergrid : Powergrid
{
	public float SellingFrequency = 50.5f;
	public float BuyingFrequency = 49.5f;
	
	private float MoneyFactor = 1.0f;
	private float TradeFee = 0.1f;
	private float MaxHz = 52.0f;
	
	public PlayerPowergrid PlayerPowergrid;
	public Weather weather;
	
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
		
		if (difference > 0.0f) {
			// Player is sellying energy to the NPC
			if (OwnFrequency >= SellingFrequency) {
				if (ForeignEnergy < 0.0f) {
					if ((ForeignEnergy + difference) > 0.0f) {
						difference = -ForeignEnergy;
					}
				} else {
					return;
				}
			} else if (Frequency >= SellingFrequency) {
				return;
			}
		} else if (difference < 0.0f) {
			// Player buying energy from NPC
			if (OwnFrequency < BuyingFrequency) {
				if (ForeignEnergy > 0.0f) {
					if ((ForeignEnergy + difference) < 0.0f) {
						difference = -ForeignEnergy;
					}
				} else {
					return;
				}
			} else if (Frequency < BuyingFrequency) {
				return;
			}
		} else {
			return;
		}
						
		if ((PlayerPowergrid.ProducedEnergy + PlayerPowergrid.ForeignEnergy - difference) < 0.0f) {
			// to less energy
			return;
		}
		
		ForeignEnergy += difference;
		PlayerPowergrid.ForeignEnergy -= difference;
	}
	
	protected override void Start ()
	{
		base.Start ();
		ProducedEnergy -= 20f;
	}
	
	protected override void Update ()
	{
		base.Update ();
		
		if (ForeignEnergy == 0.0f) {
			return;
		}
		
		float money = 0.0f;
		
		if (ForeignEnergy  < 0.0f) {
			money = ((MaxHz - OwnFrequency) * -MoneyFactor);
		} else if (ForeignEnergy > 0.0f) {
			money = ((50.0f - OwnFrequency) * MoneyFactor);
		}
		
		money -= TradeFee;		
		money *= Time.deltaTime;
		
		if ((PlayerPowergrid.Euro + money) < 0.0f) {
			PlayerPowergrid.ForeignEnergy += ForeignEnergy;
			ForeignEnergy = 0.0f;
		} else {	
			PlayerPowergrid.changeAmountEuro(money);
		}
	}
	
	protected override void ResetGrid(){
		base.ResetGrid();
		weather.Reset();
	}
}

