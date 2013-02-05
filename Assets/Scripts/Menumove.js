//private var go : GameObject;
//private var cam : GameObject;
//private var start:GameObject;
//
//function Awake(){
//	go = gameObject;
//	cam = camera.main.gameObject;
//	start= GameObject.FindGameObjectWithTag("NewGame");
//	
//}
//
//function OnMouseEnter(){
//
//	if (gameObject.tag	== "NewGame")
//	{
//		renderer.material.color = Color.blue ;
//	}	
//
//	if (gameObject.tag == "Instructions")
//	{
//		renderer.material.color = Color.blue ;
//	}
//	
//	if(gameObject.tag == "Credits")
//	{
//		renderer.material.color = Color.blue ;
//	}
//	
//	if (gameObject.tag	== "Exit")
//	{
//		renderer.material.color = Color.red ;
//	}
//
//}
//
//function OnMouseExit(){
//	
//	if (gameObject.tag	== "NewGame")
//	{
//		renderer.material.color = Color.white;
//	}	
//
//	if (gameObject.tag == "Instructions")
//	{
//		renderer.material.color = Color.white;
//	}
//	if(gameObject.tag == "Credits")
//	{
//		renderer.material.color = Color.white;
//	}
//	if (gameObject.tag	== "Exit")
//	{
//		renderer.material.color = Color.white ;
//		//yield WaitForSeconds (2.5);
//		//Application.Quit();
//	}
//
//}
//
//
//function OnMouseDown(){
//
//	
//	//iTween.MoveTo(go,{"x":134, "time":1.5, "transition":"easeInExpo"});
//	//iTween.ColorTo(go,{"r":3, "g":5, "b":1.2, "time":5});
//	iTween.RotateFrom(gameObject,{ "time":2, "transition":"easeInExpo"});
//	//iTween.shake(start,{"z":5, "time":1, "delay":2});
//	
//	if (gameObject.tag	== "NewGame")
//	{
//		//yield WaitForSeconds (2.5);
//		//iTween.shake(cam,{"z":5, "time":1, "delay":2});
//		
//		//Application.LoadLevel(1);
//
//	}	
//
//	if (gameObject.tag == "Instructions")
//	{	
//		Application.LoadLevel(2);
//		Debug.Log("Continue function not working ATM");
//	}
//	
//	if(gameObject.tag == "Credits")
//	{
//		Application.LoadLevel(3);
//		Debug.Log("Tutorial button clicked");
//	}
//	
//	if (gameObject.tag	== "Exit")
//	{
//		yield WaitForSeconds (2.5);
//		Application.Quit();
//	}
//}