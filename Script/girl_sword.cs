﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl_sword : MonoBehaviour {

    float v = 10.0f;
    public float angle;
    int i = 0;
    int count = 0;
    GameObject go;
    bool flag = true;
    int roll = 0;
    public int bz;
    int jump;
    public int jump_time;
    bool jump_flag = false;
    bool f = false;
    int walk_run = 0;
    int fan = 1, start = 1;
    // public static int hp;
    // Use this for initialization
    void Start()
    {
        // transform.eulerAngles = a.transform.eulerAngles;
        transform.position = new Vector3(10.0f, 7.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //    Debug.Log(transform.position);
        //   Debug.Log(transform.eulerAngles);
        // transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        if (f)
        {
            if (roll++ >= bz)
            {
                roll = 0; f = false;
            }
            transform.position -= transform.forward * Time.deltaTime * v;
        }
        if (jump_flag)
        {
            if (jump++ >= jump_time)
            {
                jump = 0; jump_flag = false;
            }
            transform.position += transform.up * Time.deltaTime * v * 1.5f;
        }
        gameObject.GetComponent<Animator>().SetInteger("walk", 0);
        gameObject.GetComponent<Animator>().SetInteger("run", 0);
        if (Input.GetKey(KeyCode.W))
        {
            hp.flag = 0;
            if (fan == 0)
            {
                fan = 1;
                transform.Rotate(new Vector3(0, 180, 0));

            }

            // transform.Translate(transform.forward * Time.deltaTime * v);
            //  transform.eulerAngles=new Vector3(0.0f,0.0f,0.0f);
            if (walk_run == (-1))
            {
                gameObject.GetComponent<Animator>().SetInteger("run", 1);
                gameObject.GetComponent<Animator>().SetInteger("walk", 0);
                transform.position += transform.right * Time.deltaTime * v;
            }
            else
            {
                transform.position += transform.right * Time.deltaTime * v * 0.3f;
                gameObject.GetComponent<Animator>().SetInteger("run", 0);
                gameObject.GetComponent<Animator>().SetInteger("walk", 1);
            }

            //  Debug.Log(transform.right);
            //   Debug.Log(A.transform.position);
        }

        if (Input.GetKey(KeyCode.S))
        {

            hp.flag = 1;
            if (fan == 1)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                fan = 0;
            }

            if (walk_run == (-1))
            {
                gameObject.GetComponent<Animator>().SetInteger("run", 1);
                gameObject.GetComponent<Animator>().SetInteger("walk", 0);
                transform.position += transform.right * Time.deltaTime * v;
            }
            else
            {
                transform.position += transform.right * Time.deltaTime * v * 0.3f;
                gameObject.GetComponent<Animator>().SetInteger("run", 0);
                gameObject.GetComponent<Animator>().SetInteger("walk", 1);
            }
            // Debug.Log(transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        { //transform.Translate(transform.right * Time.deltaTime * (-v));
          //  transform.eulerAngles = new Vector3(0.0f,90.0f, 0.0f);     //第三人称控制

            //  gameObject.GetComponent<Animator>().SetInteger("run", 0);
            if (hp.flag == 0)
                transform.Rotate(new Vector3(0, angle, 0));
            else
                transform.Rotate(new Vector3(0, -1 * angle, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {// transform.Translate(transform.right * Time.deltaTime * v);
         //   transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
         // gameObject.GetComponent<Animator>().SetInteger("run", 0);
         //   Debug.Log(transform.right);
            if (hp.flag == 0)
                transform.Rotate(new Vector3(0, -1 * angle, 0));
            else
                transform.Rotate(new Vector3(0, angle, 0));
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))//走路奔跑切换
        {
            walk_run = ~walk_run;
            Debug.Log(walk_run);

        }

        //gameObject.GetComponent<Animator>().SetInteger("run", 0);
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //  count++;
            //  if (count <= 2)
            //  gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 4.0f, 0.0f);
            gameObject.GetComponent<Animator>().SetInteger("jump", 1);


            // Debug.Log(gameObject.GetComponent<Animator>().GetInteger("jump"));
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))//翻滚
        {
            gameObject.GetComponent<Animator>().SetInteger("jump", 0);
            f = true;
            roll = 0;

        }
        if (Input.GetKeyDown(KeyCode.Space))// 跳跃
        {
            gameObject.GetComponent<Animator>().SetInteger("roll", 1);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetInteger("roll", 0);
            jump_flag = true;
        }
        //   if (transform.position.y < 0.51f)
        //    count = 0;
        if (Input.GetKeyDown(KeyCode.M))//格斗动作
        {
            i++;
            gameObject.GetComponent<Animator>().SetInteger("id", i);

            Debug.Log(gameObject.GetComponent<Animator>().GetInteger("id"));
            if (i == 4)
                i = 0;
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            gameObject.GetComponent<Animator>().SetInteger("id", 0);

        }
        if (Input.GetKeyDown(KeyCode.P))//子弹
        {
            if (hp.color == 0)
            {
                go = GameObject.Instantiate(green, transform.position + new Vector3(0.0f, 5.0f, 0.0f), transform.rotation) as GameObject;
            }
            else if (hp.color == 1)
            {
                go = GameObject.Instantiate(red, transform.position + new Vector3(0.0f, 5.0f, 0.0f), transform.rotation) as GameObject;
            }
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * 20.0f;


        }
        

        if (Input.GetKeyUp(KeyCode.Tab))//武器切换
        {
            if (flag)
            {
                equip.SetActive(true);
                flag = false;

            }
            else
            {
                flag = true;
                equip.SetActive(false);
            }
        }
        */

    }
}
