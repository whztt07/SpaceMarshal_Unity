using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_Base_View : MonoBehaviour
{
	[SerializeField]
	protected Mesh AgentModel;
	[SerializeField]
	protected AgentType TypeOfAgent;
	[SerializeField]
	protected AgentGender GenderOfAgent;
	[SerializeField]
	protected Material AgentMaterial;

	[SerializeField]
	public List<Mesh> ListOfModels;

	protected enum AgentType
	{
		PLAYER,
		NPC,
		MONSTER
	}

	protected enum AgentGender
	{
		Male,
		Female,
		other,
		NA
	}
}
