#pragma strict



function Start () {

}

function Update () {

}

function OnMouseDown(){
	if(gameObject.tag == "NewGame"){
	Application.LoadLevel(1);
	}
	if(gameObject.tag == "Instructions"){
	Application.LoadLevel(2);
	}
	if(gameObject.tag == "Credits"){
	Application.LoadLevel(3);
	}
	if(gameObject.tag == "Exit"){
	Application.Quit();
	}
}