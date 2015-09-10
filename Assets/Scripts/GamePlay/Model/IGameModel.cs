using System;

public interface IGameModel
{
	event Action<ICharacterModel> CurrentCharacterChanged;
	ICharacterModel CurrentCharacter { get; }	
}
