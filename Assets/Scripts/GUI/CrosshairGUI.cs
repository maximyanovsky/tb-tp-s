using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrosshairGUI : MonoBehaviour {

	private IGameModel _game;
	private Image _image;

	void Start () 
	{
		_game = GameModel.Current;
		_image = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () 
	{
		_image.enabled = _game.Player.state == CharacterState.AIMING;
	}
}
