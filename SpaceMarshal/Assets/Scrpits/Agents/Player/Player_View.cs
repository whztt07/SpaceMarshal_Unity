using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player_View : Agent_Base_View
{

	public Renderer rend;


	// Use this for initialization
	void Start ()
	{
		
		AgentMaterial = gameObject.GetComponent<Renderer>().material;
		AgentModel = gameObject.GetComponent<Mesh>();


		switch (TypeOfAgent)
		{
			case AgentType.MONSTER:

				AgentModel = ListOfModels[0];
				GetComponent<MeshFilter>().sharedMesh = AgentModel;

				break;
			case AgentType.NPC:

				AgentModel = ListOfModels[1];
				GetComponent<MeshFilter>().sharedMesh = AgentModel;
				break;
			case AgentType.PLAYER:

				AgentModel = ListOfModels[2];
				GetComponent<MeshFilter>().sharedMesh = AgentModel;
				break;
			default:
				break;
		}


		switch (GenderOfAgent)
		{
			case AgentGender.Female:

				AgentMaterial.color = Color.magenta;

				break;
			case AgentGender.Male:

				AgentMaterial.color = Color.blue;

				break;
			case AgentGender.other:

				AgentMaterial.color = Color.green;

				break;
			case AgentGender.NA:

				AgentMaterial.color = Color.black;

				break;

			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
