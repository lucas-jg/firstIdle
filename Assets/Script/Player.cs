using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    private Animator ani;

    public float maxSpeed;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }



    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            StartCoroutine(AttackTarget(monster, 0.5f));
        }
    }

    IEnumerator AttackTarget(Monster monster, float attackTime)
    {
        float healthPoint = monster.HealthPoint;

        while (healthPoint > 0 && monster)
        {
            ani.SetBool("isAttack", true);
            monster.HitMonster(10f);
            healthPoint -= 10f;
            yield return new WaitForSeconds(attackTime);

        }
        ani.SetBool("isAttack", false);
        Debug.Log("Success AttackTarget");
        yield return null;
    }


}
