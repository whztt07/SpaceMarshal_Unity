using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Model : Agent_Base_Model
{
	private int AttackDamage
	{
		get { return AttackDamage; }
		set { AttackDamage = 5; }
	}

	// Use this for initialization
	void Start()
	{
		SetMaxStats(100, 70, 80);
		AgentStatVariablesSetup();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
