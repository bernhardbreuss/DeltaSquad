using UnityEngine;
using System.Collections;

public abstract class Powergrid : MonoBehaviour {
	
	
	
	public int ConsumedEnergy { get; set; }
	public int ProducedEnergy { get; set; }
	public int ForeignEnergy { get; set; }
	public float Frequency { get { return 50 * (ProducedEnergy/ConsumedEnergy); } }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public abstract void ProduceMoreEnergy();
	public abstract void ProduceLessEnergy();
	
	
}
