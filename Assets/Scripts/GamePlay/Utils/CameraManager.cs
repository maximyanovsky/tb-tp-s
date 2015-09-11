using System;
using UnityEngine;

public class CameraManager
{
	public static void MoveTo(Transform pivot, Transform space = null)
	{
		var transform = Camera.main.transform;
		if (space == null)
		{
			transform.parent = pivot;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
		else
		{
			transform.parent = space;
			transform.position = pivot.position;
			transform.localRotation = pivot.rotation;
		}
		
	}
}
