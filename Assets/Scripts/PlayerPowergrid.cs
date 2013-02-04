using System;

public class PlayerPowergrid : Powergrid
{
	public NPCPowergrid windPowergrid;
	public NPCPowergrid solarPowergrid;
	public HydroPlant hydroPlant;
	
	
	public override void ProduceLessEnergy ()
	{
		throw new NotImplementedException ();
	}
	
	public override void ProduceMoreEnergy ()
	{
		throw new NotImplementedException ();
	}
}

