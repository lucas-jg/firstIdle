using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public Animator ani;

    public float maxSpeed;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }



    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            ani.SetBool("isAttack", true);
        }
    }
}
