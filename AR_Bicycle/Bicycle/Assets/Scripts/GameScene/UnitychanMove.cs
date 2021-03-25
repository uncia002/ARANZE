using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanMove : MonoBehaviour
{

    protected Joystick joystick;
    protected JoyButton joybutton;

    public MoveScript _moveScript;
    public ClickScript clickscript;

    public bool isJump;
    public bool isDoubleJump;

    public float lastjoystickHori = 0;
    public float lastjoystickVer = 0;

    private float time=0;

    //Rigidbodyを変数に入れる
    Rigidbody rb;



    //ジャンプ力
    public float thrust = 40;
    //2段ジャンプ力
    public float doubleThrust = 50;
    //Animatorを入れる変数
    private Animator animator;
    //ユニティちゃんの位置を入れる
    Vector3 playerPos;
    //地面に接触しているか否か
    bool ground=true;
    Vector3 lastRotate=new Vector3(0,0,0);
    

    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //ユニティちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;


        joystick = FindObjectOfType<Joystick>();

        joybutton = FindObjectOfType<JoyButton>();
    }

    void Update()
    {
        time += Time.deltaTime;
        //地面に接触していると作動する
        if (ground)
        {


            //ユニティちゃんの最新の位置から少し前の位置を引いて方向を割り出す
            Vector3 direction = transform.position - playerPos;

            //移動距離が少しでもあった場合に方向転換
            if (direction.magnitude > 0.000000001f)
            {
                //directionのX軸とZ軸の方向を向かせる
                transform.rotation = Quaternion.LookRotation(new Vector3
                    (direction.x, 0, direction.z));
                //走るアニメーションを再生
                animator.SetBool("Running", true);

                lastRotate = new Vector3(direction.x, 0, direction.z);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(lastRotate);
                //ベクトルの長さがない＝移動していない時は走るアニメーションはオフ
                //animator.SetBool("Running", false);
            }

            //ユニティちゃんの位置を更新する
            playerPos = transform.position;

            
        }


        var rigidbody = GetComponent<Rigidbody>();

        if (clickscript.isMovescriptActive)
        {


            if (joystick.Horizontal==0 && joystick.Vertical == 0)
            {
                rigidbody.velocity = new Vector3(-1* _moveScript.unitychanSpeed * 80 
                   * lastjoystickHori, rigidbody.velocity.y, _moveScript.unitychanSpeed *-80* lastjoystickVer);

            }
            else if (joystick.Horizontal * joystick.Horizontal + joystick.Vertical * joystick.Vertical < 0.90)
            {

                rigidbody.velocity = new Vector3((_moveScript.unitychanSpeed* -80 * joystick.Horizontal), rigidbody.velocity.y, _moveScript.unitychanSpeed * -80*joystick.Vertical);


            }
            else
            {
                lastjoystickHori = joystick.Horizontal;
                lastjoystickVer = joystick.Vertical;

                rigidbody.velocity = new Vector3(-1* _moveScript.unitychanSpeed *80* joystick.Horizontal, rigidbody.velocity.y, _moveScript.unitychanSpeed*80 * -1*joystick.Vertical);
            }

        }

        //jump
        if (!isJump && joybutton.Pressed)
        {
            isJump = true;
            //thrustの分だけ上方に力がかかる
            rb.AddForce(transform.up * thrust);

        }//doubleJump
        else if (!isDoubleJump && isJump && joybutton.Pressed)
        {
            isDoubleJump = true;

            //doubleThrustの分だけ上方に力がかかる
            rb.AddForce(transform.up * doubleThrust);

        }

    }

    //Planに触れている間作動
    void OnCollisionStay(Collision col)
    {
        ground = true;
        isJump = false;
        isDoubleJump = false;
    }

    //Planから離れると作動
    void OnCollisionExit(Collision col)
    {
        ground = false;

    }


}
