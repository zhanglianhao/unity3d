using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enermy : MonoBehaviour {
    public GameObject player;
    public GameObject zidan;
    public GameObject xueliang;
    public int hhp;
    public int range;
    public int count;
    int j;
    Vector3 forward;
    public int attack_range;
    float x, z,angle;
    float v = 6.0f;
    int i = 0,ran=0;
    public float juli;
    public float jiao;
    bool flag_f = false;
    bool stop = false;
    Vector3 pos;
    float x_angle;
    int run_walk=0;
    int jizhong = 0;
    int ji_count = 0;
    public int time;
    public float barUpLength;
    public  GameObject xue;
    Camera current;
	// Use this for initialization
	void Start () {
       
        xue=Instantiate(xueliang);
        current=GameObject.FindGameObjectWithTag("camera").GetComponent<Camera>();
        xue.GetComponent<Canvas>().worldCamera = current;
        Debug.Log(Camera.current);
        x = transform.position.x;
        z = transform.position.z;
	}
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "equip")
        {
            if (Mathf.Abs((transform.position + transform.forward * (-1) * 3.0f).x - x) < range && Mathf.Abs((transform.position + transform.forward * (-1) * 3.0f).z - z) < range)
            {//  transform.position += transform.forward * (-1) * 5.0f;
                jizhong = 1;
                ji_count = 0;
            }
            // Debug.Log(1);
        }
        else if (collider.tag == "energy")
        {
            stop = true;
            transform.position -= transform.forward * 1.5f;

        }
       // Debug.Log(1);
    }

    // Update is called once per frame
    void Update () {



        //   血条控制
            xue.transform.GetChild(0).transform.position = new Vector3(transform.position.x, transform.position.y + barUpLength, transform.position.z);

            xue.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, current.transform.eulerAngles.y, 0.0f);
            xue.transform.GetChild(0).GetComponent<Slider>().value = xue.transform.GetChild(0).GetComponent<Slider>().value - (xue.transform.GetChild(0).GetComponent<Slider>().value - (hhp / 100.0f)) * 0.1f;


        if (Mathf.Abs(transform.position.x - x) > range || Mathf.Abs(transform.position.z - z) > range)
        {
            transform.position = new Vector3(x, 1.0f, z);
        }
     //   Debug.Log(flag.zha_flag);
        if (flag.zha_flag&&Mathf.Abs(flag.zha.x - transform.position.x) < flag.range && Mathf.Abs(flag.zha.z - transform.position.z) < flag.range)
        {
            Destroy(xue,0.0f);
            Destroy(gameObject, 0.0f);
            flag.enermy_count--;
        }
        /*  if (i++ >= 0)
         {
           GameObject go = GameObject.Instantiate(zidan, transform.position + new Vector3(0.0f, 5.0f, 0.0f), transform.rotation) as GameObject;
             i = 0;
             go.GetComponent<Rigidbody>().velocity = go.transform.forward * 20.0f;
             Debug.Log(transform.position);
             Debug.Log(player.transform.position);
             transform.Translate((player.transform.position - transform.position) * Time.deltaTime * v);
         }
         *///弹药
           /* if ((Mathf.Abs(transform.position.x - GameObject.Find("solider").transform.position.x)) < juli && (Mathf.Abs(transform.position.z - GameObject.Find("solider").transform.position.z)) < juli)
            {
                ran=(int)(Random.Range(1.0f, 7.0f));
                gameObject.GetComponent<Animator>().SetInteger("id",ran );
                gameObject.GetComponent<Animator>().SetInteger("run", 0);
            }
            else if ((Mathf.Abs(transform.position.x - GameObject.Find("solider").transform.position.x)) < range && (Mathf.Abs(transform.position.z - GameObject.Find("solider").transform.position.z)) < range)

            {

                transform.eulerAngles = new Vector3(0.0f,90.0f-Mathf.Atan2(GameObject.Find("solider").transform.position.z - transform.position.z, GameObject.Find("solider").transform.position.x - transform.position.x) * 180 / Mathf.PI, 0.0f);
                //方向调整
                gameObject.GetComponent<Animator>().SetInteger("id", 0);
                gameObject.GetComponent<Animator>().SetInteger("run", 1);
                transform.position += transform.forward * Time.deltaTime * v;// * Time.deltaTime *10.0f;
               // Debug.Log(Time.deltaTime);
            }
            *///靠近追击
              //   if (stop == false)
              //   {
        if (jizhong == 0)
            {

            //enermy与solider距离大于attack_range时，敌人在range范围内自由移动;
            //当enermy与solider距离小于attack_range，大于range时，敌人停止移动，面向solider进行射击;
            //当enermy与solider距离小于range时，敌人向solider移动;
            //当enermy与solider距离小于juli时,敌人可进行相应攻击动作
            if ((Mathf.Abs(x - GameObject.Find("solider").transform.position.x)) < range && (Mathf.Abs(z - GameObject.Find("solider").transform.position.z)) < range)
            {
                if ((Mathf.Abs(transform.position.x - GameObject.Find("solider").transform.position.x)) < juli && (Mathf.Abs(transform.position.z - GameObject.Find("solider").transform.position.z)) < juli)
                {
                    ran = (int)(Random.Range(1.0f, 7.0f));
                    //   gameObject.GetComponent<Animator>().SetInteger("id", ran);
                    //  gameObject.GetComponent<Animator>().SetInteger("run", 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0.0f, 90.0f - Mathf.Atan2(GameObject.Find("solider").transform.position.z - transform.position.z, GameObject.Find("solider").transform.position.x - transform.position.x) * 180 / Mathf.PI, 0.0f);
                    //方向调整
                    //   gameObject.GetComponent<Animator>().SetInteger("id", 0);
                    //    gameObject.GetComponent<Animator>().SetInteger("run", 1);
                    transform.position += transform.forward * Time.deltaTime * v;// * Time.deltaTime *10.0f;
                }
            }
            else if ((Mathf.Abs(x - GameObject.Find("solider").transform.position.x)) < attack_range && (Mathf.Abs(z - GameObject.Find("solider").transform.position.z)) < attack_range)
            {
                transform.eulerAngles = new Vector3(0.0f, 90.0f - Mathf.Atan2(GameObject.Find("solider").transform.position.z - transform.position.z, GameObject.Find("solider").transform.position.x - transform.position.x) * 180 / Mathf.PI, 0.0f);

                x_angle = Mathf.Atan2(GameObject.Find("solider").transform.position.y+1.0f-(transform.position.y+1.1f),Mathf.Sqrt(Mathf.Pow(transform.position.x- GameObject.Find("solider").transform.position.x,2)+ Mathf.Pow(transform.position.z - GameObject.Find("solider").transform.position.z, 2))) * 180 / Mathf.PI;
                //Debug.Log(x_angle);
                if (++j >= count)
                {
                    transform.Rotate(-1 * x_angle, 0.0f, 0.0f);
                    j = 0;
                    GameObject aa = GameObject.Instantiate(zidan,new Vector3(transform.position.x,transform.position.y+1.1f,transform.position.z)+new Vector3(transform.forward.x,0.0f,transform.forward.z)*1, transform.rotation);
                    aa.GetComponent<Rigidbody>().velocity = transform.forward * 50;
                    GameObject.Destroy(aa, 5.0f);
                    transform.Rotate(x_angle, 0.0f, 0.0f);
                }
            }
            else
            {
                    //  gameObject.GetComponent<Animator>().SetInteger("id", 0);
                    //  gameObject.GetComponent<Animator>().SetInteger("run", 0);
                    flag_f = false;
                run_walk = 0;
                while (flag_f != true)
                {
                    angle = Random.Range(-jiao, jiao);
                    //   Debug.Log(transform.eulerAngles);
                    transform.Rotate(new Vector3(0.0f, angle, 0.0f));


                    pos = transform.position + transform.forward * Time.deltaTime * v * 0.4f;
                    if (Mathf.Abs(pos.x - x) < range && Mathf.Abs(pos.z - z) < range)

                    {
                            flag_f = true;
                        transform.position = pos;
                    }

                    else
                    {
                            flag_f = false;
                        // transform.Rotate(new Vector3(0.0f, -1 * angle, 0.0f));
                    }

                }
            }
            }
            else
            {
                if (ji_count++ >= time)
                {
                   // Debug.Log(1111);
                    ji_count = 0;
                    jizhong = 0;
                  
                }
                transform.position -= transform.forward * Time.deltaTime * v * 0.4f;


            }
     //   }
   //     else
  //          stop = false;
                
                
                }
}
