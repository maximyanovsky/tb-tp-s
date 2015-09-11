using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TState>
{
	public event Action<TState> StateEntered;
	
	private Dictionary<TState, IStateHandler<TState>> _handlers = new Dictionary<TState, IStateHandler<TState>>();
	private IStateHandler<TState> _currentHandler;
	
	public void Register(TState state, IStateHandler<TState> handler)
	{
		_handlers[state] = handler;
	}
	
	public void Start(TState state)
	{
		EnterState(state);
	}
	
	private void EnterState(TState state)
	{
		Debug.Log("Enter state " + state);
		_currentHandler = _handlers[state];
		
		if (StateEntered != null)
			StateEntered(state);
		
		_currentHandler.Finished += OnHandlerFinished;
		_currentHandler.OnEnterState();
	}
	
	private void OnHandlerFinished(TState state)
	{
		if (_currentHandler != null)
		{
			_currentHandler.Finished -= OnHandlerFinished;
			_currentHandler.OnExitState();
		}
		EnterState(state);
	}
}