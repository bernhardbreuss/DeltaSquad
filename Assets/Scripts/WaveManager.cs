using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {
	
	public CarManager carManager;
	//public GameObject carManagerObject;
	
	private bool isFinished;
	public bool IsDay { get; set; }
	//default time between two spawned cars at the beginning
	public float baseTimeBetweenCars = 5f;
	public float TimeBetweenCars { get; set; }
	public PlayerPowergrid playerGrid;
	public NPCPowergrid windGrid;
	public NPCPowergrid sunGrid;
	public float nightDuration;
	public float CurrentNightDuration { get; private set; }
	public int builtChargeStations { get; set; }
	
	private bool _allCarsSpawned;
	
	public List<TextAsset> WaveFiles;
	private List<Wave> _waves;
	private int _waveIndex;
	
	// Use this for initialization
	void Start () {
		isFinished = false;
		TimeBetweenCars = baseTimeBetweenCars;
		
		_waves = new List<Wave>();
		foreach (TextAsset asset in WaveFiles) {
			_waves.Add(ParseAsset(asset));
		}
		
		Debug.Log("Wave Manager instatiated");
		//carManager = (CarManager) carManagerObject.GetComponent("CarManager");
		_waveIndex = -1;
		StartNextWave();
	}
	
	// Update is called once per frame
	void Update () {
		 if(!IsDay){
			CurrentNightDuration -= Time.deltaTime;
		}
	}
	
	public void StartNextWave() {
		_waveIndex++;
		IsDay = true;
		
		if (_waveIndex >= _waves.Count) {
			_waveIndex = (_waves.Count - 1);
		}
		
		Debug.Log("Starting wave " + _waveIndex);
		Wave wave = _waves[_waveIndex];

		StartCoroutine(CarWave(wave._car));
		StartCoroutine(WeatherWave(wave._wind, windGrid.weather));
		StartCoroutine(WeatherWave(wave._sun, sunGrid.weather));
	}
	
	private IEnumerator<YieldInstruction> CarWave(List<Task> tasks) {
		isFinished = false;
		_allCarsSpawned = false;
				
		foreach (Task task in tasks) {
			carManager.SpawnCar();
			Debug.Log("next car in " + task._time);
			yield return new WaitForSeconds(task._time);
		}
		
		_allCarsSpawned = true;
		
		yield return null;
	}
	
	private IEnumerator<YieldInstruction> WeatherWave(List<Task> tasks, Weather weather) {
		for (int i = 0; i < tasks.Count; i++) {
			Task task = tasks[i];
			if (task._command == Commands.ChangeTo) {
				Debug.Log(((weather == windGrid.weather) ? "wind" : "sun") + " changing to " + task._v + " within " + task._time);
				weather.ChangeTo(task._v, task._time);
				yield return new WaitForSeconds(task._time);
			} else if (task._command == Commands.Wait) {
				Debug.Log(((weather == windGrid.weather) ? "wind" : "sun") + " waits for " + task._time);
				yield return new WaitForSeconds(task._time);
			} else {
				Debug.Log(((weather == windGrid.weather) ? "wind" : "sun") + " jumps to " + task._commandNr);
				if (task._command == Commands.GotoRemove) {
					tasks.RemoveAt(i);
				}
				
				i = (task._commandNr - 1);
				if (i < -1 || i >= tasks.Count) {
					i = -1;
				}
			}
		}
		
		yield return null;
	}
	
	public void WaveFinished() {
		if (!_allCarsSpawned) {
			return;
		}
		
		Debug.Log("Wave finished");
		isFinished = true;
		IsDay = false;
		StopAllCoroutines();
		playerGrid.ResetGrid();
		windGrid.ResetGrid();
		sunGrid.ResetGrid();
		CurrentNightDuration = nightDuration;
		StartCoroutine(WaitNight());
	}
	
	private IEnumerator<YieldInstruction> WaitNight(){
		yield return new WaitForSeconds(nightDuration);
		Debug.Log("Night Over");
		StartNextWave();
	}
	
	public void SkipNight(){
		if(!IsDay){
			StopAllCoroutines();
			StartNextWave();
		}
	}
	
	private Wave ParseAsset(TextAsset asset) {
		Wave wave = new Wave();
		string[] lines = asset.text.Split(new string[] {"\n"}, System.StringSplitOptions.RemoveEmptyEntries);
		
		float time;
		bool wind, gotoRemove;
		int command;
		
		for (int i = 0; i < lines.Length; i++) {
			string line = lines[i].Trim().ToLower();
			if (line.Length == 0) {
				continue;
			}
			
			if (line == "car") {
				line = lines[++i].Trim().ToLower().ToLower();
				if (float.TryParse(line, out time)) {
					wave._car.Add(new Task(Commands.Wait, time));
				} else {
					Debug.Log("Unknown car wait time: " + line);
				}
			} else if (line == "wind" || line == "sun") {
				wind = (line == "wind");
				line = lines[++i].Trim().ToLower();
				Task task = null;
				if (line == "changeto") {
					line = lines[++i].Trim().ToLower();
					float v;
					if (float.TryParse(line, out v)) {
						line = lines[++i].Trim().ToLower();
						if (float.TryParse(line, out time)) {
							task = new Task(Commands.ChangeTo, v, time);
						} else {
							Debug.Log("Unknown weather wait time: " + line);
						}
					} else {
						Debug.Log("Unknown weather value: " + line);
					}
				} else if (line == "goto" || line == "gotoremove") {
					gotoRemove = (line == "gotoremove");
					line = lines[++i].Trim().ToLower();
					if (int.TryParse(line, out command)) {
						task = new Task((gotoRemove ? Commands.GotoRemove : Commands.Goto), command);
					} else {
						Debug.Log("Unknown Goto argument: " + line);
					}
				} else if (line == "wait") {
					line = lines[++i].Trim().ToLower();
					if (float.TryParse(line, out time)) {
						task = new Task(Commands.Wait, time);
					} else {
						Debug.Log("Unknown weather wait: " + line);
					}
				}else {
					Debug.Log("Unknown weather command: " + line);
				}
					
				if (task != null) {
					if (wind) {
						wave._wind.Add(task);
					} else {
						wave._sun.Add(task);
					}
				}
			} else {
				Debug.Log("Hi, i don't know what " + line + " means. Sorry.");
			}
		}
		
		return wave;
	}
	
	private enum Commands {
		Wait, Goto, GotoRemove, ChangeTo
	}
	
	private class Wave {
		public List<Task> _car = new List<Task>();
		public List<Task> _wind = new List<Task>();
		public List<Task> _sun = new List<Task>();
	}
	
	private class Task {
		public Commands _command;
		public float _v;
		public float _time;		
		public int _commandNr;
							
		public Task(Commands command, int commandNr) {
			_command = command;
			_commandNr = commandNr;
		}	
						
		public Task(Commands command, float time) {
			_command = command;
			_time = time;
		}	
		
		public Task(Commands command, float v, float time) {
			_command = command;
			_v = v;
			_time = time;
		}
	}
}
