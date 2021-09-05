using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;


public class AgentScript : Agent
{
    public Vector2 previousPosition;
    public Vector2 actualPosition;
    public override void OnEpisodeBegin()
    {
        GetComponent<Rigidbody2D>().transform.position = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        //base.OnEpisodeBegin();
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        Debug.Log("Acceleració: " + vectorAction[0]); Debug.Log("Gir: " + vectorAction[1]);
        GetComponent<Controlador>().accelerar(vectorAction[0], 6f);

        GetComponent<Controlador>().girar(vectorAction[1], 0.1f);

        actualPosition = GetComponent<Rigidbody2D>().position;
        if (previousPosition == actualPosition) { GetComponent<AgentScript>().AddReward(-.1f); }
        else GetComponent<AgentScript>().AddReward(+.01f);
        previousPosition = actualPosition;

        //base.OnActionReceived(vectorAction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Meta") { AddReward(1f); Debug.Log("+1 punt"); }
        else
        {
            Debug.Log("-20 punts");
            GetComponent<AgentScript>().AddReward(-5f);
            GetComponent<AgentScript>().EndEpisode();
        }
    }
    
    /*public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxisRaw("Vertical");
        actionsOut[1] = Input.GetAxisRaw("Horitzontal");

        //base.Heuristic(actionsOut);
    }*/
    

}
