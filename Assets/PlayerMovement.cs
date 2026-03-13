using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        Rigidbody2D Player;
        Animator anim;
        SpriteRenderer spr;
        public float speed = 5f;
        public float jump = 5f;
        float Movement;

        public bool isDead = false;
    public GameObject GameOver;
 
        bool isGround = false;
    void Start()
    {
        //引入特別用法
        //player是玩家的意思後面2D就是指untiy上的Box Callider 2D
        Player = GetComponent<Rigidbody2D>();
        //anim是動作得意思後面的Animator指untiy上的Animator
        anim = GetComponent<Animator>();
        //spr在這邊是控制圖的方向在untiy上是指SpriteRenderer
        spr = GetComponent<SpriteRenderer>();
        //這些都是在play1這個物件上所加的屬性也就是untiy點物件時旁邊可以加的東西
    }

    //OnTriggerEnter2D這是用來判斷2個有Box Collider 2D有沒有接觸
    void OnTriggerEnter2D(Collider2D other)
    {
        //這邊的if是用來看如果碰觸到的另一個有Box Collider的物件tag是否為Ground是就執行if
        if (other.CompareTag("Ground"))
        {
            //只是控制是否在地板(在這主要是用來說沒辦法在空中跳躍)
            isGround = true;
            //這是動畫表現
            anim.SetBool("jump", false);
            //這是暫時成為此Ground的子物件(主要是用來讓人物和地板一起走就是不會人停在原地地板自己跑掉)
            transform.SetParent(other.transform);
        }
        //和上面一樣只是看tag是不是Death Line
        else if (other.CompareTag("Death Line"))
        {   
            //這邊只是控制遊戲結束的重來怎麼做
            GameOver.SetActive(true);
            isDead = true;
            Debug.Log("主角掛掉");
        }
    }

    void Update()
    {   
        //重新開始遊戲這指令
        if (isDead == true && Input.anyKeyDown)
        {
            //這邊是要重開遊戲直接整個遊戲重整(場景管理員.載入場景("載入場景名稱"))
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = false;
            transform.SetParent(null);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Movement = speed;
            anim.SetBool("run", true);
            spr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Movement = -speed;
            anim.SetBool("run", true);
            spr.flipX = true;
        }
        else
        {
            Movement = 0f;
            anim.SetBool("run", false);
        }
        Player.linearVelocityX = Movement;

        if (Input.GetKey(KeyCode.W) && isGround == true)
        {
            Player.linearVelocity = new Vector2(Movement, jump);
            anim.SetBool("jump", true);
        }
    }
}
