using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class terrain : MonoBehaviour {
    public GameObject cc;
    public GameObject menu;
   
    public Text text;
   // bool flag=true;
    // Use this for initialization
    void Start () {
        for (int i = 1; i <= 6; i++)
        {     
            flag.weakon[i].count = 10;
        }
        //武器子弹数量初始化
	}
	
	// Update is called once per frame
	void Update () {
        if (menu.GetComponent<Menu>().oldItemIndex != 0)
        {
            text.text ="弹药数量:"+flag.weakon[menu.GetComponent<Menu>().oldItemIndex].count+"敌人数量："+flag.enermy_count;

        }
        else
        {
            text.text ="弹药数量:" +0+ "敌人数量：" + flag.enermy_count;
        }
      
    //    Debug.Log(Screen.width);
    //    Debug.Log(Input.mousePosition.y);
        //枪支菜单调出
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            menu.SetActive(true);

        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(false);

        }

    }
}
