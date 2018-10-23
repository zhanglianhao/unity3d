using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_camera : MonoBehaviour {

    public GameObject ak;
    public GameObject menu;
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

        //相机根据当前枪支进行视觉移动
        //transform.eulerAngles = new Vector3(ak.transform.eulerAngles.x * (-1), ak.transform.eulerAngles.y - 180.0f-pc, 0.0f);
        // transform.eulerAngles = new Vector3(0.0f, ak.transform.eulerAngles.y - 90.0f, 0.0f);

        //对相机角度进行自由偏差的修正
   /*     ak.transform.eulerAngles += new Vector3(0.0f, -1 * angle_y, 0.0f);
        ak.transform.eulerAngles -= new Vector3(angle_x, 0.0f, 0.0f);
        transform.position = ak.transform.position + ak.transform.forward * juli;
        if (menu.GetComponent<Menu>().oldItemIndex <= 2 && menu.GetComponent<Menu>().oldItemIndex >= 1)
        {
            transform.eulerAngles = new Vector3(ak.transform.eulerAngles.x * (-1), ak.transform.eulerAngles.y - 180.0f - pc, 0.0f);
            transform.position = ak.transform.position + ak.transform.forward * juli;
        }
        else
        {
            transform.eulerAngles = new Vector3(ak.transform.eulerAngles.x * (-1), ak.transform.eulerAngles.y - pc, 0.0f);
            transform.position = ak.transform.position - ak.transform.forward * juli;
        }
        ak.transform.eulerAngles += new Vector3(angle_x, 0.0f, 0.0f);
        ak.transform.eulerAngles += new Vector3(0.0f, angle_y, 0.0f);
*/
        transform.eulerAngles = ak.transform.GetChild(0).eulerAngles;
        transform.position = ak.transform.GetChild(0).position - ak.transform.GetChild(0).forward * 1;


    }
}
