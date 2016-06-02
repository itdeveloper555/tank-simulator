﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


	public Animator anim;
	public  GameObject player;
	public PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
//	public bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");

        playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
//            playerInRange = true;
			anim.SetBool ("NearPlayer", true);
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
//            playerInRange = false;
			anim.SetBool ("NearPlayer", false);
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && anim.GetBool ("NearPlayer")/* && enemyHealth.currentHealth > 0*/)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
