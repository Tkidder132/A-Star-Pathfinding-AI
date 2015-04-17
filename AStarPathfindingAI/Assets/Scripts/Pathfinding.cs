﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

	Grid grid;

	void Awake()
	{
		grid = GetComponent<Grid>();
	}

	void FindPath(Vector3 startPos, Vector3 targetPos)
	{
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();

		openSet.Add(startNode);

		while( openSet.Count > 0 )
		{
			Node currentNode = openSet[0];
			for( int i = 1; i < openSet.Count; i++ )
			{
				if( openSet[i].fCost < currentNode.fCost || ( openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost ) )
				{
					currentNode = openSet[i];
				}
			}

			openSet.Remove(currentNode);
			closedSet.Add(currentNode);

			if( currentNode == targetNode )
			{
				return;
			}

			foreach(Node neighbor in grid.GetNeighbors(currentNode))
			{
				if( !neighbor.walkable || closedSet.Contains(neighbor) )
				{
					continue;
				}
			}
		}
	}
}
