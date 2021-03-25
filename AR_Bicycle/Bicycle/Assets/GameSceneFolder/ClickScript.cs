using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{

    private GameObject andy;
    GameObject hoge;
    public GameObject unitychan;
    public GameObject Canvas;
    public GameObject movescript;

    public bool wait = false;
    public bool isMovescriptActive = false;

    private float time;

    public void Start()
    {
        time = 5;

        Canvas.SetActive(false);
    }

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        Debug.Log("Button click!");
        hoge = GameObject.Find("Controller");
        GameObject.Destroy(hoge);

        //hoge = GameObject.Find("set_canvas");
        //GameObject.Destroy(hoge);

        andy = GameObject.Find("hasi_No1");



        
        Canvas.SetActive(true);
        unitychan.SetActive(true);
        //unitychan Position
        Transform myTransform = andy.transform;
        unitychan.GetComponent<Transform>().position = new Vector3(myTransform.position.x, (float)(myTransform.position.y+0.7), myTransform.position.z);
        //unitychan.GetComponent<UnitychanMove>().enabled = false;


        //５秒待つ
        wait = false;
        //Instantiate((GameObject)Resources.Load("moveScript"));
        movescript.SetActive(true);
        isMovescriptActive = true;

        hoge = GameObject.Find("set_canvas");
        GameObject.Destroy(hoge);
    }


    private void Update()
    {
        /*
        if (wait)
        {
            time -= Time.deltaTime;
            for (int i=5; ; i--)
            {
                if()
            }
            
        }
        */
    }
}

