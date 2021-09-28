using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCollision = false;
    public Animator ani;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = newPosition.x - 1;

        if (!isCollision)
        {
            this.transform.position = Vector3.Lerp(transform.position, newPosition, 0.02f);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCollision = true;
            ani.SetBool("isIdle", true);
        }
    }
}
