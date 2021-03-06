using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public void OnPointerDown(PointerEventData data)
	{
		if (PlayerBehaviourScript.instance != null)
		{
			PlayerBehaviourScript.instance.SetJumpState(true);
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		if (PlayerBehaviourScript.instance != null)
		{
			PlayerBehaviourScript.instance.SetJumpState(false);
		}
	}
}
