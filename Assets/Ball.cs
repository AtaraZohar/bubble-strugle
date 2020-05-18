using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	public Vector2 startForce;

	public GameObject nextBall;

	public Rigidbody2D rb;

	public GameObject [] ball;

	//[SerializeField] int nextlevel;

	//public nextlevel level;

	// Use this for initialization
	void Start () {
		rb.AddForce(startForce, ForceMode2D.Impulse);
		//level = new nextlevel();
	}

	public void Split ()
	{
		if (nextBall != null)
		{
			GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
			GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

			ball1.GetComponent<Ball>().startForce = new Vector2(2f, 5f);
			ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 5f);
		}

        else
        {
			
			
			ball = GameObject.FindGameObjectsWithTag("Ball");
			if(ball.Length == 1)
            {
				GameObject nextLevel = GameObject.Find("levelInfo");
				//nextlevel.GetComponent<levelinfo>();
				SceneManager.LoadScene(nextLevel.GetComponent<levelinfo>().nextLevel);
			}
		}

		Destroy(gameObject);
		
	}

}
