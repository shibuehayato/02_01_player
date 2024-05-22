using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed = 1.0f;
        const float jumpSpeed = 6.0f;
        Vector3 v = Rb.velocity;

        if (GoalScript.isGameClear == false)
        {
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                v.x = moveSpeed;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                v.x = -moveSpeed;
            }
            else
            {
                v.x = 0;
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                v.y = jumpSpeed;
            }
            Rb.velocity = v;
        }
    }

}
