using UnityEngine;
using System.Collections;

public class VisualizeCharging : MonoBehaviour {
	public float turns = 2520.0f;
	public float counter = 0f;
	public float degrees = 126.0f;
 // Use this for initialization
    void Start () {
        renderer.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        if(renderer.enabled && counter < turns){
			counter += degrees;
			gameObject.transform.Rotate(0f,degrees,0f);
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
