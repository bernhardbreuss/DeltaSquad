using UnityEngine;
using System.Collections;

public class CameraPathCredits : MonoBehaviour {
	
	// public GameObject target ;

	// Use this for initialization
	IEnumerator Start () {
	iTween.MoveTo(gameObject,iTween.Hash("path",iTweenPath.GetPath("Start"),"time",30,"easetype",iTween.EaseType.easeInOutSine));
	yield return StartCoroutine(waitforscene());
	}
	
	// Update is called once per frame
	void Update () {
	//Camera.main.transform.LookAt (target.transform);
		
	}
	
	IEnumerator waitforscene(){
		yield return new WaitForSeconds(30);
		Application.LoadLevel(1);
	}
}
