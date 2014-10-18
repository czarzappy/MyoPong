using UnityEngine;
using System.Collections;

public class ForceIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.rigidbody.AddForce(0.0f, 0.0f, -20.0f, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
