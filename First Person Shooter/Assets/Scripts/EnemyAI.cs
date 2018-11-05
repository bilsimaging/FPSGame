﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AlertState alertState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public GameObject[] totalDecals;
    [HideInInspector] public int actual_decal = 0;

    public Light myLight;
    public float life = 100;
    public float timeBetweenShoots = 1.0f;
    public float damageForce = 10f;
    public float rotationTime = 3.0f;
    public float shootHeight = 0.5f;
    public Transform[] wayPoints;
    public GameObject decalPrefab;
    public AudioSource fireAudio;

    // Use this for initialization
    void Start () {
        totalDecals = new GameObject[10];
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        attackState = new AttackState(this);

        currentState = patrolState;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState();

        if (life < 0) Destroy(this.gameObject);
	}

    public void Hit(float damage)
    {
        life -= damage;
        currentState.Impact();
    }

    public void DestroyQuad()
    {
        Destroy(totalDecals[actual_decal]);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
