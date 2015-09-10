using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public class CharacterModel : AStateModel<CharacterState>, ICharacterModel 
{
	[SerializeField] private ThirdPersonCharacter _thirdPersonCharacter;
	[SerializeField] private Transform _firstPersonPivot;
	[SerializeField] private Transform _thirdPersonPivot;

	public Transform firstPersonPivot { get { return _firstPersonPivot; } }
	public Transform thirdPersonPivot { get { return _thirdPersonPivot; } }

	private Transform _cameraTransform;

	// Use this for initialization
	void Start () 
	{
		_cameraTransform = Camera.main.transform;
		_thirdPersonCharacter = GetComponentInChildren<ThirdPersonCharacter> ();
	}
	
	public void DoStep(ControlStep step)
	{
		if (state == CharacterState.MOVE) 
		{
			_thirdPersonCharacter.Move (step.Move, step.Crouch, step.Jump);
		} 
		else
		{
			_thirdPersonCharacter.Move (Vector3.zero, false, false);
			if (state == CharacterState.AIMING && step.State != CharacterState.ATTACK) 
			{
				cachedTransform.localRotation = step.CharacterLocalRotation;
				_cameraTransform.localRotation = step.CameraLocalRotation;
			}
		}

		if (step.State != CharacterState.NONE)
			setState (step.State);
	}
}

public enum CharacterState
{
	NONE, IDLE, MOVE, AIMING, ATTACK
}

public class ControlStep
{
	public Vector3 Move;
	public bool Crouch;
	public bool Jump;
	public CharacterState State;
	public Quaternion CameraLocalRotation;
	public Quaternion CharacterLocalRotation;
}

