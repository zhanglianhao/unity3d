using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject cannon;
    public int cannon_count;
    public GameObject[] zd;
    public int count;
    public GameObject A;
    public GameObject robet;
    public GameObject enermy;
    public float enermy_height=1.0f;
    public float zidan_height = 0.5f;
    public float cannon_height = 4.0f;
    public GameObject menu;
    public int enermy_count;
    public int v = 10;
    public  float angle;
    public int min, max;
    bool a = true;
    int i = 0;
    Vector3 pos;
    Quaternion jiaodu;
    public  float x, y, z;
   
    // Use this for initialization
    void Start () {
        flag.enermy_count = enermy_count;


        for (i = 0; i < enermy_count; i++)
        {
            GameObject  go = GameObject.Instantiate(enermy,  new Vector3(Random.Range(min,max), enermy_height, Random.Range(min, max)),robet.transform.rotation) as GameObject;

        }
        for (i = 0; i < count; i++)
        {
            foreach (GameObject a in zd)
              Instantiate(a, new Vector3(Random.Range(min, max), zidan_height, Random.Range(min, max)), robet.transform.rotation);
        }
        for (i = 0; i < cannon_count; i++)
        {
            Instantiate(cannon, new Vector3(Random.Range(min, max), cannon_height, Random.Range(min, max)), robet.transform.rotation);
        }

        //敌人数量及出生地点配置
	}
	
	// Update is called once per frame
	void Update () {
    /*     if (hp.flag == 0)
         {
             transform.eulerAngles = robet.transform.eulerAngles;
             transform.position = new Vector3(robet.transform.position.x + robet.transform.forward.x * x, robet.transform.position.y + y, robet.transform.position.z + robet.transform.forward.z * z);
         }
         else
         {
             transform.eulerAngles = new Vector3(0, robet.transform.eulerAngles.y - 180, 0);
             transform.position = new Vector3(robet.transform.position.x - robet.transform.forward.x * x, robet.transform.position.y + y, robet.transform.position.z - robet.transform.forward.z * z);

         }
     */  
      /*  if (hp.flag == 0)
        {
            transform.eulerAngles =new Vector3( robet.transform.eulerAngles.x, robet.transform.eulerAngles.y+90, robet.transform.eulerAngles.z);
            transform.position = new Vector3(robet.transform.position.x + robet.transform.right.x * x, robet.transform.position.y + y, robet.transform.position.z + robet.transform.right.z * z);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, robet.transform.eulerAngles.y - 90, 0);
            transform.position = new Vector3(robet.transform.position.x - robet.transform.right.x * x, robet.transform.position.y + y, robet.transform.position.z - robet.transform.right.z * z);

        }
*/
        // transform.position = robet.transform.position + new Vector3(x,y,z);//第三人称控制相机视角

        // transform.eulerAngles = robet.transform.eulerAngles;
        //transform.position = robet.transform.position;
        // transform.Translate( new Vector3(0.0f, 3.0f, -9.0f));

        /*   if (Input.GetKey("w"))
           {
               transform.Translate(transform.forward * Time.deltaTime * v);
               //   Debug.Log(A.transform.position);
           }
           else if (Input.GetKey("s"))
           { transform.Translate(transform.forward * Time.deltaTime * (-v)); }
           else if (Input.GetKey("a"))
           { transform.Translate(transform.right * Time.deltaTime * (-v)); }
           else if (Input.GetKey("d"))
           { transform.Translate(transform.right * Time.deltaTime * v); }
           else if (Input.GetKey("q"))
           { transform.Translate(transform.up * Time.deltaTime * (-v)); }
           else if (Input.GetKey("e"))
           { transform.Translate(transform.up * Time.deltaTime * v); }
           */
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           // menu.SetActive(true);
        }

        //在solider模式下，相机视角可以自由调节
        /*   if (Input.GetKey(KeyCode.Q))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y-angle,transform.eulerAngles.z);
               // transform.Rotate(0.0f, -1 * angle, 0.0f);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + angle, transform.eulerAngles.z);
                //transform.Rotate(0.0f, angle, 0.0f);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x - angle, transform.eulerAngles.y , transform.eulerAngles.z);
                // transform.Rotate(-1 * angle, 0.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.C))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x + angle, transform.eulerAngles.y, transform.eulerAngles.z);
              //  transform.Rotate(angle, 0.0f, 0.0f);
            }
      */

        //鼠标控制视角
        if (!menu.activeSelf)
        {
            jiaodu.eulerAngles = new Vector3((Input.mousePosition.y - (Screen.height / 2)) / (Screen.height / 2) * -50.0f, (Input.mousePosition.x - (Screen.width / 2)) / (Screen.width / 2) * 180, 0.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, jiaodu, 0.1f);
        }
        pos = robet.transform.position-transform.forward*z;
      //  Debug.Log(pos);
        pos.y = robet.transform.position.y+y;
        transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
       


    }
}
