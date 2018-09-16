using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightTImer : MonoBehaviour
{
	public float CurrentTime;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		CurrentTime += 0.1f * Time.smoothDeltaTime;
		//print(CurrentTime);
	}
}
