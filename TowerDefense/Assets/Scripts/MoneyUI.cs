﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour {

public Text moneyText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "$"+ PlayerStats.money.ToString();
	}
}
