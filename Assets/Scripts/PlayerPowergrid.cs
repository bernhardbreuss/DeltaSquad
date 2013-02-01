using System;

public class PlayerPowergrid : Powergrid
{
	private NPCPowergrid _windPowergrid;
	private NPCPowergrid _solarPowergrid;
	private HydroPlant _hydroPlant;
	
	
	public override void ProduceLessEnergy ()
	{
		throw new NotImplementedException ();
	}
	
	public override void ProduceMoreEnergy ()
	{
		throw new NotImplementedException ();
	}
}

