using UnityEngine;
using System.Collections;

public class ExtendedMonoBehaviour : MonoBehaviour {

	private Transform _cachedTransform;
	public Transform cachedTransform 
	{ 
		get 
		{
			if (_cachedTransform == null)
				_cachedTransform = transform;
			return _cachedTransform;
		}
	}
}
