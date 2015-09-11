using System;
using System.Collections;
using UnityEngine;

public class AimState : ComponentStateHandler<CharacterState>
{
	[SerializeField] private AimingCharacterController _aimController;
	[SerializeField] private Transform _cameraPivot;
	
	private ICharacterModel _characterModel;
	private Transform _characterTransform;
	private Transform _cameraTransform;
	
	void Awake()
	{
		_cameraTransform = Camera.main.transform;
		_characterModel = GetComponent<ICharacterModel>();
		_characterTransform = _characterModel.transform;
	}
	
	override public void OnEnterState()
	{
		base.OnEnterState();
		_aimController.ClearSession();
		
		CameraManager.MoveTo(_cameraPivot);
	}
	
	private void FixedUpdate()
	{
		var step = _aimController.GetControlStep();
		if (step.State != CharacterState.NONE)
		{
			Finish(CharacterState.ATTACK);
		}
		else
		{
			_characterTransform.localRotation = step.CharacterLocalRotation;
			_cameraTransform.localRotation = step.CameraLocalRotation;
		}
	}
}