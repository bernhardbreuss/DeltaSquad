using UnityEngine;
using System.Collections.Generic;

public class Health: MonoBehaviour {	
	
	private float _maxHealth = 100;
	private float _minHealth = 0;	
	private float _currentHealth = 100;
	
	void Start () 
	{		
	}
	
	public float CurrentHealth
    {
		get
		{
		    return this._currentHealth;
		}
		set
		{
		    this._currentHealth = value;
		}
    }
	
	public void DecreaseHealth(float amount) 
	{
		if(_minHealth > 0)
			_currentHealth -= amount;		
	}
	
	public void ResetHealth() 
	{
		_currentHealth = _maxHealth;		
	}
	

}
