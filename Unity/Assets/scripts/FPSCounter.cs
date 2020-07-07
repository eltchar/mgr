using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class FPSCounter : MonoBehaviour
{
    bool start_counting = false;
    string log_path;
    void Start()
    {
        log_path = PersistentManagerScript.Instance.log_path+"FPS_log_unity" +DateTime.Now.TimeOfDay.Hours.ToString()+"_"+DateTime.Now.TimeOfDay.Minutes.ToString()+ "_" + DateTime.Now.TimeOfDay.Seconds.ToString() + ".txt";

        if (!File.Exists(log_path))
        {
            // Create a file to write to.
            string createText = "";
            File.WriteAllText(log_path, createText);
        }
        else
        {
            File.Delete(log_path);
            string createText = "";
            File.WriteAllText(log_path, createText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start_counting == false)
        {
            if(PersistentManagerScript.Instance.scene_loaded==true)
            {
                start_counting = true;
            }
        }
        else
        {
            UpdateBuffer();
        }
    }

    void UpdateBuffer()
    {  
        string appendText = (1f / Time.unscaledDeltaTime).ToString() + Environment.NewLine;
        File.AppendAllText(log_path, appendText);
    }

}
