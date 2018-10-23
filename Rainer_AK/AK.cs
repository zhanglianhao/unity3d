using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : MonoBehaviour {
    float v = 10.0f;
    public GameObject zd;
    public GameObject wz;
    public float angle;
    int walk_run = 0;
    public int count;
    int jishu = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {

            // transform.Translate(transform.forward * Time.deltaTime * v);
            //  transform.eulerAngles=new Vector3(0.0f,0.0f,0.0f);

            if (walk_run == (-1))
            {
                transform.position -= transform.right * Time.deltaTime * v;
            }
            else
            {
                transform.position -= transform.right * Time.deltaTime * v * 0.3f;

            }
        }

        if (Input.GetKey(KeyCode.S))
        {


            if (walk_run == (-1))
            {
                transform.position += transform.right * Time.deltaTime * v;
            }
            else
            {
                transform.position += transform.right * Time.deltaTime * v * 0.3f;

            }
            // Debug.Log(transform.right);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (walk_run != -1)
                walk_run = -1;
            else
                walk_run = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, angle, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0, angle, 0);


        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles += new Vector3(0.0f, 0.0f, angle);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles -= new Vector3(0.0f, 0.0f, angle);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(++jishu>=count)
            {
                jishu = 0;
            transform.eulerAngles -= new Vector3(0, 90.0f, 0);
             GameObject a=GameObject.Instantiate(zd, transform.position+transform.forward*4, transform.rotation);
           // GameObject a = GameObject.Instantiate(zd, wz.transform.position, transform.rotation);
            transform.eulerAngles += new Vector3(0, 90.0f, 0);
            a.GetComponent<Rigidbody>().velocity = -1 * transform.right * 100;
            }
        }
    }
}
