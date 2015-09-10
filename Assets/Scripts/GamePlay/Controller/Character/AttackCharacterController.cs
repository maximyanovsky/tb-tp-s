using UnityEngine;
using System.Collections;

public class AttackCharacterController : MonoBehaviour, ICharacterController
{
	private ICharacterModel _character;

	public void Init (ICharacterModel character, Camera camera)
	{
		_character = character;
	}

	void FixedUpdate ()
	{
		//later here wil bee spawning a bullet etc, now just skip
		_character.DoStep (new ControlStep () { State = CharacterState.MOVE });
	}
}
