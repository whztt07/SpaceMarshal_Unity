using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This is a Scrpit for adding movement to a game quickly.
 * This is ment to be replaced but its useful for just testing movement functions.
 */
public class Movement_Model : MonoBehaviour
{
	public bool IsThisA2DGame;
	public int speed;

	public float X_AxisInput, y_AxisInput, X_Position, Y_Position;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		X_AxisInput = Input.GetAxis("Horizontal");
		y_AxisInput = Input.GetAxis("Vertical");

		X_Position = X_AxisInput * speed;
		Y_Position = y_AxisInput * speed;

		if (IsThisA2DGame)
		{
			MovementFunction2d();
		}
		else
		{
			MovementFunction3d();
		}
		
	}

	void MovementFunction3d()
	{
		transform.Translate(X_Position, 0, Y_Position);
	}

	void MovementFunction2d()
	{
		transform.Translate(X_Position, Y_Position, 0);
	}

	
}
