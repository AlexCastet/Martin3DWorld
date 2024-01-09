using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.VersionControl.Asset;
using Random = UnityEngine.Random;

public class EnemyBehaivour : MonoBehaviour
{
    // Start is called before the first frame update
    private enum States { IDLE, Patrullar, TRACK, ATTACK }
    [SerializeField]
    private States m_CurrentState;
    [SerializeField]
    private Transform[] PuntsPatrulla;
    private Rigidbody rb;
    private GameObject Objectiu;
    [SerializeField]
    private TrackBehaivour trackBehaivour;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private AttackBehaivour attackBehaivour;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        trackBehaivour.OnEntrar += EntraAreaPersecucio;
        trackBehaivour.OnSortir += SurtAreaPersecucio;
        attackBehaivour.OnEntrar += EntraAreaAtac;
        attackBehaivour.OnSortir += SurtAreaAtack;
        ChangeState(States.IDLE);
    }

    private void SurtAreaAtack()
    {
       
    }

    private void EntraAreaAtac(GameObject @object)
    {
       Debug.Log(@object);
        ChangeState(States.ATTACK);
    }

    private void SurtAreaPersecucio()
    {
        ChangeState(States.IDLE);
    }

    private void EntraAreaPersecucio(GameObject @object)
    {
       ChangeState(States.TRACK);
       Objectiu = @object;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState(m_CurrentState);
    }
    
    private void ChangeState(States newState)
    {
        if (newState == m_CurrentState)
            return;

        ExitState(m_CurrentState);
        InitState(newState);
    }
    private void InitState(States initState)
    {
        m_CurrentState = initState;

            switch (m_CurrentState)
            {
                case States.IDLE:
                    Debug.Log("Estoy en Idle");
                    break;
                case States.Patrullar:
                    
                    break;
                case States.TRACK:

                    Debug.Log("Teveooo");
                    break;
                case States.ATTACK:
                    Debug.Log("TeAcato");
                    rb.velocity = Vector3.zero;
                    break;
            }
        

    }
   
    private void UpdateState(States updateState)
    {

       
        
        
            switch (updateState)
            {
                case States.IDLE:

                    break;
                case States.Patrullar:
                PosarObjectiu();
                    break;
                case States.TRACK:
                    Debug.Log("Posant destinacio");
                navMeshAgent.SetDestination(Objectiu.transform.position);
                    break;
                case States.ATTACK:

                    break;

            }
        

    }

    private void PosarObjectiu()
    {
        int Punt = Random.Range(0, PuntsPatrulla.Length+1);
        navMeshAgent.SetDestination(PuntsPatrulla[Punt].position);
    }

    private void ExitState(States exitState)
    {
        
       
        
            switch (exitState)
            {
                case States.IDLE:

                    break;

                case States.TRACK:

                    break;
                case States.ATTACK:

                    
                    break;
            }
        

    }
}
