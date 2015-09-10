using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStateController : MonoBehaviour 
{
	[SerializeField] private Camera _camera;

	private Dictionary<CharacterState, ICharacterController> _stateDict;
	private ICharacterModel _currentCharacter;
	private ICharacterController _currentController;

	public ICharacterModel CurrentCharacter
	{
		get { return _currentCharacter; }
		set
		{
			if (_currentCharacter != null)
			{
				_currentCharacter.StateChanged -= HandleStateChanged;
				StopAllCoroutines();
			}

			_currentCharacter = value;
			_currentCharacter.Init(_camera.transform);
			_currentCharacter.StateChanged += HandleStateChanged;

			if (_currentCharacter.state != CharacterState.NONE)
			{
				HandleStateChanged(_currentCharacter.state);
			}
			else
				_currentCharacter.DoStep(new ControlStep(){ State = CharacterState.MOVE });
		}
	}

	void HandleStateChanged (CharacterState state)
	{
		Debug.Log ("State changed " + state);

		if (_currentController != null)
			_currentController.enabled = false;

		_currentController = getController (state);
		_currentController.Init (_currentCharacter, _camera);
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
