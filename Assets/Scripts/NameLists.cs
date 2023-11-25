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

    }
    private static void initSurnames()
    {

    }
    private static void initCities()
    {

    }
}
