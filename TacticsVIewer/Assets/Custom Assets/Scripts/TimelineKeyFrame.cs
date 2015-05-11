using UnityEngine;
using System;

public class TimelineKeyFrame : IComparable
{

    float t;
    Vector3 pos;
    Vector3 dir;

    public TimelineKeyFrame(float tIn, Vector3 posIn, Vector3 dirIn)
    {
        t = tIn;
        pos = posIn;
        dir = dirIn;
    }

    public int CompareTo(object obj)
    {
        TimelineKeyFrame other = (TimelineKeyFrame)obj;

        if (this.t > other.t)
        {
            return 1;
        }
        else if (this.t < other.t)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public float GetT()
    {
        return t;
    }   

    public Vector3 GetPos() 
    {
        return pos;
    }

    public Vector3 GetDir()
    {
        return dir;
    }
}
