using UnityEngine;
using System.Collections;
using System;

// conversion from Vector3 to string and vice versa
// for socket communication between Unity clients

public class Converter : MonoBehaviour {

	void Start () {

		// conversion testing

		Vector3 vec = new Vector3 (1.5f, 2.0f, 0f);
		string str = vecToStr (vec);
		Debug.Log (str.GetType());
		Debug.Log (str);
		Vector3 vec3 = strToVec (str);
		Debug.Log (vec3.GetType());
		Debug.Log (vec3);
	}

	// takes a Vector3 and returns a string
	private string vecToStr (Vector3 vec) {
		return vec.ToString();
	}

	// takes a string and returns a Vector3
	private Vector3 strToVec (string str) {
		char[] charsToTrim = {'(',')'};
		str = str.Trim (charsToTrim);
		string[] components = str.Split(',');

		float x = Single.Parse(components [0]);
		float y = Single.Parse(components [1]);
		float z = Single.Parse(components [2]);

		return new Vector3 (x, y, z);

	}
}
