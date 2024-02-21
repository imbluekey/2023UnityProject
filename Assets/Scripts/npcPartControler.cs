using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class npcPartControler : MonoBehaviour
{
    public string fileName = "npc_test1.txt";
    public string filePath;
    private TMP_Text textMesh;
    private int linePointer = 0;
    private int maxLine;
    private List<string> lines;

    public void setNextPartString()
    {
        if (linePointer > maxLine)
        {
            textMesh.text = "...";
        }
        else
        {
            Debug.Log("setNextPartString > " + lines[linePointer].ToString());
            textMesh.text = lines[linePointer].ToString();
            linePointer++;
        }
    }

    public void initiateLinePointer()
    {
        linePointer = 0;    
    }

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        
        filePath = System.IO.Path.Combine(Application.dataPath, fileName);
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("Please check the file path");
            return;
        }

        if (!File.Exists(filePath))
        {
            Debug.LogError("File does not exists > " + filePath);
            return;
        }

        lines = new List<string>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error Occured while reading file > " + e.Message);
            return;
        }

        maxLine = lines.Count - 1;
        for(int i = 0; i < lines.Count; i ++ )
        {
            Debug.Log(lines[i]);
        }
    }
}
