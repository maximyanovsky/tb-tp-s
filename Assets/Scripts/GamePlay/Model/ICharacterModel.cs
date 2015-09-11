using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public interface ICharacterModel : IStateModel<CharacterState>
{
	Transform transform { get; }

    void SetState(CharacterState state);
}
