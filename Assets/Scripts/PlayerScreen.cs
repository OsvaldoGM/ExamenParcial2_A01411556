using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScreen : MonoBehaviour {

    public Text Score;
    public Text Health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Score.text = GameObject.Find("Playerstats").GetComponent<Playerstats>().score.ToString();
        Health.text = GameObject.Find("Playerstats").GetComponent<Playerstats>().health.ToString();
    }
}
