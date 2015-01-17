using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineRendererMaster : MonoBehaviour {

	public GameObject Nail;

	private List<GameObject> nails;	

	private List<GameObject> lines;

	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		nails = new List<GameObject> ();
		lines = new List<GameObject> ();

		AddLine(0, AddNail (0, 0, 15));
		AddLine(1, AddNail (-6, 0, 15));
		AddLine(2, AddNail (-6, 4, 15));
		AddLine(1, AddNail (0, 4, 15));


		lineRenderer = GetComponent<LineRenderer> ();
	}

	private GameObject AddNail(float x, float y, float z)
	{
		GameObject nail = Instantiate (Nail) as GameObject;
		nail.transform.position = new Vector3 (x, y, z);
		nails.Add (nail);
		return nail;
	}

	private void AddLine (int index, GameObject nail)
	{
		List<GameObject> newLines = new List<GameObject> ();
		for(int i=0; i<index; i++)
		{
			newLines.Add(lines[i]);
		}
		newLines.Add (nail);
		for(int i=index; i<lines.Count; i++)
		{
			newLines.Add(lines[i]);
		}
		lines = newLines;
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer.SetVertexCount (lines.Count);
		for(int i=0; i<lines.Count; i++)
		{
			lineRenderer.SetPosition(i, lines[i].transform.position);
		}
	}
}
