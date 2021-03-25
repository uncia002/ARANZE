using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject topobj;
    private GameObject middleobj;
    private GameObject bottomobj;
    private GameObject andy;
    private System.Random rnd = new System.Random();    // インスタンスを生成
    int intResult;
    float g;
    float x;
    float y;
    float z;
    Vector3 worldAngle;
    float world_x;
    float world_y;
    float world_z;

    public GameObject _unitychan;
    UnitychanMove unitychanMove;

    //台の移動速度
    public float nowspeed = 0.0000001f;
    public float acceleration = 0.00000002f;
    public float time = 0;


    public float unitychanSpeed=0;


    void Start()
    {
        andy = GameObject.Find("hasi_No1");
        Vector3 tmp = andy.transform.position;
        x = tmp.x;
        y = tmp.y;
        z = tmp.z;
        Transform myTransform = andy.transform;
        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        float world_x = worldAngle.x; // ワールド座標を基準にした、x軸を軸にした回転角度
        float world_y = worldAngle.y; // ワールド座標を基準にした、y軸を軸にした回転角度
        float world_z = worldAngle.z; // ワールド座標を基準にした、z軸を軸にした回転角度

        topobj = Instantiate((GameObject)Resources.Load("hasi_No3"), new Vector3(x+4.172f, y, z), Quaternion.Euler(world_x, world_y, world_z));
        middleobj = Instantiate((GameObject)Resources.Load("hasi_No2"), new Vector3(x+2.085f, y, z), Quaternion.Euler(world_x, world_y, world_z));
        bottomobj = andy;


        unitychanSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //すべてのユミル人はひとつの座標で交わる。エレン探し
        g = middleobj.transform.position.x;
        if (g <= x)
        {

            //オブジェクトの削除と追加
            intResult = rnd.Next(5); // 0～4をランダムで返す
            GameObject.Destroy(bottomobj);
            bottomobj = middleobj;
       
            middleobj = topobj;
            if (intResult == 0)
            {
                topobj = Instantiate((GameObject)Resources.Load("hasi_No2"), new Vector3(x + 4.172f, y, z), Quaternion.Euler(world_x, world_y, world_z));

            }
            else if (intResult == 1)
            {
                topobj = Instantiate((GameObject)Resources.Load("hasi_No3"), new Vector3(x + 4.172f, y, z), Quaternion.Euler(world_x, world_y, world_z));
            }
            else if (intResult == 2)
            {
                topobj = Instantiate((GameObject)Resources.Load("hasi_No4"), new Vector3(x + 4.172f, y, z), Quaternion.Euler(world_x, world_y, world_z));
                z = z + 0.426f;
            }
            else if (intResult == 3)
            {
                topobj = Instantiate((GameObject)Resources.Load("hasi_No5"), new Vector3(x +4.172f, y, z), Quaternion.Euler(world_x, world_y, world_z));
                z = z - 0.426f;
            }
            else
            {
                topobj = Instantiate((GameObject)Resources.Load("hasi_No6"), new Vector3(x+4.172f, y, z), Quaternion.Euler(world_x, world_y, world_z));
            }

                


        }


        //オブジェクトの移動
        time += Time.deltaTime;
        nowspeed = time * acceleration*0.003f;

        unitychanSpeed = nowspeed - (time * 0.001f * (_unitychan.GetComponent<Transform>().position.x - x));
        //unitychanSpeed = nowspeed;
        Debug.Log(nowspeed);
        topobj.transform.Translate(-1*nowspeed, 0, 0);
        middleobj.transform.Translate(-1*nowspeed, 0, 0);
        bottomobj.transform.Translate(-1*nowspeed, 0, 0);
    }
}
