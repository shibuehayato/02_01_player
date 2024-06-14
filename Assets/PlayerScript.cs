using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody Rb;
    private bool isBlock = true;
    private AudioSource audioSource;
    public GameObject bombParticle;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed = 1.0f;
        const float jumpSpeed = 6.0f;
        Vector3 v = Rb.velocity;

        float stick = UnityEngine.Input.GetAxis("Horizontal");

        //プレイヤーの下方向へレイを出す
        Vector3 rayPosition = transform.position + new Vector3(0.0f,0.8f,0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        float distance = 0.9f;
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
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow) || stick > 0)
            {
                v.x = moveSpeed;
                animator.SetBool("walk", true);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                v.x = -moveSpeed;
                animator.SetBool("walk", true);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                v.x = 0;
                animator.SetBool("walk", false);
            }

            if (isBlock == true)
            {
                animator.SetBool("jump", false);
                if (UnityEngine.Input.GetButtonDown("Jump"))
                {
                    v.y = jumpSpeed;
                }
            }
            else
            {
                animator.SetBool("jump", true);
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

        //  爆発パーティクル
        Instantiate(bombParticle, transform.position, Quaternion.identity);
    }

}
