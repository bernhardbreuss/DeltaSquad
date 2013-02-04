using UnityEngine;
using System.Collections;

public abstract class Powergrid : MonoBehaviour {
	
	/*
	 *  initial value for ConsumedEnergy and ProducedEnergy
	 */
	public float baseEnergy = 100f;
	public float ConsumedEnergy { get; set; }
	public float ProducedEnergy { get; set; }
	public float ForeignEnergy { get; set; }
	public float Frequency { get { return 50 * (ProducedEnergy/ConsumedEnergy); } }
	
	// Use this for initialization
	void Start () {
		ConsumedEnergy = baseEnergy;
		ProducedEnergy = baseEnergy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public abstract void ProduceMoreEnergy();
	public abstract void ProduceLessEnergy();
	
	
}
