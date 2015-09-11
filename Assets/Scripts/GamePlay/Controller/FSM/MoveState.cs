using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class MoveState : ComponentStateHandler<CharacterState>
{
	[SerializeField] private ThirdPersonCharacterController _controller;
	[SerializeField] private ThirdPersonCharacter _thirdPersonCharacter;
	[SerializeField] private Transform _cameraPivot;
	
	private ICharacterModel _characterModel;
    private Transform _cameraTransform;               
	
	void Awake()
	{
		_characterModel = GetComponent<ICharacterModel>();
		_cameraTransform = Camera.main.transform;
	}
	
	override public void OnEnterState()
	{
		base.OnEnterState();
		_controller.ClearSession();
		CameraManager.MoveTo(_cameraPivot);
		
		StartCoroutine(Move());
	}

    private IEnumerator Move()
    {
		yield return new WaitForEndOfFrame();
		ControlStep step;
		do
		{
			step = _controller.GetControlStep();
			_thirdPersonCharacter.Move (step.Move, step.Crouch, step.Jump);
			yield return new WaitForFixedUpdate();
		}
		while (step.State == CharacterState.NONE);
		while (_thirdPersonCharacter.isMoving())
		{
			_thirdPersonCharacter.Move (Vector3.zero, false, false);
			yield return new WaitForFixedUpdate();
		}
		Finish(step.State);
    }
}