﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class AimingCharacterController : MonoBehaviour, ICharacterController 
{
	[SerializeField] private MouseLook _mouseLook;

	private ICharacterModel _characterModel;
	private Transform _characterTransform;
	private Transform _cameraTransform;

	public void Init(ICharacterModel character, Camera camera)
	{
		_characterModel = character;
		_characterTransform = character.transform;
		_cameraTransform = camera.transform;
		_mouseLook.Init (_characterTransform, _cameraTransform);
	}

	void OnEnable()
	{
		if (_characterModel != null) 
		{
			_cameraTransform.parent = _characterModel.firstPersonPivot;
			_cameraTransform.localPosition = Vector3.zero;
			_cameraTransform.localRotation = Quaternion.identity;
		}
	}
	
	void FixedUpdate () 
	{
		var step = new ControlStep();
		bool fireUp = CrossPlatformInputManager.GetButtonDown ("Fire1");

		if (fireUp) 
		{
			step.State = CharacterState.ATTACK;
		}
		else
		{
			_mouseLook.LookRotation (_characterTransform, _cameraTransform, out step.CharacterLocalRotation, out step.CameraLocalRotation);
		}
		_characterModel.DoStep (step);
	}
}