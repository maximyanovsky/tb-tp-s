using System;

public class CharacterStateMachine : ComponentStateMachine<CharacterState>
{
	private ICharacterModel _character;
	private IGameModel _game;

	void Awake()
	{
		_character = GetComponent<ICharacterModel>();
		
		Register<MoveState>(CharacterState.MOVE);
		Register<AimState>(CharacterState.AIMING);
		Register<AttackState>(CharacterState.ATTACK);
		Register<IdleState>(CharacterState.IDLE);
		_fsm.StateEntered += HandleStateEntered;
		_fsm.Start(CharacterState.MOVE);
	}

    private void HandleStateEntered(CharacterState state)
    {
        _character.SetState(state);
    }

    void Start()
	{
		_game = GameModel.Current;
		_character = GetComponent<ICharacterModel>();
	}
}