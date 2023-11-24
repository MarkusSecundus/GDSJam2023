using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaritalStatus
{
    single,
    married,
    divorced,
    widower
}
public class IDCard : ScriptableObject
{
    public string Name = "John";
    public string Surname = "Doe";
    public uint age=21;
    public string TownOfOrigin = "Detroit";
    public string TownOfResidence = "Chicago";
    public MaritalStatus maritalStatus = MaritalStatus.single;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
