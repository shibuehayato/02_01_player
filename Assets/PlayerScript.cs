using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody Rb;
    private bool isBlock = true;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed = 1.0f;
        const float jumpSpeed = 6.0f;
        Vector3 v = Rb.velocity;

        //プレイヤーの下方向へレイを出す
        Vector3 rayPosition = transform.position;
        Ray ray = new Ray(rayPosition, Vector3.down);
        float distance = 0.6f;
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);
        if(isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        }

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

            if (isBlock == true)
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                {
                    v.y = jumpSpeed;
                }
            }
            Rb.velocity = v;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }
    }

}
