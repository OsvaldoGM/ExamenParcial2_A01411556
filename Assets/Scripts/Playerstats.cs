using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats : MonoBehaviour {

    public int score;
    public int health;
    protected static Playerstats instance = null;

	void Start () {
        health = 100;
        score = 0;
	}

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
	
}
