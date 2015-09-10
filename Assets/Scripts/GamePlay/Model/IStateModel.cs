using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public interface IStateModel<TState>
{
	event Action<TState> StateChanged;
	TState state { get; }
}
