using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public GameObject agent_count_box;
    public GameObject speed_box;
    public GameObject log_path_box;
    public void play_lab1()
    {
        PersistentManagerScript.Instance.play_lab1();
    }
    public void play_lab2()
    {
        PersistentManagerScript.Instance.play_lab2();
    }
    public void play_lab3()
    {
        PersistentManagerScript.Instance.play_lab3();
    }
    public void play_lab4()
    {
        PersistentManagerScript.Instance.play_lab4();
    }
    public void play_lab5()
    {
        PersistentManagerScript.Instance.play_lab5();
    }
    public void play_funnel()
    {
        PersistentManagerScript.Instance.play_funnel();
    }
    public void play_side_test()
    {
        PersistentManagerScript.Instance.play_side_test();
    }
    public void exit_app()
    {
        Application.Quit();
    }

    public void back_to_menu()
    {
        PersistentManagerScript.Instance.back_to_menu();
    }

    public void change_agent_count()
    {
        PersistentManagerScript.Instance.agent_count = int.Parse(agent_count_box.GetComponent<InputField>().text);
    }
    public void change_agent_speed()
    {
        PersistentManagerScript.Instance.agent_speed = float.Parse(speed_box.GetComponent<InputField>().text);
    }
    public void change_log_path()
    {
        PersistentManagerScript.Instance.log_path = log_path_box.GetComponent<InputField>().text;
    }

    private void Start()
    {
        agent_count_box.GetComponent<InputField>().text = PersistentManagerScript.Instance.agent_count.ToString();
        speed_box.GetComponent<InputField>().text = PersistentManagerScript.Instance.agent_speed.ToString();
        log_path_box.GetComponent<InputField>().text = PersistentManagerScript.Instance.log_path;
    }
}
