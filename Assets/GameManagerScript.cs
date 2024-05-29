using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score = 0;

    int[,] map;

    public GameObject block;
    public GameObject Goal;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);

        map = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,3,0,0,0,1,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,1,0,0,0,3,0,2,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        };


        Vector3 position = Vector3.zero;

        for (int y = 0; y < map.GetLength(0); y++)
        {
            position.y = -y + 5;

            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x;
                if (map[y,x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                if (map[y,x] == 2)
                {
                    Goal.transform.position = position;
                }

                // �R�C��
                if (map[y,x]==3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GoalScript.isGameClear==true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        scoreText.text = "SCORE" + score;
    }
}
