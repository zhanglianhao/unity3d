using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class quadd : MonoBehaviour {
    public GameObject qu;
    float x,y;
    TextEditor txt;
    public int a, b;
    float aa, bb;
    float c, d;
	// Use this for initialization
	void Start () {
        x = qu.GetComponent<MeshFilter>().mesh.bounds.size.x;//父对象尺寸
        y = qu.GetComponent<MeshFilter>().mesh.bounds.size.y ;
       // Debug.Log(x);
       // Debug.Log(y);
        aa= GetComponent<MeshFilter>().mesh.bounds.size.x * transform.localScale.x+0.005f;
        bb= GetComponent<MeshFilter>().mesh.bounds.size.y * transform.localScale.y+ 0.005f;//子对象尺寸
      //  Debug.Log(aa);
      //  Debug.Log(bb);
        c = -aa / 2 - x/2;
        d = bb / 2 + y/2;//子对象放置起始位置
        transform.localPosition = new Vector3(c + (b + 1) * aa, d - (a + 1) * bb, -0.1f); 
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
                    object tempQie2 = null;
                    //txt=gameobj.GetComponent<TextEditor>();
                    GameObject.Find("text").GetComponent<TextMesh>().text = gameobj.GetComponent<Text>().text;
                    hp.color = a * 4 + b;

                }
                //   gameObject.transform.lo

            }
        }
    }
}
