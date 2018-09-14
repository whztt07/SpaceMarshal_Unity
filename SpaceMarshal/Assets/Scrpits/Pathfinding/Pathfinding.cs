using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Pathfinding : MonoBehaviour
{
	public Grid Gird;

	private PathRequestManager RequestManager;


	void Awake()
	{
		RequestManager = GetComponent<PathRequestManager>();
		Gird = GetComponent<Grid>();
	}

	
	public void StartFindPath(Vector3 StartPos, Vector3 TargetPos)
	{
		StartCoroutine(FindPath(StartPos, TargetPos));
	}
	
	IEnumerator FindPath(Vector3 StartPosition, Vector3 TargetPosition)
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();

		Vector3[] Waypoints = new Vector3[0];
		bool IsPathSuccess = false;


		StarNode StartNode = Gird.GetNodeFromWorldPoint(StartPosition);
		StarNode TargetNode = Gird.GetNodeFromWorldPoint(TargetPosition);

		if (StartNode.IsWalkable && TargetNode.IsWalkable)
		{
			Heap<StarNode> OpenSet = new Heap<StarNode>(Gird.MaxSize);
			HashSet<StarNode> ClosedSet = new HashSet<StarNode>();

			OpenSet.Add(StartNode);

			while (OpenSet.Count > 0)
			{
				StarNode CurrentNode = OpenSet.RemoveFirst();
				ClosedSet.Add(CurrentNode);

				if (CurrentNode == TargetNode)
				{
					sw.Stop();
					print("Path found: " + sw.ElapsedMilliseconds + " ML");
					IsPathSuccess = true;

					break;
				}

				foreach (StarNode Neighbor in Gird.GetNeighbors(CurrentNode))
				{
					if (!Neighbor.IsWalkable || ClosedSet.Contains(Neighbor))
					{
						continue;
					}

					int NewMovementCostToNeighour = CurrentNode.Gcost + GetDistance(CurrentNode, Neighbor);
					if (NewMovementCostToNeighour < Neighbor.Gcost || !OpenSet.Contains(Neighbor))
					{
						Neighbor.Gcost = NewMovementCostToNeighour;
						Neighbor.Hcost = GetDistance(Neighbor, TargetNode);
						Neighbor.NodeParent = CurrentNode;

						if (!OpenSet.Contains(Neighbor))
						{
							OpenSet.Add(Neighbor);
							OpenSet.UpdateItem(Neighbor);
						}
					}
				}
			}
		}

		
		yield return null;
		if (IsPathSuccess)
		{
			Waypoints = RetracePath(StartNode, TargetNode);
		}

		RequestManager.FinshedProcessingPath(Waypoints, IsPathSuccess);

	}

	Vector3[] RetracePath(StarNode StartNode, StarNode EndNode)
	{
		List<StarNode> Path = new List<StarNode>();

		StarNode CurrentNode = EndNode;

		while (CurrentNode != StartNode)
		{
			Path.Add(CurrentNode);
			CurrentNode = CurrentNode.NodeParent;
		}
		Vector3[] Waypoints = SimplifyPath(Path);
		Array.Reverse(Waypoints);

		return Waypoints;


	}

	private Vector3[] SimplifyPath(List<StarNode> path)
	{
		List<Vector3> waypoints = new List<Vector3>();
		Vector2 DirectionOld = Vector2.zero;

		for (int i = 1; i < path.Count; i++)
		{
			Vector2 DirectionNew = new Vector2(path[i - 1].GridX - path[i].GridX, path[i - 1].GridY - path[i].GridY);

			if (DirectionNew != DirectionOld)
			{
				waypoints.Add(path[i].WorldPosition);
			}
			DirectionOld = DirectionNew;
		}

		return waypoints.ToArray();
	}


	int GetDistance(StarNode NodeA, StarNode NodeB)
	{
		int DstX = Mathf.Abs(NodeA.GridX - NodeB.GridX);
		int DstY = Mathf.Abs(NodeA.GridY - NodeB.GridY);

		if (DstX > DstY)
		{
			return 14 * DstY + 10 * (DstX - DstY);
		}
		else
		{
			return 14 * DstX + 10 * (DstY - DstX);
		}
	}

}
