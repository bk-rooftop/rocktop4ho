using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스태틱 변수는 바로 다이렉트로 클래스명으로 접근가능.
//일반 변수는 객채 생성 메모리를 할당해줘야 접근 가능하다.
public class Access
{
    public static int luck = 0;
    public int str = 0;
}

class main
{
    public static void Main()
    {
        Access.luck = 1; 
        Access stat = new Access(); // 객체 생성해서 메모리 할당
        stat.str = 1;
    }
    
}

class 휴먼
{

}

public class Stats
{
    public int age = 20;
    private int weight = 50;

    public void SetWeight(int x)
    {
        weight = x;

    }

    public int GetWeight()
    {
        return weight;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stats none = new Stats();

    }
}

