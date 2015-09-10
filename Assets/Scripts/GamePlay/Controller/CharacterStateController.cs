using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterStateController : MonoBehaviour 
{
	private ICharacterModel _character;
	private IGameModel _game;

	private Dictionary<CharacterState, ICharacterController> _stateDict;
	private ICharacterController _currentController;

	void Start()
	{
		_game = GameModel.Current;
		_character = GetComponent<ICharacterModel>();
		
		_game.CurrentCharacterChanged += OnCurrentCharacterChanged;
		_character.StateChanged += HandleStateChanged;
		
		if (_game.CurrentCharacter != null)
			OnCurrentCharacterChanged(_game.CurrentCharacter);
	}

    private void OnCurrentCharacterChanged(ICharacterModel value)
    {
		if (_character == value)
		{
			_character.DoStep(new ControlStep(){State = CharacterState.MOVE});
		}
		else
		{
			_character.DoStep(new ControlStep(){State = CharacterState.IDLE});
		}
    }

	void HandleStateChanged (CharacterState state)
	{
		Debug.Log ("State changed " + state);

		if (_currentController != null)
			_currentController.enabled = false;

		_currentController = getController (state);
		StartCoroutine (EnableController ());
	}

	IEnumerator EnableController()
	{
		yield return new WaitForEndOfFrame ();
		_currentController.enabled = true;
	}

	void Awake () 
	{
		_stateDict = new Dictionary<CharacterState, ICharacterController> ();

		registerController (CharacterState.MOVE, GetComponent<ThirdPersonCharacterController> ());
		registerController (CharacterState.AIMING, GetComponent<AimingCharacterController> ());
		registerController (CharacterState.ATTACK, GetComponent<AttackCharacterController> ());
		registerController (CharacterState.IDLE, GetComponent<IdleCharacterController> ());
	}

	private ICharacterController getController(CharacterState state)
	{
		return _stateDict [state];
	}

	private void registerController(CharacterState state, ICharacterController controller)
	{
		controller.enabled = false;
		_stateDict [state] = controller;
	}
}
