using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Range(0, 30)]
    public float speed = 5f;

    //�������������
    private Animator ani;
    private Rigidbody2D rigid;
    void Start()
    {
        //��ȡ���
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //һֱ��ȡ�������
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            //�Ķ����Ĺؼ�����
            ani.SetFloat("Horizontal", horizontal);
            ani.SetFloat("Vertical", 0);
        }
        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);
        }


        //�л��ܲ�
        Vector2 dir = new Vector2(horizontal, vertical);
        //�ı�������Ķ���
        ani.SetFloat("Speed", dir.magnitude);

        //�ı�����ٶ�
        rigid.linearVelocity = dir * speed;
    }

}