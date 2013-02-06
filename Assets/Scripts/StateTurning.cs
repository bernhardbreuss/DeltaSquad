using UnityEngine;
using System.Collections;

public class StateTurning : AbstractCar {
	public float turnAroundX;
    public float turnAroundZ;
	public float reach180;
	public float degrees;
	
	
	public  StateTurning(Car car):base(car)
	{
		Debug.Log("State Turning ---------------------------------------------------");
		reach180 = 0.0f;
		degrees = 8.196f;
		//turnAroundZ = -carSpeed;
		//turnAroundX = -180.0f;
		//degrees = 9f;		
	}		
	
	
	
	// Update is called once per frame
	public override void Update()
	{
		if(reach180 <= 172.116){
			//turnAroundZ += 20;
			//turnAroundX += 18;
			reach180 += degrees;
			
			_car.transform.Rotate(0f,degrees,0f);
			_car.transform.Translate(0f, 0f, -(carSpeed + 50) * Time.deltaTime);
			
		}
		else if(reach180 >= 172.116 && !carLooped){	
			carLooped = true;
			_car.ChangeState(new StateGoingBack(_car));
		}
		else if(reach180 >= 172.116 && carLooped){
			_car.ChangeState(new StateSearching(_car));
		}
		// car.transform.Translate(-10f * Time.deltaTime, 0f, 0f);
		//_car.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			//_car.transform.Rotate(Vector3.up*90,Space.Self);
			//_
			//_car.transform.Translate(0f, 0f, 0f);
			//-carSpeed * Time.deltaTime
		}
	
}



   
    