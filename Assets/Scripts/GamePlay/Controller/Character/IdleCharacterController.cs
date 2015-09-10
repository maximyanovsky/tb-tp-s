using UnityEngine;
using System.Collections;

public class IdleCharacterController : MonoBehaviour, ICharacterController
{
    private ICharacterModel _character;
	void Start()
	{
		_character = GetComponent<ICharacterModel>();
	}
	
	void FixedUpdate ()
	{
		//do nothing
		_character.DoStep (new ControlStep ());
	}
}
