using UnityEngine;
using System.Collections;

public class VisualizeCharging : MonoBehaviour {
	
	public float degrees = 30f;
	
 // Use this for initialization
    void Start () {
    	stopAnimation();
	}
    
    // Update is called once per frame
    void Update () {
        if(renderer.enabled){
			
			gameObject.transform.Rotate(0f,0f,degrees * Time.deltaTime * 15);
        }
    }
    public void startAnimation(){ 
        renderer.enabled = true;
    }
    public void stopAnimation(){
        renderer.enabled = false;
    }
}
// public GameObject visualCharging;
// visualCharging.GetComponent<VisualizeCharging>().stopAnimation();
// visualCharging.GetComponent<VisualizeCharging>().startAnimation();
