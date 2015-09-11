using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (ICharacterModel))]
public class IdleCharacterController : MonoBehaviour, ICharacterController
{
    private ICharacterModel _character;
	private Rigidbody _rigidbody;
	
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_character = GetComponent<ICharacterModel>();
	}
	
	void OnEnable()
	{
		_rigidbody.isKinematic = true;
	}
	
	void OnDisable()
	{
		_rigidbody.isKinematic = false;
	}
	
	void FixedUpdate ()
	{
		//do nothing
		_character.DoStep (new ControlStep ());
	}
}
