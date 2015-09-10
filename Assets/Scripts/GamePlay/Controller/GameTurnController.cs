using UnityEngine;
using System.Collections;

public class GameTurnController : MonoBehaviour 
{
	[SerializeField] private CharacterStateController _characterStateController;
	[SerializeField] private GameModel _gameModel;
	
	void Start () 
	{
		_characterStateController.CurrentCharacter = _gameModel.Player;
	}
}
