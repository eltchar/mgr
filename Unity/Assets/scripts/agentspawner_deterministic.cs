using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class agentspawner_deterministic : MonoBehaviour
{
    [SerializeField]
    private GameObject agentprefab;

    int count;
    int spawnedSoFar = 0;
    float time_end_spawn;
    bool latch = true;
    private static Timer aTimer;

    private void Start()
    {
        count = PersistentManagerScript.Instance.agent_count;
    }
    public void return_to_menu()
    {
        PersistentManagerScript.Instance.back_to_menu();
    }
    public void start_test()
    {
        PersistentManagerScript.Instance.test_started = true;
    }
    public void save_times()
    {
        PersistentManagerScript.Instance.write_times_to_file();
    }
    void Update()
    {
        if (spawnedSoFar < count)
        {
            Spawn();
            spawnedSoFar++;
        }
        else
        {
            if (latch)
            {
                time_end_spawn = Time.realtimeSinceStartup;
                PersistentManagerScript.Instance.scene_loaded = true;
                latch = false;
                PersistentManagerScript.Instance.time_end_spawn = time_end_spawn;
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
                aTimer.Start();
            }

        }

    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        PersistentManagerScript.Instance.test_started = true;
        aTimer.Stop();
    }
    void Spawn()
    {
        Instantiate(agentprefab, transform.position, transform.rotation);
        transform.Translate(Vector3.forward * 10, Space.Self);
    }
}
