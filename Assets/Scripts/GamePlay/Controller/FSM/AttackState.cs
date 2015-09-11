using System;
using System.Collections;
using UnityEngine;

public class AttackState : ComponentStateHandler<CharacterState>
{
	[SerializeField] private Animator _animator;
	[SerializeField] private Transform _cameraPivot;
	
	override public void OnEnterState()
	{
		base.OnEnterState();
		CameraManager.MoveTo(_cameraPivot, _animator.transform.parent);
		_animator.SetTrigger("Kick");
		StartCoroutine(PlayKickAnimation());
	}

    private IEnumerator PlayKickAnimation()
    {
		while(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
			yield return new WaitForEndOfFrame();
        while(_animator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
			yield return new WaitForEndOfFrame();
		Finish(CharacterState.MOVE);
    }
}