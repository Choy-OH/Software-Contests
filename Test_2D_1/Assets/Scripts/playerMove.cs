using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Range(0, 30)]
    public float speed = 5f;

    //动画，刚体组件
    private Animator ani;
    private Rigidbody2D rigid;
    void Start()
    {
        //获取组件
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //一直获取方向参数
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            //改动画的关键代码
            ani.SetFloat("Horizontal", horizontal);
            ani.SetFloat("Vertical", 0);
        }
        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);
        }


        //切换跑步
        Vector2 dir = new Vector2(horizontal, vertical);
        //改变参数来改动画
        ani.SetFloat("Speed", dir.magnitude);

        //改变刚体速度
        rigid.linearVelocity = dir * speed;
    }

}