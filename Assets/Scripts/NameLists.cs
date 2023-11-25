using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NameLists
{
    //We're too lazy to do it the proper way, so here we go
    private static bool namesInitialized=false;
    private static bool surnamesInitialized=false;
    private static bool citiesInitialized = false;
    private static List<string> names;
    private static List<string> surnames;
    private static List<string> cities;
    
    public static string[] GetNames()
    {
        if (!namesInitialized)
        {
            initNames();
            namesInitialized=true;
        }
        return names.ToArray();
    }
    public static string[] GetSurnames()
    {
        if(!surnamesInitialized)
        {
            initSurnames();
            surnamesInitialized=true;
        }
        return surnames.ToArray();
    }
    public static string[] GetCities()
    {
        if (!citiesInitialized)
        {
            initCities();
            citiesInitialized=true;
        }
        return cities.ToArray();
    }
    private static void initNames()
    {

        names = new List<string> { "James", 
            "John", 
            "Robert", 
            "Michael", 
            "William", 
            "David", 
            "Richard", 
            "Charles", 
            "Joseph", 
            "Thomas",
            "Christopher",
            "Daniel",
            "Paul",
            "Mark",
            "Donald",
            "George",
            "Kenneth",
            "Steven",
            "Edward",
            "Brian"
        };

    }
    private static void initSurnames()
    {
        surnames = new List<string>
        {
            "Smith",
            "Johnson",
            "Williams",
            "Brown",
            "Jones",
            "Garcia",
            "Miller",
            "Davis",
            "Rodriguez",
            "Martinez",
            "White",
            "Lopez",
            "Lee",
            "Wilson",
            "Anderson",
            "Thomas",
            "Taylor",
            "Moore",
            "Jackson",
            "Martin"
        };
    }
    private static void initCities()
    {
        cities = new List<string>
        {
            "New York",
            "Philadelphia",
            "Washington",
            "Atlanta",
            "Charleston",
            "San Francisco",
            "Los Angeles",
            "Dallas",
            "Austin",
            "Miami",
            "Houston",
            "San Antonio",
            "Chicago",
            "Charlotte",
            "Las Vegas",
            "Seattle",
            "Memphis",
            "Indianapolis",
            "Detroit"
        };
    }
}
