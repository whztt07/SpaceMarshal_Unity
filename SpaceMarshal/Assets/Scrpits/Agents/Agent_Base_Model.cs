using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Agent_Base_Model : MonoBehaviour
{

	//Stat Variables
	[SerializeField]
	protected float CurrentHealth, MaxHealth, DecreasingHealth;
	[SerializeField]
	protected float CurrentMana, MaxMana, DecreasingMana;
	[SerializeField]
	protected float CurrentStamina, MaxStamina, DecreasingStamina;

	protected virtual float IncreassStat(float CurrentAmount, float IncreassingAmount)
	{
		CurrentAmount += IncreassingAmount;
		return CurrentAmount;
	}

	protected virtual void DecreassStat(float CurrentAmount, float DecreasingAmount)
	{
		CurrentAmount -= DecreasingAmount;
	}

	protected virtual void AgentStatVariablesSetup()
	{
		CurrentHealth = MaxHealth;
		CurrentMana = MaxMana;
		CurrentStamina = MaxStamina;
	}

	protected virtual void SetMaxStats(float H, float M, float S)
	{
		MaxHealth = H;
		MaxMana = M;
		MaxStamina = S;
	}







}


