using UnityEngine;
using System.Collections;

public class GameModel : MonoBehaviour, IGameModel 
{
	// for read-only access in GUI scripts
	public static IGameModel Current { get; private set; }

	public ICharacterModel Player { get; private set; }

	// Use this for initialization
	void Awake () {
		Player = GetComponentInChildren<ICharacterModel> ();
		Current = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
