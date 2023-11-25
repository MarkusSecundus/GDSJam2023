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
    private static IDCard instance = null;
    public static IDCard Instance 
    { 
        get
        {
            if(instance == null)
            {
                instance = new();
            }
            return instance;
        }
    }

    public string FirstName = "John";
    public string Surname = "Doe";
    public uint age=21;
    public string TownOfOrigin = "Detroit";
    public string TownOfResidence = "Chicago";
    public MaritalStatus maritalStatus = MaritalStatus.single;

    public static IDCard generateNewRandomInstance()
    {
        IDCard instance = new();
        var names=NameLists.GetNames();
        var surnames=NameLists.GetSurnames();
        var cities=NameLists.GetCities();
        instance.FirstName = names[Random.Range(0, names.Length)];
        instance.Surname = surnames[Random.Range(0, surnames.Length)];
        instance.age = (uint)Random.Range(21, 51);
        instance.TownOfOrigin = cities[Random.Range(0, cities.Length)];
        instance.TownOfResidence = cities[Random.Range (0, cities.Length)];
        int randstate = Random.Range(0, 10);
        if(randstate < 3)
        {
            instance.maritalStatus= MaritalStatus.single;
        }
        else if(randstate < 5) 
        {
            instance.maritalStatus = MaritalStatus.married;
        }
        else if(randstate < 8)
        {
            instance.maritalStatus = MaritalStatus.divorced;
        }
        else
        {
            instance.maritalStatus = MaritalStatus.widower;
        }
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
