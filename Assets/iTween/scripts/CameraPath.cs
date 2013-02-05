using UnityEngine;
using System.Collections;

public class CameraPath : MonoBehaviour {
	
	 public GameObject target ;

	// Use this for initialization
	IEnumerator Start () {
	iTween.MoveTo(gameObject,iTween.Hash("path",iTweenPath.GetPath("Camerazoom"),"time",15,"easetype",iTween.EaseType.easeInOutSine));
	yield return StartCoroutine(waitforscene());
	}
	
	// Update is called once per frame
	void Update () {
	Camera.main.transform.LookAt (target.transform);
	
	
		
	}
	
	IEnumerator waitforscene(){
		yield return new WaitForSeconds(15);
		Application.LoadLevel(3);
	}
}
