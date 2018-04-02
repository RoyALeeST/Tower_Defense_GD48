using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : NPCBaseFSM {


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		base.OnStateEnter(animator,stateInfo,layerIndex); // to call all the variables from the state enter
	}


	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		var direction = Opponent.transform.position - NPC.transform.position;
        float distanceThisFrame = speed * Time.deltaTime;




        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,Quaternion.LookRotation(direction),rotSpeed * Time.deltaTime); //we use slerp to make the npc 
        //agent.transform.position = Vector3.Lerp(agent.transform.position, Opponent.transform.position, speed * Time.deltaTime);
		//slowly look at the waypoint is traveling you can change the speed of the roration with the rotspeed(which is created in npcbasefsm)
		//NPC.transform.position = Quaternion.Slerp(NPC.transform.position, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime); ; //you can use speed to change velocity of the movement (which is created in npcbasefsm)
        //NPC.transform.Translate(Opponent.transform.position);
	    agent.SetDestination(Opponent.transform.position-NPC.transform.position);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
	
	}
}


