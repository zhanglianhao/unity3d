using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
    public GameObject father;
    public Transform ff;
    public bool c=true;
	// Use this for initialization
	void Start () {
        father = gameObject.transform.parent.gameObject;
        ff = father.transform.GetComponentInChildren<Transform>(true);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameobj = hitInfo.collider.gameObject;
                if (gameobj == gameObject)
                {
                 //   gameobj.SetActive(false);
                 foreach(Transform aa in ff)
                    {
                      //  Debug.Log(aa.name);
                        if (aa.gameObject != gameobj)
                        {
                        //    aa.gameObject.SetActive(false);
                            if (c)
                            {
                                aa.gameObject.SetActive(false);
                              
                            }
                            else
                            {
                                aa.gameObject.SetActive(true);
                             
                            }
                        }
                    }
                    if (c)
                        c = false;
                    else
                        c = true;
                    //  gameObject.transform.lo
                }

            }
        }
    }
}
