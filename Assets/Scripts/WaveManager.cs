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
	public Weather sun;
	public Weather wind;
	
	private bool _allCarsSpawned;
	
	public List<TextAsset> WaveFiles;
	private List<Wave> _waves;
	private int _waveIndex;
	private Wave _currentWave;
	
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
		 
	}
	
	public void StartNextWave() {
		_waveIndex++;
		IsDay = true;
		
		if (_waveIndex < _waves.Count) {
			Debug.Log("Starting wave");
			_currentWave = _waves[_waveIndex];
			
			StartCoroutine(CarWave());
		}
	}
	
	public IEnumerator<YieldInstruction> CarWave() {
		isFinished = false;
		_allCarsSpawned = false;
		
		
		/*while(!isFinished){
			carManager.SpawnCar();
			sun.EnergyProductionRate += 0.01f;
			wind.EnergyProductionRate -= 0.01f;
			Debug.Log("TimeBetweenCars: " + TimeBetweenCars);
			yield return new WaitForSeconds(TimeBetweenCars);
			//weather change after served car

		}*/
		
		foreach (Task task in _currentWave._car) {
			if (task._command == Commands.Wait) {
				carManager.SpawnCar();
				Debug.Log("next car in " + task._time);
				yield return new WaitForSeconds(task._time);
			}
		}
		
		yield return null;
	}
	
	public void WaveFinished() {
		if (!_allCarsSpawned) {
			return;
		}
		
		isFinished = true;
		IsDay = false;
		StopAllCoroutines();
	}
	
	private Wave ParseAsset(TextAsset asset) {
		Wave wave = new Wave();
		string[] lines = asset.text.Split(new string[] {"\n"}, System.StringSplitOptions.RemoveEmptyEntries);
		
		float time;
		bool wind, gotoRemove;
		int command;
		
		for (int i = 0; i < lines.Length; i++) {
			string line = lines[i].Trim().ToLower();
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
				}
					
				if (task != null) {
					if (wind) {
						wave._wind.Add(task);
					} else {
						wave._wind.Add(task);
					}
				}
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
