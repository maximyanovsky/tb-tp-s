using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public interface ICharacterModel : IStateModel<CharacterState>
{
	void DoStep (ControlStep step);

	Transform transform { get; }
	Transform thirdPersonPivot { get; }
	Transform firstPersonPivot { get; }

}
