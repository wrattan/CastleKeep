using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Transform target;

	public float Snappiness;

	public float Above = 10;
	public float Behind = 15;

	Vector3 DesiredPosition;

	void Reset()
	{
		Snappiness = 3.0f;
	}

	Vector3 offset
	{
		get
		{
			return new Vector3( 10f, Above, Behind);
		}
	}

	

	IEnumerator Start()
	{
		yield return null;		

		ManualUpdate(1.0f);
	}

	void ManualUpdate(float SnapTweenAmount)
	{
		Vector3 UsableOffset = offset;

		DesiredPosition = target.position + UsableOffset;

		transform.position = Vector3.Lerp(
		transform.position, DesiredPosition, SnapTweenAmount);

	}

	void FixedUpdate()
	{
		ManualUpdate( Snappiness * Time.deltaTime);
	}

}