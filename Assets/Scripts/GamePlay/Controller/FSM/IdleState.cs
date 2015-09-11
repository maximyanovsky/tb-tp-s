using UnityEngine;

public class IdleState : ComponentStateHandler<CharacterState>
{
	private Rigidbody _rigidbody;
	
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	override public void OnEnterState()
	{
		_rigidbody.isKinematic = true;
	}
	
	override public void OnExitState()
	{
		_rigidbody.isKinematic = false;
	}
}