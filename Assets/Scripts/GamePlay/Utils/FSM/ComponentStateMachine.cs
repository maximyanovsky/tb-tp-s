using UnityEngine;

public class ComponentStateMachine<TState> : MonoBehaviour
{
	protected StateMachine<TState> _fsm = new StateMachine<TState>();
	
	protected void Register<T>(TState state) where T : IStateHandler<TState>
	{
		var component = GetComponent<T>();
		(component as MonoBehaviour).enabled = false;
		
		_fsm.Register(state, component);
	}
}