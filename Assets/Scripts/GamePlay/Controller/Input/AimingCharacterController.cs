using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent (typeof (ICharacterModel))]
public class AimingCharacterController : MonoBehaviour, ICharacterController 
{
	[SerializeField] private MouseLook _mouseLook;
	private ICharacterModel _characterModel;

	private Transform _characterTransform;
	private Transform _cameraTransform;
	private bool _buttonDown;
	
	void Awake()
	{
		_cameraTransform = Camera.main.transform;
		_characterModel = GetComponent<ICharacterModel>();
		_characterTransform = _characterModel.transform;
		_mouseLook.Init (_characterTransform, _cameraTransform);
	}
	
	void Update()
	{
		if (!_buttonDown)
			_buttonDown = CrossPlatformInputManager.GetButtonDown ("Fire1");
	}

    public ControlStep GetControlStep()
    {
        var step = new ControlStep();
		if (_buttonDown) 
		{
			step.State = CharacterState.ATTACK;
		}
		else
		{
			_mouseLook.LookRotation (_characterTransform, _cameraTransform, out step.CharacterLocalRotation, out step.CameraLocalRotation);
		}
		_buttonDown = false;
		return step;
    }

    public void ClearSession()
    {
        _buttonDown = false;
    }
}
