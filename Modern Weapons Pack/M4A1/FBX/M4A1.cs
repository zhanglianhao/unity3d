using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : MonoBehaviour {
    public GameObject cam;
    float v = 10.0f;
    public GameObject zd;
    public GameObject wz;
    public float angle;
    public float juli;
    GameObject cc;
    Vector3 sd;
    public int count;
    int jishu = 0;
    int walk_run = 0;
    // Use this for initialization
    void Start()
    {
       // sd = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            sd = new Vector3(transform.forward.x, 0.0f, transform.forward.z);
            // transform.Translate(transform.forward * Time.deltaTime * v);
            //  transform.eulerAngles=new Vector3(0.0f,0.0f,0.0f);

            if (walk_run == (-1))
            {
                transform.position -= sd * Time.deltaTime * v;
            }
            else
            {
                transform.position -= sd* Time.deltaTime * v * 0.3f;

            }
        }

        if (Input.GetKey(KeyCode.S))
        {
           sd = new Vector3(transform.forward.x, 0.0f, transform.forward.z);

            if (walk_run == (-1))
            {
                transform.position += sd * Time.deltaTime * v;
            }
            else
            {
                transform.position += sd * Time.deltaTime * v * 0.3f;

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
            transform.eulerAngles -= new Vector3(angle, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles+= new Vector3(angle, 0.0f, 0.0f);
        }
        if (Input.GetMouseButton(0))
        {
            if (jishu++ >= count)
            {
                jishu = 0;
                transform.eulerAngles -= new Vector3(0, 90.0f, 0);
                //GameObject a = GameObject.Instantiate(zd, transform.position - transform.forward * juli, transform.rotation);
                GameObject a = GameObject.Instantiate(zd, wz.transform.position, transform.rotation);
                transform.eulerAngles += new Vector3(0, 90.0f, 0);
                //  Debug.Log(a.transform.position);
                //  Debug.Log(wz.transform.position);
                a.GetComponent<Rigidbody>().velocity = -1 * transform.forward * 100;
            }
        }
        
    }
}
