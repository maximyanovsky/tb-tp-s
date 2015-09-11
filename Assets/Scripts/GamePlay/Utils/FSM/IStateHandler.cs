using System;

public interface IStateHandler<TState>
{
	event Action<TState> Finished;
	void OnEnterState();
	void OnExitState();
}