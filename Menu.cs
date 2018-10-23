using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public GameObject cam;
    public GameObject wuqi;
    GameObject cc,aa;
    public Image[] items;
    public Color nomorlColor;
    public Color heightColor;
    public GameObject solider;
    public int oldItemIndex = 0;
    public int currentItemindex;
    // Use this for initialization
    void Start () {
        flag.active[0] = true;
        //flag.active[1] = true;
       // flag.active[2] = true;
    }
	
	// Update is called once per frame
	void Update () {
         currentItemindex = GetItemIndex();
        //设置高亮,并将其他item置回默认样式

        //当前枪支是否拥有
        if (flag.active[currentItemindex])
        {
            if (oldItemIndex != currentItemindex)
            {
                
                items[oldItemIndex].color= nomorlColor;

                nomorlColor=items[currentItemindex].color;
                items[currentItemindex].color = heightColor;

              //  Debug.Log(oldItemIndex);
              
                solider.transform.GetChild(oldItemIndex+2).gameObject.SetActive(false);
                solider.transform.GetChild(currentItemindex+2).gameObject.SetActive(true);
               
                
                    aa = wuqi.transform.GetChild(oldItemIndex).gameObject;
                    cc = wuqi.transform.GetChild(currentItemindex).gameObject;
                    cc.SetActive(true);
             
                    cc.transform.position = aa.transform.position;
                //进行枪支切换时将前一枪支与后一枪支的位置与角度进行转换
                //由于不同枪支的正方向与坐标系的z轴方向不一致，在进行枪支转换时，为使视野方向不发生改变，需进行判断
                    if ((oldItemIndex == 1 || oldItemIndex == 2) && (currentItemindex != 1 && currentItemindex != 2) || (oldItemIndex != 1 && oldItemIndex != 2) && (currentItemindex == 1 || currentItemindex == 2))
                    {
                        cc.transform.eulerAngles = aa.transform.eulerAngles+new Vector3(0.0f,180.0f,0.0f);
                        wuqi.GetComponent<gun>().center += 180.0f;
                     if (wuqi.GetComponent<gun>().center > 360)
                     {
                        wuqi.GetComponent<gun>().center -= 360;
                     }
               //     Debug.Log(wuqi.GetComponent<gun>().center);
                 //   Debug.Log(cc.transform.eulerAngles);
                     }
                    else
                    {
                        cc.transform.eulerAngles = aa.transform.eulerAngles;
              //          Debug.Log(aa.transform.eulerAngles);
              //          Debug.Log(cc.transform.eulerAngles);
                    }
         

                    //将camera与gun中的交互对象进行改变，为当前枪支
                    cam.GetComponent<gun_camera>().ak = cc;
                    wuqi.GetComponent<gun>().current = cc;
                    aa.SetActive(false);
                
                
                oldItemIndex = currentItemindex;
                flag.current = oldItemIndex;
            }
        }
        

        if (Input.GetMouseButtonDown(0))
        {
           //点击左键确认选择,这里未做处理
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
        }

    }

    //根据角度获得当前鼠标所处的image数组的index
    int GetItemIndex()
    {
        //V是鼠标相对屏幕大小以中心点原点的2维向量
        Vector2 v = new Vector2(Input.mousePosition.x / Screen.width - 0.5f, Input.mousePosition.y / Screen.height - 0.5f);
        //f是(相对屏幕大小以中心点原点的坐标系)(0,1)与v的角度
        float f = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg + 180;
       // Debug.Log(f);
        //根据f返回index
        return ((int)(f / (360/items.Length)));
    }


}
