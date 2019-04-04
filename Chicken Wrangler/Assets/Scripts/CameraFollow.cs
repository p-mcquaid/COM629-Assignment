using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float m_smooth = 0.125f;
    public Vector3 offset;

	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, m_smooth);

        transform.position = smoothedPos;

        transform.LookAt(target);
	}
}
