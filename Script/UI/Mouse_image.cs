using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mouse_image : MonoBehaviour {
    public Sprite UI;
    public Sprite UInone;
    public GameObject menu;
    Image aa;
    // Use this for initialization
    void Start () {
        aa = GetComponent<Image>();
       
	}
	
	// Update is called once per frame
	void Update () {
        /*
         if (dianji.flag == 1)
         {
             aa.sprite = UI;
         }
         else
         {
             aa.sprite = null;
         }
         */
        aa.sprite = dianji.img;
        //aa.sprite = UI;
        aa.color = dianji.col;
          transform.position = new Vector3(Input.mousePosition.x - 60, Input.mousePosition.y + 40,0.0f);
        //transform.localPosition = new Vector3(Input.mousePosition.x , Input.mousePosition.y ,0.0f);
    
    }
}
public class dianji
{
    public static int flag=0;
    public static Sprite img=null;
    public static Color col;
}
