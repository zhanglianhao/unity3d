using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {

    public Sprite UInone;
 //   public Sprite UIimage;
    Sprite img;
    Image a;
    Color cc;
    
    int change;
   public int bz=1;
    // Use this for initialization
    void Start () {
        a = GetComponent<Image>();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(click);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(2);
	}
    
    public void click()
    {
        change = dianji.flag;
        dianji.flag = bz;
        bz = change;
        img = dianji.img;
        dianji.img = a.sprite;
        a.sprite = img;
        cc = dianji.col;
        dianji.col = a.color;
        a.color = cc;


        Debug.Log(bz);

    }
}
