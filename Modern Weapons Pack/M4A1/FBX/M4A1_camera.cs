using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1_camera : MonoBehaviour
{

    public GameObject ak;
    public float juli;
    public float angle_x;
    public float angle_y;
    public float pc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles = new Vector3(ak.transform.eulerAngles.x * (-1), ak.transform.eulerAngles.y - 180.0f-pc, 0.0f);
        // transform.eulerAngles = new Vector3(0.0f, ak.transform.eulerAngles.y - 90.0f, 0.0f);
        ak.transform.eulerAngles += new Vector3(0.0f, -1 * angle_y, 0.0f);
        ak.transform.eulerAngles -= new Vector3(angle_x, 0.0f, 0.0f);
        transform.position = ak.transform.position + ak.transform.forward * juli;
        transform.eulerAngles = new Vector3(ak.transform.eulerAngles.x * (-1), ak.transform.eulerAngles.y - 180.0f - pc, 0.0f);
        ak.transform.eulerAngles += new Vector3(angle_x, 0.0f, 0.0f);
        ak.transform.eulerAngles += new Vector3(0.0f, angle_y, 0.0f);


    }
}
