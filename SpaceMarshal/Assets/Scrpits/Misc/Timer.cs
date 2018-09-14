using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField]
	public float StartTime, EndTime, IncrementingTime, CurrentTime;
	public event Action OnTimerFinish;


	public bool CheckTime()
	{
		if (CurrentTime >= EndTime)
		{
			return true;
		}

		return false;

	}

	public void RunTimerDown()
	{
		CurrentTime -= IncrementingTime;
	}


	public void RunTimerUp()
	{
		CurrentTime += IncrementingTime;
	}
}
