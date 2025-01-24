using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
    public int hp = 1000;
    public float speed = 10;
    public int jump = 2;
    // public static int level = 1;
    // public static int exp = 0;

    public int getHP(){
        return hp;
    }

    public float getSpeed(){
        return speed;
    }

    public int getJump(){
        return jump;
    }



}
