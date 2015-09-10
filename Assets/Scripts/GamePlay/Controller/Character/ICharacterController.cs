using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public interface ICharacterController
{
	bool enabled {get; set;}
	void Init(ICharacterModel character, Camera camera);
}