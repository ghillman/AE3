using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerState
{
    private static int _PlayerHealth;
    private static int _PlayerLevel;
    private static int _Level;
    private struct Items
    {
        int Coins;
        int potions;
    }


    public static int PlayerHealth
    {
        get
        {
            return _PlayerHealth;
        }
        set
        {
            _PlayerHealth = value;
        }
    }
    public static int PlayerLevel
    {
        get
        {
            return _PlayerLevel;
        }
        set
        {
            _PlayerLevel = value;
        }
    }
    public static int Level
    {
        get
        {
            return _Level;
        }
        set
        {
            _Level = value;
        }
    }
    

}
