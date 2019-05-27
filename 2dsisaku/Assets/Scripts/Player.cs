using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
	private Animator m_player;
	public int m_playerState = 0;
	private SpriteRenderer m_idlestate;

	public Sprite F;
	public Sprite B;
	public Sprite R;
	public Sprite L;

	private Vector3 m_playerPosition = new Vector3(0, 0, 0);


	// Use this for initialization
	void Start()
	{
		m_player = GetComponent<Animator>();
		m_idlestate = GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKey(KeyCode.DownArrow))
		{
			m_player.speed = 1;
			m_player.SetInteger("Walk", 0);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			m_player.speed = 1;
			m_player.SetInteger("Walk", 1);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			m_player.speed = 1;
			m_player.SetInteger("Walk", 3);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			m_player.speed = 1;
			m_player.SetInteger("Walk", 2);
		}

		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			m_player.speed = 0;
		}


		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			m_player.speed = 0;
		}


		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			m_player.speed = 0;
		}


		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			m_player.speed = 0;
		}
	}

}
