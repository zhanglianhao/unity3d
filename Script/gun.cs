using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gun : MonoBehaviour {
    public GameObject wq;
    public GameObject solider;
    public GameObject menu;
    public GameObject cam;
    public GameObject current;
    public float center;
    public float center_range;
    float v = 10.0f;
    public GameObject[] zd;
   // public GameObject wz;
    public float angle;
    public float juli;
    public Color cu;
    public Color  old;
    GameObject aa;
    GameObject cc;
    Vector3 sd;
    public int count;
    int jishu = 0;
    int walk_run = 0;

    // Use this for initialization
    void Start () {
        jishu = count;
	}
	
	// Update is called once per frame
	void Update () {
        solider.GetComponent<solider>().xue();
     /*   if (Input.GetKeyUp(KeyCode.LeftControl)&& menu.GetComponent<Menu>().oldItemIndex!=0)
        {
           flag.active[menu.GetComponent<Menu>().oldItemIndex] = false;
            menu.transform.GetChild(menu.GetComponent<Menu>().oldItemIndex).GetComponent<Image>().color = old;

          //  Debug.Log(menu.GetComponent<Menu>().oldItemIndex);
          //  Debug.Log(old);

            aa = current;
            current = transform.GetChild(0).gameObject;
            current.SetActive(true);
            menu.transform.GetChild(0).GetComponent<Image>().color = menu.GetComponent<Menu>().heightColor;
            menu.GetComponent<Menu>().nomorlColor = cu;


            current.transform.position = aa.transform.position;
            current.transform.eulerAngles = aa.transform.eulerAngles;

            cam.GetComponent<gun_camera>().ak = current;
           

            cc=wq.transform.GetChild(menu.GetComponent<Menu>().oldItemIndex).gameObject;
            cc.SetActive(true);
            cc.transform.position = current.transform.position;
            cc.transform.eulerAngles = current.transform.eulerAngles;

            menu.GetComponent<Menu>().oldItemIndex = 0;

            aa.SetActive(false);
        }
        */
   /*     if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            flag.active[1] = true;
            menu.transform.GetChild(1).gameObject.GetComponent<Image>().color = cu;

            // menu.transform.GetChild(1).gameObject.GetComponent<Image>().color = old;

        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            flag.active[2] = true;
            menu.transform.GetChild(2).gameObject.GetComponent<Image>().color = cu;
          
        }
       */
    /*    if (Input.GetKey(KeyCode.W))
        {
            sd = new Vector3(current.transform.forward.x, 0.0f, current.transform.forward.z);
            // transform.Translate(transform.forward * Time.deltaTime * v);
            //  transform.eulerAngles=new Vector3(0.0f,0.0f,0.0f);

            if (walk_run == (-1))
            {
                current.transform.position -= sd * Time.deltaTime * v;
            }
            else
            {
                current.transform.position -= sd * Time.deltaTime * v * 0.3f;

            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            sd = new Vector3(current.transform.forward.x, 0.0f, current.transform.forward.z);

            if (walk_run == (-1))
            {
                current.transform.position += sd * Time.deltaTime * v;
            }
            else
            {
                current.transform.position += sd * Time.deltaTime * v * 0.3f;

            }
            // Debug.Log(transform.right);
        }
        */
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            if (walk_run != -1)
                walk_run = -1;
            else
                walk_run = 0;
        }

        //进入瞄准模式后，枪支只能进行上下左右方向偏转，且左右偏转最大角度可以调整
        /*     if (Input.GetKey(KeyCode.D))
             {
                 if(current.transform.eulerAngles.y<(center+center_range))
                 current.transform.eulerAngles += new Vector3(0, angle, 0);

             }
             if (Input.GetKey(KeyCode.A))
             {
                 if (current.transform.eulerAngles.y > (center - center_range))
                     current.transform.eulerAngles -= new Vector3(0, angle, 0);


             }
             if (Input.GetKey(KeyCode.S))
             {
                 if (flag.current <= 2 && flag.current >= 1)
                 {
                     current.transform.eulerAngles -= new Vector3(angle, 0.0f, 0.0f);
                 //    Debug.Log(current.transform.eulerAngles.x);
                 }
                 else

                     current.transform.eulerAngles += new Vector3(angle, 0.0f, 0.0f);
             }
             if (Input.GetKey(KeyCode.W))
             {
                 if (flag.current <= 2 && flag.current >= 1)
                     current.transform.eulerAngles += new Vector3(angle, 0.0f, 0.0f);
                 else
                     current.transform.eulerAngles -= new Vector3(angle, 0.0f, 0.0f);
             }
     */

        //    Debug.Log(Screen.width);
        //    Debug.Log(Input.mousePosition.y);

        if (!menu.activeSelf)
        {
            if (flag.current <= 2 && flag.current >= 1)
                current.transform.eulerAngles = new Vector3((Input.mousePosition.y - (Screen.height / 2)) / (Screen.height / 2) * 30.0f, center + (Input.mousePosition.x - (Screen.width / 2)) / (Screen.width / 2) * center_range, 0.0f);
            else
                current.transform.eulerAngles = new Vector3((Input.mousePosition.y - (Screen.height / 2)) / (Screen.height / 2) * -30.0f, center + (Input.mousePosition.x - (Screen.width / 2)) / (Screen.width / 2) * center_range, 0.0f);
        }



        //射击
        if (Input.GetMouseButton(0) && menu.GetComponent<Menu>().oldItemIndex != 0)
        {
            //子弹放射时间间隔，可以修改
            if (jishu++ >= count && flag.weakon[menu.GetComponent<Menu>().oldItemIndex].count > 0)
            {
                jishu = 0;
                flag.weakon[menu.GetComponent<Menu>().oldItemIndex].count--;
                //current.transform.eulerAngles -= new Vector3(0, 90.0f, 0);
                //GameObject a = GameObject.Instantiate(zd, transform.position - transform.forward * juli, transform.rotation);
                GameObject a = GameObject.Instantiate(zd[menu.GetComponent<Menu>().oldItemIndex - 1], current.transform.GetChild(0).position, current.transform.GetChild(0).rotation);
                // current.transform.eulerAngles += new Vector3(0, 90.0f, 0);
                //  Debug.Log(a.transform.position);
                //  Debug.Log(wz.transform.position);
                a.GetComponent<Rigidbody>().velocity = a.transform.forward * 50;
                GameObject.Destroy(a, 5.0f);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            jishu = count ;
        }
        
        //将游戏对象从gun转入solider对象
        if (Input.GetMouseButtonUp(1))
        {
            
            solider.GetComponent<solider>().enabled = true;
            cam.GetComponent<gun_camera>().enabled = false;
            cam.GetComponent<camera>().enabled = true;

            //将相机角度变换为枪支切换前的角度
            cam.GetComponent<camera>().transform.eulerAngles = solider.GetComponent<solider>().angle;
          //  solider.SetActive(true);
            if (menu.GetComponent<Menu>().oldItemIndex <= 2 && menu.GetComponent<Menu>().oldItemIndex >= 1)
                solider.transform.eulerAngles = new Vector3(solider.transform.eulerAngles.x, current.transform.eulerAngles.y + 180, solider.transform.eulerAngles.z);
            else
                solider.transform.eulerAngles = new Vector3(solider.transform.eulerAngles.x, current.transform.eulerAngles.y, solider.transform.eulerAngles.z);
       //     Debug.Log(solider.transform.eulerAngles);
       //     Debug.Log(current.transform.eulerAngles);
            current.transform.parent.gameObject.SetActive(false);
            enabled = false;
        }

    }
}
