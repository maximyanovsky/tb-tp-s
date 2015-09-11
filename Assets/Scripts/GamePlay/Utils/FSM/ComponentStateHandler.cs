using System;
using UnityEngine;

public class ComponentStateHandler<TState> : MonoBehaviour, IStateHandler<TState>
{
    public event Action<TState> Finished;

    public void Finish(TState state)
    {
        Finished(state);
    }
    
    public virtual void OnEnterState()
    {
        enabled = true;
    }

    public virtual void OnExitState()
    {
        enabled = false;
    }
}