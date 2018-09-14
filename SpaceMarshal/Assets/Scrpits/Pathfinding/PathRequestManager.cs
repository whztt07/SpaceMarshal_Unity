using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PathRequestManager : MonoBehaviour
{
	Queue<PathRequest> PathRequestQueue = new Queue<PathRequest>();
	private PathRequest CurrentPathRequest;

	private static PathRequestManager Instance;
	private Pathfinding Pathfinding;

	private bool IsProcessingPath;

	void Awake()
	{
		Instance = this;
		Pathfinding = GetComponent<Pathfinding>();
	}

	public static void RequestPath(Vector3 PathStart, Vector3 PathEnd, Action<Vector3[], bool> CallBack)
	{
		PathRequest newPathRequest = new PathRequest(PathStart, PathEnd, CallBack);
		Instance.PathRequestQueue.Enqueue(newPathRequest);
		Instance.TryProcessNext();
	}

	private void TryProcessNext()
	{
		if (!IsProcessingPath && PathRequestQueue.Count > 0)
		{
			CurrentPathRequest = PathRequestQueue.Dequeue();
			IsProcessingPath = true;
			Pathfinding.StartFindPath(CurrentPathRequest.PathStart, CurrentPathRequest.PathEnd);
		}
	}

	public void FinshedProcessingPath(Vector3[] path, bool success)
	{
		CurrentPathRequest.CallBack(path, success);
		IsProcessingPath = false;
		TryProcessNext();
	}

	struct PathRequest
	{
		public Vector3 PathStart;
		public Vector3 PathEnd;
		public Action<Vector3[], bool> CallBack;

		public PathRequest(Vector3 _PathStart, Vector3 _PathEnd, Action<Vector3[], bool> _CallBack)
		{
			PathStart = _PathStart;
			PathEnd = _PathEnd;
			CallBack = _CallBack;
		}
	}

}
