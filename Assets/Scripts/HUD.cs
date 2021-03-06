using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Texture2D HzBar;
	public Texture2D HzOwn;
	public Texture2D HzTotal;
	public GUIStyle HzOwnStyle;
	public GUIStyle HzTotalStyle;
		
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
	public GUIStyle ButtonReset;
	public GUIStyle ButtonRepair;
	public GUIStyle ButtonSkipNight;
	public GUIStyle ButtonMenu;
	
	private GUIStyle ButtonIncreaseOwnDown;
	private GUIStyle ButtonDecreaseOwnDown;
	
	public GUIStyle LabelEuro;
	public GUIStyle LabelHp;
	public GUIStyle LabelForeignPrice;
	public GUIStyle LabelNightDuration;
	public GUIStyle LabelGameOver;
		
	public KeyCode IncreaseOwnKey = KeyCode.W;
	public KeyCode DecreaseOwnKey = KeyCode.S;
	public KeyCode IncreaseWindKey = KeyCode.Q;
	public KeyCode DecreaseWindKey = KeyCode.A;
	public KeyCode IncreaseSolarKey = KeyCode.O;
	public KeyCode DecreaseSolarKey = KeyCode.L;
	
	public Texture2D WeatherWind;
	public Texture2D WeatherSolar;
	public Texture2D WeatherOverlay;
	
	public PlayerPowergrid PlayerPowergrid;
	public NPCPowergrid WindPowergrid;
	public NPCPowergrid SolarPowergrid;
	public WaveManager WaveManager;
	
	private int _buttonWidth;
	private int _buttonHeight;
		
	private Buttons _ownButtons;
	private Buttons _windButtons;
	private Buttons _solarButtons;
	
	float _hzBarWidth;
	float _ownBarX;
	float _ownBarY;
	
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
	
		
		_hzBarWidth = (HzBar.width + (2 * _buttonWidth));
		_ownBarX = ((Screen.width - _hzBarWidth) / 2);
		_ownBarY = (Screen.height - HzBar.height - _buttonHeight);
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
		if (PlayerPowergrid.hydroPlant.GameOver) {
			GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Over\nYour Score: " + PlayerPowergrid.Euro.ToString("0.#0") + " $", LabelGameOver);
			
			if (GUI.Button(new Rect(((Screen.width - ButtonMenu.normal.background.width) / 2), ((Screen.height / 2) - ButtonMenu.normal.background.height + 100), ButtonMenu.normal.background.width, ButtonMenu.normal.background.height), "", ButtonMenu)) {
				Application.LoadLevel(1);
				Time.timeScale = 1.0f;
			}
		} else {
			if (WaveManager.IsDay) {
				DayHud ();
			} else {
				NightHud();
			}
			GUI.Label(new Rect(_ownBarX + _hzBarWidth - _buttonWidth, _ownBarY, 50, 30), PlayerPowergrid.Euro.ToString("#,##0.00 $"), LabelEuro);
			GUI.Label(new Rect(_ownBarX + _hzBarWidth - _buttonWidth, _ownBarY + 30, Screen.width, 30), PlayerPowergrid.hydroPlant.Health.ToString("0 HP"), LabelHp);
		}
	}
	
	private void DayHud() {		
		HzBarGroup(_ownBarX, _ownBarY, _ownButtons, IncreaseOwnKey, DecreaseOwnKey, PlayerPowergrid);
		
		HzBarGroup(0, 0, _windButtons, IncreaseWindKey, DecreaseWindKey, WindPowergrid);
		
		HzBarGroup((Screen.width - _hzBarWidth), 0, _solarButtons, IncreaseSolarKey, DecreaseSolarKey, SolarPowergrid);
		
		if (GUI.Button(new Rect((_ownBarX + (2 * _buttonWidth)), (Screen.height - ButtonReset.normal.background.height), ButtonReset.normal.background.width, ButtonReset.normal.background.height), "", ButtonReset)) {
			PlayerPowergrid.ResetGrid();
		}
		
		DrawWeather(WeatherWind, _hzBarWidth, 0.0f, WindPowergrid.weather);
		DrawWeather(WeatherSolar, (Screen.width - _hzBarWidth - WeatherSolar.width), 0.0f, SolarPowergrid.weather);
	}
	
	private void NightHud() {
		if (GUI.RepeatButton(new Rect((_ownBarX + _hzBarWidth - _buttonWidth), (_ownBarY + 60), ButtonRepair.normal.background.width, ButtonRepair.normal.background.height), "", ButtonRepair)) {
			PlayerPowergrid.hydroPlant.Repair();
		}
		
		if (GUI.Button(new Rect(((Screen.width - ButtonSkipNight.normal.background.width) / 2), ((Screen.height / 2) - ButtonSkipNight.normal.background.height - 10), ButtonSkipNight.normal.background.width, ButtonSkipNight.normal.background.height), "", ButtonSkipNight)) {
			WaveManager.SkipNight();
		}
		
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Day in " + WaveManager.CurrentNightDuration.ToString("0.#0") + " Seconds", LabelNightDuration);
	}
	
	private void HzBarGroup(float x, float y, Buttons buttons, KeyCode increaseKey, KeyCode decreaseKey, Powergrid powergrid) {
		GUILayout.BeginArea(new Rect(x, y, Screen.width / 2, Screen.height / 2));
		
		GUI.DrawTexture(new Rect(0, 0, HzBar.width, HzBar.height), HzBar);
		
		//Own Hz
		float hzPos = GetHzCurrentPositionY(powergrid.OwnFrequency);
		GUI.DrawTexture(new Rect(HzBarOffset.x, (hzPos - (HzOwn.height / 2)), HzOwn.width, HzOwn.height), HzOwn);
		GUI.Label(new Rect(HzBar.width, (hzPos - (HzOwnStyle.fontSize / 2)), 60, 20), powergrid.OwnFrequency.ToString("0.#0") + "Hz", HzOwnStyle);
		
		//Total Hz
		hzPos = GetHzCurrentPositionY(powergrid.Frequency);
		GUI.DrawTexture(new Rect(HzBarOffset.x, (hzPos - (HzTotal.height / 2)), HzTotal.width, HzTotal.height), HzTotal);
		GUI.Label(new Rect(HzBar.width, (hzPos - (HzTotalStyle.fontSize / 2)), 60, 20), powergrid.Frequency.ToString("0.#0") + "Hz", HzTotalStyle);
				
		Rect buttonPos = new Rect(0, HzBar.height, _buttonWidth, _buttonHeight);
		if (GUI.RepeatButton(buttonPos, "", buttons.increaseCurrent) || Input.GetKey(increaseKey)) {
			buttons.increaseCurrent = buttons.increaseActive;
			powergrid.ProduceMoreEnergy();
		} else {
			buttons.increaseCurrent = buttons.increaseNormal;
		}
		
		buttonPos.x += _buttonWidth;
		if (GUI.RepeatButton(buttonPos, "", buttons.decreaseCurrent) || Input.GetKey(decreaseKey)) {
			buttons.decreaseCurrent = buttons.decreaseActive;
			powergrid.ProduceLessEnergy();
		} else {
			buttons.decreaseCurrent = buttons.decreaseNormal;
		}
		
		
		if (powergrid is NPCPowergrid) {
			GUI.Label(new Rect(HzBar.width, 0, (2 * _buttonWidth), 20), ((NPCPowergrid)powergrid).CurrentPrice().ToString("0.#0 $"), LabelForeignPrice);
		}
		
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
	
	private void DrawWeather(Texture2D texture, float x, float y, Weather weather) {
		float productionRate = (weather.EnergyProductionRate - Weather.MinEnergyProductionRate) / Weather.ProductionRateRange;
		float angle = 180.0f - (180.0f * productionRate);
		
		Vector2 pivot;
		pivot.x = (x + (texture.width / 2));
		pivot.y = (y + (texture.height / 2));
		
		Matrix4x4 matrix = GUI.matrix;
		GUIUtility.RotateAroundPivot(angle, pivot);
		GUI.DrawTexture(new Rect(x, y, texture.width, texture.height), texture);
		GUI.matrix = matrix;
		
		GUI.DrawTexture(new Rect(x, y, WeatherOverlay.width, WeatherOverlay.height), WeatherOverlay);
	}
}
