using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {
    public GameObject zhadan;
    public GameObject solider;
    public float angle;
    public float v;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(GameObject.FindGameObjectWithTag("solider").transform.position.x - transform.position.x) < 8 && Mathf.Abs(GameObject.FindGameObjectWithTag("solider").transform.position.z - transform.position.z) < 12)
        {
            if (Input.GetKey(KeyCode.X))
            {
                transform.position += new Vector3(transform.forward.x, 0.0f, transform.forward.z)*0.1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {

            }

            if (Input.GetKey(KeyCode.Q))
                transform.eulerAngles -= new Vector3(0.0f, angle, 0.0f);
            if (Input.GetKey(KeyCode.E))
                transform.eulerAngles += new Vector3(0.0f, angle, 0.0f);
            if (Input.GetKey(KeyCode.Z))
                transform.eulerAngles += new Vector3(angle, 0.0f, 0.0f);
            if (Input.GetKey(KeyCode.C))
                transform.eulerAngles -= new Vector3(angle, 0.0f, 0.0f);
            if (Input.GetMouseButtonUp(0))
            {
              GameObject aa=Instantiate(zhadan, transform.position + transform.forward*6+new Vector3(0.0f,1.0f,0.0f), transform.rotation);
                aa.GetComponent<Rigidbody>().velocity = transform.forward * v;
            }
        }
	}
}
