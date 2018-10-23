using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enerm : MonoBehaviour {
    float v = 10.0f;
    int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
   //     Debug.Log(new Vector3(GameObject.Find("Robot Kyle").transform.position.x - transform.position.x, 0.0f, GameObject.Find("Robot Kyle").transform.position.z - transform.position.z) * Time.deltaTime * 1f);

            Debug.Log(new Vector3(GameObject.Find("Robot Kyle").transform.position.x - transform.position.x, 0.0f, GameObject.Find("Robot Kyle").transform.position.z - transform.position.z) * Time.deltaTime * 1f);
            transform.Translate(new Vector3(GameObject.Find("Robot Kyle").transform.position.x - transform.position.x, 0.0f, GameObject.Find("Robot Kyle").transform.position.z - transform.position.z) * Time.deltaTime * 1.0f);
            //  Debug.Log(new Vector3(GameObject.Find("Robot Kyle").transform.position.x - transform.position.x, 0.0f, GameObject.Find("Robot Kyle").transform.position.z - transform.position.z) * Time.deltaTime * 0.01f);
  
    }
}
