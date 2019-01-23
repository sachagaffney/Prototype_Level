using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    Image healthbar;
    float maxHealth = 100f;
    public static float health;
	// Use this for initialization
	void Start () {
        healthbar = GetComponent<Image>();
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.fillAmount = health / maxHealth;
	}
}
