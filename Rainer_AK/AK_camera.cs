using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_camera : MonoBehaviour {
    public GameObject ak;
    public float juli;
    public float angle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(ak.transform.eulerAngles.z, ak.transform.eulerAngles.y - 90.0f, 0.0f);
       // transform.eulerAngles = new Vector3(0.0f, ak.transform.eulerAngles.y - 90.0f, 0.0f);
        ak.transform.eulerAngles += new Vector3(0.0f, -1 * angle, 0.0f);
        transform.position = ak.transform.position + ak.transform.right * juli;
        ak.transform.eulerAngles += new Vector3(0.0f,  angle, 0.0f);


    }
}
