﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Text shieldTxt;
    public Text lifeTxt;
    public Slider shieldSlider;
    public Slider lifeSlider;

    float life = 150;
    float shield = 5;

    float maxLife = 150;
    float maxShield = 150;

    private void Awake()
    {
        shieldTxt.text = shield.ToString();
        lifeTxt.text = life.ToString();
        shieldSlider.value = shield;
        lifeSlider.value = life;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(float damage)
    {
        if (shield > 0)
        {
            shield -= damage;

            if (shield < 0)
            {
                life += shield;
                shield = 0;
            }
            shieldSlider.value = shield;
            lifeSlider.value = life;

            shieldTxt.text = shield.ToString();
            lifeTxt.text = life.ToString();
        }
        else
        {
            life -= damage;
            if (life < 0) life = 0;
            lifeSlider.value = life;
            lifeTxt.text = life.ToString();
        }

    }
    
    //If life or ammo are already at his maximum, do not get the items
    public bool AddLife(float lifePlus)
    {
        bool useItem = false;
        if (life < maxLife)
        {
            useItem = true;
            life += lifePlus;
            lifeSlider.value = life;
            lifeTxt.text = life.ToString();
        }
        return useItem;
    }

    public bool AddShield(float shieldPlus)
    {
        bool useItem = false;
        if (shield < maxShield)
        {
            useItem = true;
            shield += shieldPlus;
            shieldSlider.value = shield;
            shieldTxt.text = shield.ToString();
        }
        return useItem;
    }
}
