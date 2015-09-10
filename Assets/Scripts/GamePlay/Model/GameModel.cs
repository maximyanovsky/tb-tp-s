using UnityEngine;
using System;

public class GameModel : MonoBehaviour, IGameModel
{
    // for read-only access in GUI scripts
    public static IGameModel Current { get; private set; }

    private ICharacterModel _currentCharacter;

    public event Action<ICharacterModel> CurrentCharacterChanged;
    public ICharacterModel[] Characters { get; private set; }
    public ICharacterModel CurrentCharacter
    {
        get { return _currentCharacter; }
        set
        {
            if (_currentCharacter != value)
            {
                _currentCharacter = value;
                if ( CurrentCharacterChanged != null)
                    CurrentCharacterChanged(_currentCharacter);
            }      
        }
    }
    

    // Use this for initialization
    void Awake()
    {
        Characters = GetComponentsInChildren<ICharacterModel>();
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
