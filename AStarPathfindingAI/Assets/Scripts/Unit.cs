using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Transform target;
	float speed = 5;
	Vector3[] path;
	int targetIndex;

	void Start()
	{
		PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{

	}
}
