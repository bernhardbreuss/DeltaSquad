using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Texture2D HzBar;
	public Texture2D HzCurrent;
		
	public Vector2 HzBarOffset = new Vector2(8.0f, 7.0f);
	public Vector2 HzBarSize = new Vector2(15.0f, 137.0f);
	
	public float MinHz = 48.0f;
	public float MaxHz = 52.0f;
	
	public GUIStyle ButtonIncreaseOwn;
	public GUIStyle ButtonDecreaseOwn;
	public GUIStyle ButtonIncreaseWind;
	public GUIStyle ButtonDecreaseWind;
	public GUIStyle ButtonIncreaseSolar;
	public GUIStyle ButtonDecreaseSolar;
	
	private GUIStyle ButtonIncreaseOwnDown;
	private GUIStyle ButtonDecreaseOwnDown;
	
	public GUIStyle LabelEuro;
		
	public KeyCode IncreaseOwnKey = KeyCode.W;
	public KeyCode DecreaseOwnKey = KeyCode.S;
	public KeyCode IncreaseWindKey = KeyCode.Q;
	public KeyCode DecreaseWindKey = KeyCode.A;
	public KeyCode IncreaseSolarKey = KeyCode.O;
	public KeyCode DecreaseSolarKey = KeyCode.L;
	
	public PlayerPowergrid PlayerPowergrid;
	public NPCPowergrid WindPowergrid;
	public NPCPowergrid SolarPowergrid;
	
	private int _buttonWidth;
	private int _buttonHeight;
	
	private delegate void PressDelegate();
	
	private Buttons _ownButtons;
	private Buttons _windButtons;
	private Buttons _solarButtons;
	
	private class Buttons {
		public GUIStyle increaseNormal;
		public GUIStyle increaseActive;
		public GUIStyle increaseCurrent;
		public GUIStyle decreaseNormal;
		public GUIStyle decreaseActive;
		public GUIStyle decreaseCurrent;
	}
	
	// Use this for initialization
	void Start () {
		_ownButtons = CreateButtonStruct(ButtonIncreaseOwn, ButtonDecreaseOwn);
		_windButtons = CreateButtonStruct(ButtonIncreaseWind, ButtonDecreaseWind);
		_solarButtons = CreateButtonStruct(ButtonIncreaseSolar, ButtonDecreaseSolar);
		
		_buttonWidth = ButtonIncreaseOwn.normal.background.width;
		_buttonHeight = ButtonIncreaseOwn.normal.background.height;
		
	}
	
	private Buttons CreateButtonStruct(GUIStyle increase, GUIStyle decrease) {
		Buttons buttons = new Buttons();
		
		buttons = new Buttons();
		buttons.increaseNormal = increase;
		buttons.increaseActive = new GUIStyle(increase);
		buttons.increaseCurrent = buttons.increaseActive;
		buttons.decreaseNormal = decrease;
		buttons.decreaseActive = new GUIStyle(decrease);
		buttons.decreaseCurrent = buttons.decreaseNormal;
		
		buttons.increaseActive.normal.background = buttons.increaseActive.active.background;
		buttons.decreaseActive.normal.background = buttons.decreaseActive.active.background;
		
		return buttons;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		HzBarGroup(0, (Screen.height - HzBar.height), PlayerPowergrid.Frequency, _ownButtons, IncreaseOwnKey, DecreaseOwnKey, PlayerPowergrid.ProduceMoreEnergy, PlayerPowergrid.ProduceLessEnergy);
		
		HzBarGroup(0, 0, WindPowergrid.Frequency, _windButtons, IncreaseWindKey, DecreaseWindKey, WindPowergrid.ProduceMoreEnergy, WindPowergrid.ProduceLessEnergy);
		
		HzBarGroup((Screen.width - HzBar.width - (2 * _buttonWidth)), 0, SolarPowergrid.Frequency, _solarButtons, IncreaseSolarKey, DecreaseSolarKey, SolarPowergrid.ProduceMoreEnergy, SolarPowergrid.ProduceLessEnergy);
		
		GUI.Label(new Rect(0, 10, Screen.width, 30), PlayerPowergrid.Euro.ToString("#,##0.00 $"), LabelEuro);
	}
	
	private void HzBarGroup(float x, float y, float hz, Buttons buttons, KeyCode increaseKey, KeyCode decreaseKey, PressDelegate increase, PressDelegate decrease) {
		GUILayout.BeginArea(new Rect(x, y, Screen.width / 2, Screen.height / 2));
		
		GUI.DrawTexture(new Rect(0, 0, HzBar.width, HzBar.height), HzBar);
		float hzPos = GetHzCurrentPositionY(hz);
		GUI.DrawTexture(new Rect(HzBarOffset.x, (hzPos - (HzCurrent.height / 2)), HzCurrent.width, HzCurrent.height), HzCurrent);
		
		Rect buttonPos = new Rect(HzBar.width, (HzBar.height - _buttonHeight), _buttonWidth, _buttonHeight);
		if (GUI.RepeatButton(buttonPos, "", buttons.increaseCurrent) || Input.GetKey(increaseKey)) {
			buttons.increaseCurrent = buttons.increaseActive;
			increase();
		} else {
			buttons.increaseCurrent = buttons.increaseNormal;
		}
		
		buttonPos.x += _buttonWidth;
		if (GUI.RepeatButton(buttonPos, "", buttons.decreaseCurrent) || Input.GetKey(decreaseKey)) {
			buttons.decreaseCurrent = buttons.decreaseActive;
			decrease();
		} else {
			buttons.decreaseCurrent = buttons.decreaseNormal;
		}
		
		GUI.Label(new Rect(HzBar.width, (hzPos - 10), 60, 20), hz.ToString("0.#0") + "Hz");
		
		GUILayout.EndArea();
	}
	
	private float GetHzCurrentPositionY(float hz) {
		hz = Mathf.Max(hz, MinHz);
		hz = Mathf.Min(hz, MaxHz);
		
		hz -= MinHz;
		float range = (MaxHz - MinHz);
		
		float posY = (hz / range);
		if (posY < 0.5f) {
			posY = (0.5f + (0.5f - posY));
		} else {
			posY = (0.5f - (posY - 0.5f));
		}
		posY *= HzBarSize.y;
		
		return (HzBarOffset.y + posY);
	}
	
	private void IncreaseOwn() {
			// TODO: call PlayerPowergrid.ProduceMoreEnergy()
	}
	
	private void DecreaseOwn() {
			// TODO: call PlayerPowergrid.ProduceLessEnergy()
	}
}
