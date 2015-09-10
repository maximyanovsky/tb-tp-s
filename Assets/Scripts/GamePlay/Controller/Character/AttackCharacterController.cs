using UnityEngine;
using System.Collections;

public class AttackCharacterController : MonoBehaviour, ICharacterController
{
	private ICharacterModel _character;
	void Start()
	{
		_character = GetComponent<ICharacterModel>();
	}
	
	void FixedUpdate ()
	{
		//later here wil bee spawning a bullet etc, now just skip
		_character.DoStep (new ControlStep () { State = CharacterState.MOVE });
	}
}
