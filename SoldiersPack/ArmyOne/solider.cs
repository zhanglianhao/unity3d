using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class solider : MonoBehaviour {
    public GameObject current;
    public GameObject gun;
    public Slider xueliang;
    public int hhp;
    public float barUpLength = 3.0f;
    public float gun_barUpLength;
    GameObject aa,cc;
    float v = 10.0f;
    float shuiping, shuzhi;
    public GameObject cam;
    public Color cu,old;
    int walk_run = 0;
    public GameObject wq;
    public GameObject menu;
    public Vector3  angle;
    void OnCollisionStay(Collision collider)
    {
        int i = 0;
      //  Debug.Log(collider.gameObject.name);
      //拾捡对应序号枪支
        for (i = 1; i <= 6; i++)
        {
            if (wq.transform.GetChild(i).gameObject == collider.gameObject)
            {
                flag.active[i] = true;
                menu.transform.GetChild(i).gameObject.GetComponent<Image>().color = cu;
                collider.gameObject.SetActive(false);
            }
        }

        if (collider.gameObject.tag == "1")
        {
            flag.weakon[1].count += 10;
            Debug.Log(123);
            Destroy(collider.gameObject,0.0f);
        }
        else if (collider.gameObject.tag == "2")
        {
            Debug.Log(123);
            flag.weakon[2].count += 10;
            Destroy(collider.gameObject, 0.0f);
        }
        else if (collider.gameObject.tag == "3")
        {
            Debug.Log(123);
            flag.weakon[3].count += 10;
            Destroy(collider.gameObject, 0.0f);
        }
        else if (collider.gameObject.tag == "4")
        {
            Debug.Log(123);
            flag.weakon[4].count += 10;
            Destroy(collider.gameObject, 0.0f);
        }
        else if (collider.gameObject.tag == "5")
        {
            Debug.Log(123);
            flag.weakon[5].count += 10;
            Destroy(collider.gameObject, 0.0f);
        }
        else if (collider.gameObject.tag == "6")
        {
            Debug.Log(123);
            flag.weakon[6].count += 10;
            Destroy(collider.gameObject, 0.0f);
        }


    }
        void Start()
    {
    }

    //血条控制
    public  void xue()
    {
        //   xueliang.value = flag.hhp / 100.0f;
        xueliang.value = xueliang.value-(xueliang.value- (flag.hhp / 100.0f))*0.1f;
        if(!gun.activeSelf)
             xueliang.transform.position = new Vector3(transform.position.x, transform.position.y + barUpLength, transform.position.z);
        else
             xueliang.transform.position = new Vector3(gun.GetComponent<gun>().current.transform.position.x, gun.GetComponent<gun>().current.transform.position.y + gun_barUpLength, gun.GetComponent<gun>().current.transform.position.z)+cam.transform.forward*2;

        xueliang.transform.eulerAngles = new Vector3(0.0f, cam.transform.eulerAngles.y, 0.0f);
      
    }
    // Update is called once per frame
    void Update()
    {
        xue();
       
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        //自由视觉移动
        gameObject.GetComponent<Animator>().SetInteger("walk", 0);
        gameObject.GetComponent<Animator>().SetInteger("run", 0);
        shuiping = Input.GetAxis("Horizontal");
        shuzhi = Input.GetAxis("Vertical");
 
        if (shuiping != 0 || shuzhi != 0)
        {
            transform.eulerAngles = new Vector3(0.0f, 90 - Mathf.Atan2(shuzhi, shuiping) * 180 / Mathf.PI + cam.transform.eulerAngles.y, 0.0f);

            if (walk_run == (-1))
            {
                gameObject.GetComponent<Animator>().SetInteger("run", 1);
                gameObject.GetComponent<Animator>().SetInteger("walk", 0);
                transform.position += transform.forward * Time.deltaTime * v;
            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * v * 0.3f;
                gameObject.GetComponent<Animator>().SetInteger("run", 0);
                gameObject.GetComponent<Animator>().SetInteger("walk", 1);
            }
        }


        if (Input.GetKeyUp(KeyCode.LeftAlt))//走路奔跑切换
        {
            walk_run = ~walk_run;
            Debug.Log(walk_run);

        }


        //丢弃当前枪支
        if (Input.GetKeyUp(KeyCode.LeftControl) && menu.GetComponent<Menu>().oldItemIndex != 0)
        {
            flag.active[menu.GetComponent<Menu>().oldItemIndex] = false;
            menu.transform.GetChild(menu.GetComponent<Menu>().oldItemIndex).GetComponent<Image>().color = old;

            //  Debug.Log(menu.GetComponent<Menu>().oldItemIndex);
            //  Debug.Log(old);

            transform.GetChild(menu.GetComponent<Menu>().oldItemIndex+2).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
 
            menu.transform.GetChild(0).GetComponent<Image>().color = menu.GetComponent<Menu>().heightColor;
            menu.GetComponent<Menu>().nomorlColor = cu;

            cc = wq.transform.GetChild(menu.GetComponent<Menu>().oldItemIndex).gameObject;
            cc.SetActive(true);
            cc.transform.position = current.transform.position+transform.right*2;
            cc.transform.eulerAngles = current.transform.eulerAngles;

            menu.GetComponent<Menu>().oldItemIndex = 0;
            flag.current = 0;


        }

        //进入枪支瞄准模式，游戏对象从solider转入gun
        if (Input.GetMouseButtonDown(1))
        {
          
            gun.GetComponent<gun>().enabled = true;
            gun.GetComponent<gun>().current.transform.position = transform.position+new Vector3(0.0f,1.0f,0.0f);
            if (menu.GetComponent<Menu>().oldItemIndex <= 2 && menu.GetComponent<Menu>().oldItemIndex >= 1)
            {
                gun.GetComponent<gun>().current.transform.eulerAngles = transform.eulerAngles + new Vector3(0.0f, 180.0f, 0.0f);
              
            }
            else
            {
                gun.GetComponent<gun>().current.transform.eulerAngles = transform.eulerAngles;
               
            }
            gun.GetComponent<gun>().current.transform.position += transform.forward * 2;
            gun.GetComponent<gun>().center = gun.GetComponent<gun>().current.transform.eulerAngles.y;

            //  Debug.Log(gun.GetComponent<gun>().current.transform.eulerAngles);
            angle =cam.GetComponent<camera>().transform.eulerAngles;
            cam.GetComponent<camera>().enabled = false;
            cam.GetComponent<gun_camera>().enabled = true;
            gun.SetActive(true);
           // gameObject.SetActive(false);
            enabled = false;
            
        }

    }
    
}
