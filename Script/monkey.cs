using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : MonoBehaviour {

    public GameObject player;
    public string name;
    // public GameObject zidan;
    public int range;
    float x, z, angle;
    float v = 6.0f;
    int i = 0, ran = 0;
    public float juli;
    public float jiao;
    bool flag = false;
    bool stop = false;
    Vector3 pos, wz, wz1;
    int run_walk = 0;
    int jizhong = 0;
    int ji_count = 0;
    public int time;
    // Use this for initialization
    void Start()
    {
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
    void Update()
    {
        if (Mathf.Abs(transform.position.x - x) > range || Mathf.Abs(transform.position.z - z) > range)
        {
            transform.position = new Vector3(x, 7.0f, z);
        }
        if (stop == false)
        {
            if (jizhong == 0)
            {
                if ((Mathf.Abs(x - GameObject.Find(name).transform.position.x)) < range && (Mathf.Abs(z - GameObject.Find(name).transform.position.z)) < range)
                {
                    if ((Mathf.Abs(transform.position.x - GameObject.Find(name).transform.position.x)) < juli && (Mathf.Abs(transform.position.z - GameObject.Find(name).transform.position.z)) < juli)
                    {
                        ran = 1;
                        gameObject.GetComponent<Animator>().SetInteger("id", ran);
                        //     gameObject.GetComponent<Animator>().SetInteger("run", 0);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0.0f, 90.0f - Mathf.Atan2(GameObject.Find(name).transform.position.z - transform.position.z, GameObject.Find(name).transform.position.x - transform.position.x) * 180 / Mathf.PI, 0.0f);
                        //方向调整
                        wz = transform.forward;
                        transform.eulerAngles = new Vector3(0.0f, 90.0f + 90.0f - Mathf.Atan2(GameObject.Find(name).transform.position.z - transform.position.z, GameObject.Find(name).transform.position.x - transform.position.x) * 180 / Mathf.PI, 0.0f);

                        gameObject.GetComponent<Animator>().SetInteger("id", 0);
                        //      gameObject.GetComponent<Animator>().SetInteger("run", 1);
                        transform.position += wz * Time.deltaTime * v;// * Time.deltaTime *10.0f;
                    }
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetInteger("id", 0);
                    //         gameObject.GetComponent<Animator>().SetInteger("run", 0);
                    flag = false;
                    run_walk = 0;
                    while (flag != true)
                    {
                        angle = Random.Range(-jiao, jiao);
                        //   Debug.Log(transform.eulerAngles);
                        transform.Rotate(new Vector3(0.0f, angle - 90.0f, 0.0f));
                        wz1 = transform.forward;
                        transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                        pos = transform.position + wz1 * Time.deltaTime * v * 0.4f;
                        if (Mathf.Abs(pos.x - x) < range && Mathf.Abs(pos.z - z) < range)

                        {
                            flag = true;
                            transform.position = pos;
                        }

                        else
                        {
                            flag = false;
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
        }
        else
            stop = false;


    }
}
