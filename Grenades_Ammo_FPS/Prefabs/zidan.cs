using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zidan : MonoBehaviour {
    int count = 0;
    int flag_zha;
    void OnCollisionEnter(Collision collider)
    {
        //炸弹与普通子弹区分
        if (tag == "zhadan")
        {
            flag.range = 10;
          //  if (collider.gameObject.tag == "terrian")
         //   {
                flag.zha = transform.position;
                GameObject.Destroy(gameObject, 1.9f);
                // flag.zha_flag = true;
                flag_zha = 1;
        //    }
        }
        else if (tag=="super_zhadan")
        {
            flag.range = 30;
        //    if (collider.gameObject.tag == "terrian")
         //   {
                flag.zha = transform.position;
                GameObject.Destroy(gameObject, 1.9f);
                // flag.zha_flag = true;
                flag_zha = 1;
        //    }
        }
        else
        {
            if (collider.gameObject.tag == "enermy")
            {
                if ((transform.position.y - collider.gameObject.transform.position.y) < 1.56)
                    collider.gameObject.GetComponent<enermy>().hhp -= 10;
                else
                    collider.gameObject.GetComponent<enermy>().hhp -= 100;

                GameObject.Destroy(gameObject, 0.0f);
                if (collider.gameObject.GetComponent<enermy>().hhp <= 0)
                {
                    Destroy(collider.gameObject.GetComponent<enermy>().xue, 0.0f);
                    Destroy(collider.gameObject);
                    flag.enermy_count--;
                }
            }
            else if (collider.gameObject.tag == "solider")
            {
                flag.hhp -= 10;
                if (flag.hhp <= 0)
                {
                    //    Destroy(collider.gameObject);
                }
                GameObject.Destroy(gameObject, 0.0f);
          //      Debug.Log("solider");
            }
            else
            {
                GameObject.Destroy(gameObject, 0.0f);
            }

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((tag == "zhadan"|| tag == "super_zhadan") && flag_zha == 1)
        {
            count++;
            if (count >= 45)
            {
              //  count = 0;
                flag.zha_flag = false;
                flag.zha = new Vector3(0, 0, 0);
                Debug.Log("zha");
            }
            else if (count >= 40)
            {
                flag.zha_flag = true;
            }
        }
	}
}
