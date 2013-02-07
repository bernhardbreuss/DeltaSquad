using UnityEngine;
using System.Collections;

public class Menumove : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void OnMouseEnter() {
		if( gameObject.tag == "NewGame"){
			renderer.material.color = Color.cyan;
			iTween.MoveTo(gameObject,iTween.Hash("position",transform.position += Vector3.forward*-1.0f,"easetype",iTween.EaseType.easeInOutSine,"time",0.2f));
		
		}
		if(gameObject.tag == "Instructions"){
			renderer.material.color = Color.cyan;
			iTween.MoveTo(gameObject,iTween.Hash("position",transform.position += Vector3.forward*-1.0f,"easetype",iTween.EaseType.easeInOutSine,"time",0.2f));
		}
		if(gameObject.tag == "Credits"){
			renderer.material.color = Color.cyan;
			iTween.MoveTo(gameObject,iTween.Hash("position",transform.position += Vector3.forward*-1.0f,"easetype",iTween.EaseType.easeInOutSine,"time",0.2f));
		}
	}
	
	void OnMouseExit(){
		if( gameObject.tag == "NewGame"){
			iTween.MoveTo(gameObject,iTween.Hash("position",transform.position += Vector3.forward*1.0f,"easetype",iTween.EaseType.easeInOutSine,"time",.2f));
			renderer.material.color = Color.red;
		}
		if(gameObject.tag == "Instructions"){
			renderer.material.color = Color.red;
			iTween.MoveTo(gameObject,iTween.Hash("position",transform.position += Vector3.forward*1.0f,"easetype",iTween.EaseType.easeInOutSine,"time",.2f));
		}
		if(gameObject.tag == "Credits"){
			renderer.material.color = Color.red;
			iTween.MoveTo(gameObject,iTween.Hash("position",transform.position += Vector3.forward*1.0f,"easetype",iTween.EaseType.easeInOutSine,"time",.2f));
		}
	}
	
	
	 IEnumerator OnMouseDown(){
		if( gameObject.tag == "NewGame"){
			iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", 0.2f));
			
			yield return new WaitForSeconds(1);
			Application.LoadLevel(4);
		
		}
		if(gameObject.tag == "Instructions"){
			iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", 0.2f));
			yield return new WaitForSeconds(1);
			//Application.LoadLevel(3);
		}
		if(gameObject.tag == "Credits"){
			iTween.RotateBy(gameObject, iTween.Hash("x", .25, "easeType", "easeInOutBack", "loopType", "pingPong", "delay", 0.2f));
			yield return new WaitForSeconds(1);
			Application.LoadLevel(4);
		}
	}
	
	

	
}
