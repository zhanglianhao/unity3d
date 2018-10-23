using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip1 : MonoBehaviour {
    Vector3 angle,old_angle,player_angle;
    public GameObject jie;
    public GameObject player;
    public GameObject guanjie;
    public float juli;
    int flag = 0;
    int count = 0;
    bool start = false;
    float v=20.0f;
    float roll = 0;
    float strength=0;
	// Use this for initialization
	void Start () {
        //transform.eulerAngles = new Vector3(0, 0, 0);
        // transform.localEulerAngles = new Vector3(153, -19, 49.9f);
        angle =-1*( new Vector3(0.0f, 0.0f, 0.0f) - jie.transform.eulerAngles);
        transform.eulerAngles = jie.transform.eulerAngles;
        transform.position = jie.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            transform.Rotate(new Vector3(0, 2*v, 0));
            if (flag == 0)
                transform.position += player_angle * Time.deltaTime * v;
            else
            { //transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * v;
              //   transform.position += new Vector3(jie.transform.position.x - transform.position.x, jie.transform.position.y - transform.position.y, jie.transform.position.z - transform.position.z) * Time.deltaTime;
                old_angle = transform.eulerAngles;
                transform.eulerAngles = new Vector3(0.0f, 90.0f - Mathf.Atan2(GameObject.Find("Robot Kyle").transform.position.z - transform.position.z, GameObject.Find("Robot Kyle").transform.position.x - transform.position.x) * 180 / Mathf.PI, 0.0f);
                transform.position += transform.forward * Time.deltaTime * v;
                transform.eulerAngles =  old_angle;

            }
            if (count++ >= strength)
            {
                count = 0;
                flag = 1;
            }
            if (flag == 1 && (Mathf.Abs(transform.position.x - jie.transform.position.x)) < juli && (Mathf.Abs(transform.position.z - jie.transform.position.z)) < juli)
            {

                flag = 0;
                count = 0;
                start = false;
                strength = 0;
            }
        }
        else
        {
            transform.eulerAngles = jie.transform.eulerAngles+angle;
            transform.position = jie.transform.position;
          /*  transform.position = player.transform.position + new Vector3(2 * Mathf.Sin(roll / 180*Mathf.PI), 1, 2 * Mathf.Cos(roll / 180 * Mathf.PI));
            roll += 10;
            if (roll >= 360)
            {
                roll = 0;
            }
            */
        }
        if (Input.GetMouseButtonUp(0))
        {
            start = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            player_angle = player.transform.forward;
            Debug.Log(transform.forward);

        }
        else if (Input.GetMouseButton(0))
        {
            strength++;
            transform.eulerAngles = new Vector3(0.0f, player.transform.eulerAngles.y+ 90+strength, 0.0f);
           // Debug.Log(guanjie.transform.eulerAngles);
        }
        
        // guanjie.transform.eulerAngles = new Vector3(0.0f, 90, 0.0f);
        //Debug.Log(guanjie.transform.eulerAngles);  //对于机器人整体来说，它的关节子对象不能通过程序修改位置
    }
}
