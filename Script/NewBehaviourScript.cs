using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject canvas;
    public bool a = true;
    public bool c = true;
    // Use this for initialization
    void Start () {
        //canvas.SetActive(true);
        Debug.Log("error");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //if (canvas.activeInHierarchy)
            //{
            // canvas.SetActive(false);

            //}
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameobj = hitInfo.collider.gameObject;
                if (gameobj == gameObject)
                {
                        gameobj.SetActive(false);
  
                }
           //   gameObject.transform.lo
               
            }

        }

    }
}
