using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCollision = false;
    private Animator ani;
    public float HealthPoint;


    void Start()
    {
        HealthPoint = 100f;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = newPosition.x - 1;

        if (!isCollision)
        {
            this.transform.position = Vector3.Lerp(transform.position, newPosition, 0.04f);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollision = true;
            ani.SetBool("isIdle", true);
        }
    }

    public void HitMonster(float damage)

    {
        HealthPoint -= damage;

        if (HealthPoint <= 0)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject, 0.5f);
        }

        Debug.Log("HealthPoint : " + HealthPoint);


    }
}
