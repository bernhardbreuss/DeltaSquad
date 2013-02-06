using UnityEngine;
using System.Collections;

public class VisualizeCharging : MonoBehaviour {
 // Use this for initialization
    void Start () {
        renderer.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        if(renderer.enabled){
            
        }
    }
    public void startAnimation(){ 
        renderer.enabled = true;
    }
    public void stopAnimation(){
        renderer.enabled = false;
    }
}
