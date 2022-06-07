using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnistyEngine.AI;

public class Enemy : MonoBehaviour
{

 
        public NavMeshAgent agent
		public Transform player;
		public LayerMask whatIsGround, whatIsPlayer;
		public Vector3 walkPoint
		bool walkPointSet
		public flaot walkPointRange;
		public TimeBetweenAttacks
		bool alreadyAttacked
		public float sightRange, attackRange
		public bool playerInSightRange, playerInAttackRange;
		
		private void Awake()
		{
			player = GameObject.Find("PlayerObj").transform;
			agent = GetComponent<NavMeshAgent>();
		}
		private void Update()
		{
			playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
			playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
			if (!playerInSightRange && !playerInAttackRange) Patrolling();
			if(playerInSightRange && !playerInAttackRange) ChasePlayer();
			if (playerInSightRange && playerInAttackRange) AttackPlayer();
			
		}
		private void Patrolling()
		{
			if (!walkPointSet) SearchWalkPoint();
			
			if (walkPointSet)
				agent.setDestination(walkPoint);
			
			Vector3 distanceToWalkPoint = transform.position - walkPoint;
			
			if (distanceToWalkPoint.magnitude <2f)
				walkPoint = false;
		}
		private void SearchWalkPoint()
		{
			flaot randomZ=Rnadom.Range(-walkPointRange, walkPointRange);
			flaot randomX=Rnadom.Range(-walkPointRange, walkPointRange);
			walkPoint= new Vector3(transform.position.x +randomX, transform.position.y, transform.position.z +randomZ);
			if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
				walkPointSet = true;
		}
		private void ChasePlayer()
		{
			agent.SetDestination(player.position);
		}
		private void AttackPlayer()
		{
			agent.SetDestination(transform.position);
			transform.LookAt(player);
			if(!alreadyAttacked)
			{
				//attack code here
				alreadyAttacked=true;
				invoke(nameof(ResetAttack), timeBetweenAttacks);
			}
		}
	private void ResetAttack()
	{
		alreadyAttacked = false;
	}
}
