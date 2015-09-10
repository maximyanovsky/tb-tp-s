using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameTurnController : MonoBehaviour 
{
	[SerializeField] private GameModel _gameModel;
	
	private bool _switch;
	
	void Start () 
	{
		_gameModel.CurrentCharacter = _gameModel.Characters[0];
	}
	
	void Update ()
	{
		if (!_switch)
			_switch = CrossPlatformInputManager.GetButtonDown("Switch");
	}
	
	void FixedUpdate()
	{
		if (_switch)
		{
			var index = Array.IndexOf(_gameModel.Characters, _gameModel.CurrentCharacter);
			index++;
			if (index >= _gameModel.Characters.Length)
				index = 0;
				
			_gameModel.CurrentCharacter = _gameModel.Characters[index];	
		}
		
		_switch = false;
	}
}
