using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour {
	public float tileSize;
	Vector3 startPos, movingDirn;

	Transform backgroundTransform;
	// Use this for initialization
	void Start () {
		movingDirn = new Vector3 (0, -1, 0);
		backgroundTransform = GetComponent<Transform> ();
		startPos = backgroundTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float pos = Mathf.Repeat (Time.time * GameManager.Instance.speed, tileSize);
		backgroundTransform.position = startPos+movingDirn * pos;
	}
}
