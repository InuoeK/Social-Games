using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	bool inBattle;

	void Start()
	{
		inBattle = false;
	}

	public void SetInBattle(bool a_boo)
	{
		inBattle = a_boo;
	}

	public bool GetInBattle()
	{
		return inBattle;
	}
}
