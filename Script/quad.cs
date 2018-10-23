using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad : MonoBehaviour {
    public GameObject txt;
	// Use this for initialization
	void Start () {
        txt.transform.localPosition = new Vector3(0.2f,0.5f,0.1f);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
