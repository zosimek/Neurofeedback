using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;
using UnityEngine.SceneManagement;

public class PacManMenagere : MonoBehaviour
  
{
    public PathCreator pathCreator;
    public Sprite pacManRest;
    public float speed = 3;
    [HideInInspector]
    public float distanceTraveled = 0;
    public float move = 0;

    public GameObject[] points;
    public double pointDistance = 2.0;
    int i = 0;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<ChangeScene>().LoadScene("Main");
        }
        if(distanceTraveled < 87.6)
        {
            if (PythonTest.isOverThreshold == true)
            {
                Debug.Log(distanceTraveled);

                if(distanceTraveled > pointDistance && i < 55)
                {
                    points[i].SetActive(false);
                    i++;
                    pointDistance += 1.6;
                }

                distanceTraveled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
                if (distanceTraveled > 86)
                {
                    move = 1;
                }
                else if (distanceTraveled > 84)
                {
                    move = 4;
                }
                else if (distanceTraveled > 80)
                {
                    move = 3;
                }
                else if (distanceTraveled > 77)
                {
                    move = 2;
                }
                else if (distanceTraveled > 72)
                {
                    move = 1;
                }
                else if (distanceTraveled > 65)
                {
                    move = 4;
                }
                else if (distanceTraveled > 59)
                {
                    move = 3;
                }
                else if (distanceTraveled > 52)
                {
                    move = 2;
                }
                else if (distanceTraveled > 43)
                {
                    move = 1;
                }
                else if (distanceTraveled > 33)
                {
                    move = 4;
                }
                else if (distanceTraveled > 23)
                {
                    move = 3;
                }
                else if (distanceTraveled > 12)
                {
                    move = 2;
                }
                else if (distanceTraveled > 0)
                {
                    move = 1;
                }

                ///////////////////////

                if (move == 1)
                {
                    gameObject.GetComponent<Animator>().Play("pacManRight");
                }
                else if (move == 2)
                {
                    gameObject.GetComponent<Animator>().Play("pacManDown");
                }
                else if (move == 3)
                {
                    gameObject.GetComponent<Animator>().Play("pacManLeft");
                }
                else if (move == 4)
                {
                    gameObject.GetComponent<Animator>().Play("pacManUp");
                }
            }
            else 
            {
                gameObject.GetComponent<Animator>().Play("pacManStop");
            }
        }
        else
        {
            distanceTraveled = 0;
            SceneManager.LoadScene("Pac-man");
            //gameObject.GetComponent<Animator>().Play("pacManStop");
            //Application.Quit();
        }
    }
}
