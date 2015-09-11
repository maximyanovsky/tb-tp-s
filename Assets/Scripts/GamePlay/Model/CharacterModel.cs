using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public class CharacterModel : AStateModel<CharacterState>, ICharacterModel 
{
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

