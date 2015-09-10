using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonCharacterController : MonoBehaviour, ICharacterController
{
	private ICharacterModel _characterModel;
    private Transform _cameraTransform;                
    private Vector3 _cameraForward;             
    private Vector3 _move;
    private bool _jump;         
	private bool _fire;
	
	void Awake()
	{
		_characterModel = GetComponent<CharacterModel>();
		_cameraTransform = Camera.main.transform;
	}

    private void Update()
    {
        if (!_jump)
        {
            _jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

		if (!_fire) 
		{
			_fire = CrossPlatformInputManager.GetButtonDown ("Fire1");
		}
    }

	void OnEnable()
	{
		if (_characterModel != null) 
		{
			_cameraTransform.parent = _characterModel.thirdPersonPivot;
			_cameraTransform.localPosition = Vector3.zero;
			_cameraTransform.localRotation = Quaternion.identity;
		}
	}
	
    private void FixedUpdate()
    {
		var step = new ControlStep();

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		bool crouch = Input.GetKey(KeyCode.C);

		if (_fire) 
		{
			step.State = CharacterState.AIMING;

			step.Move = Vector2.zero;
			step.Crouch = false;
			step.Jump = false;
		} 
		else 
		{
			_cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
			_move = v*_cameraForward + h*_cameraTransform.right;


			step.Crouch = crouch;
			step.Jump = _jump;
			step.Move = _move;
		}

		_characterModel.DoStep (step);
        _jump = false;
		_fire = false;
    }
}

