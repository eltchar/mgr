using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;


public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }
    public string log_path= @"d:\";
    public bool test_started = false, scene_loaded=false;
    public int agent_count = 200;
    public int fps_range = 60;
    public float time_start_geo,time_end_spawn;
    public float agent_speed = 10;
    public List<string> agent_times;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void play_lab1()
    {
        time_start_geo=Time.realtimeSinceStartup;
        SceneManager.LoadScene("Labirynt1");
    }
    public void play_lab2()
    {
        time_start_geo = Time.realtimeSinceStartup;
        SceneManager.LoadScene("Labirynt2");
    }
    public void play_lab3()
    {
        time_start_geo = Time.realtimeSinceStartup;
        SceneManager.LoadScene("Labirynt3");
    }
    public void play_lab4()
    {
        time_start_geo = Time.realtimeSinceStartup;
        SceneManager.LoadScene("Labirynt4");
    }
    public void play_lab5()
    {
        time_start_geo = Time.realtimeSinceStartup;
        SceneManager.LoadScene("Labirynt5");
    }
    public void play_funnel()
    {
        time_start_geo = Time.realtimeSinceStartup;
        SceneManager.LoadScene("Funnel");
    }
    public void play_side_test()
    {
        time_start_geo = Time.realtimeSinceStartup;
        SceneManager.LoadScene("deterministic");
    }

    public void exit_app()
    {
        Application.Quit();
    }

    public void add_agent_time(string time)
    {
        agent_times.Add(time);
    }
    public void back_to_menu()
    {
        SceneManager.LoadScene("menu");
        test_started = false;
        scene_loaded = false;
        agent_times.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {
        log_path = @"d:\";
    }

    public void write_times_to_file()
    {
        string log_path_save = log_path + "Times_log_unity" + DateTime.Now.TimeOfDay.Hours.ToString() + "_" + DateTime.Now.TimeOfDay.Minutes.ToString() + "_" + DateTime.Now.TimeOfDay.Seconds.ToString() + ".txt";

        if (!File.Exists(log_path_save))
        {
            // Create a file to write to.
            string createText = "";
            File.WriteAllText(log_path_save, createText);
        }
        else
        {
            File.Delete(log_path_save);
            string createText = "";
            File.WriteAllText(log_path_save, createText);
        }
        string appendText = (time_end_spawn-time_start_geo).ToString()+ Environment.NewLine;
        foreach (string item in agent_times)
        {
            appendText = appendText + item + Environment.NewLine;
        }
        File.AppendAllText(log_path_save, appendText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
