using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

abstract public class AStateModel<TState> : ExtendedMonoBehaviour, IStateModel<TState>
{
	public TState state { get; private set; }
	public event Action<TState> StateChanged;

	public void SetState(TState state_)
	{
		if (!Enum.Equals (state, state_)) 
		{
			state = state_;
			if (StateChanged != null)
				StateChanged(state);
		}
	}
}
