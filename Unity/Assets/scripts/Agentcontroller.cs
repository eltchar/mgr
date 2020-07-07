using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.SceneManagement;

public class Agentcontroller : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    float start_time=0,end_time=0,in_time=0,out_time=0;
    int start_var=0;
    bool started = false, ended=false, in_lab=false,out_lab=false;
    Vector3 goal;
    Vector3 dist_vec;
    float distance;


    void Start()
    {
        agent.speed = PersistentManagerScript.Instance.agent_speed;
        double multipler_dist = 1000;
        int distmod;
        if (SceneManager.GetActiveScene().name== "deterministic")
        {
            multipler_dist = (double)PersistentManagerScript.Instance.agent_count / 1.0;
            distmod = ((int)Math.Floor(multipler_dist) * 10) + 200;
        }
        else
        {
            multipler_dist = multipler_dist / 20.0;
            distmod = ((int)Math.Floor(multipler_dist) * 10) + 300;
        }
            
        dist_vec = new Vector3(0, 0, distmod);
        goal = new Vector3(99999, 9999, 99999);
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(transform.position, goal);
        if (PersistentManagerScript.Instance.test_started && started == false)
        start_var++;
        if(start_var==1 && started == false)
        {
            goal = transform.position - dist_vec;
            started = true;
            start_time = Time.realtimeSinceStartup;
        }
        if (distance > 0.1f && started == true && ended == false)
        {
            agent.SetDestination(goal);
        }
        if (distance < 0.1f && started == true && ended == false)
        {
            ended = true;
            end_time = Time.realtimeSinceStartup;
            string time_string = start_time + ";" + end_time + ";" + in_time + ";" + out_time;
            PersistentManagerScript.Instance.add_agent_time(time_string);      
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="gate_in"&& in_lab == false)
        {
            in_time= Time.realtimeSinceStartup;
            in_lab = true;
        }
        if (other.gameObject.name == "gate_out" && out_lab == false)
        {
            out_time = Time.realtimeSinceStartup;
            out_lab = true;
        }
        if (other.gameObject.name == "gate_out2" && out_lab == false)
        {
            out_time = Time.realtimeSinceStartup;
            out_lab = true;
        }
        if (other.gameObject.name == "gate_out3" && out_lab == false)
        {
            out_time = Time.realtimeSinceStartup;
            out_lab = true;
        }
    }

}
