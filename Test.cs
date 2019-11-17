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

    public int GetSet
    { get; private set; }
    
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
        none.SetWeight(100);
        int a = none.GetWeight();
    }
}

class Father
{
    public string normal = "wife info";
    private string secret = "very important info of flavor";
    protected string knowHow = "secret recipe of family";

    void n()
    {
        // Father는 자신의 클래스 안에 있는건 다 접근가능
        string a = normal;   
        string b = secret;   
        string c = knowHow;  
    }
}

class Son : Father
{
    void Suceeding()
    {
        string a = normal;
        string b = secret;   // Father 상속해도 private에 접근 불가
        string c = knowHow;  // Father 상속해서 protected에 접근 가능
    }
}

class Thief
{
    void Stolen()
    {
        Father father = new Father();
        string a = father.normal;
        //string b = father.secret;   // private에 접근 불가
        //string c = father.knowHow;  // protected에 접근 불가
    }
}

public class ConstSample
{
    // const 는 상수라 못 바꾼다. 
    public const double roket = 3.14;
}

class ConstTest
{
    public void Main()
    {

        // const 는 자동 static 이라 시작과 동시에 생성. 그래서 다이렉트로 접근가능.
        Debug.Log(ConstSample.roket);
    }
}

public class RoketOutfact
{
    // readonly는 const와 다르게 생성자에서 딱 한번 값을 할당할 수 있다. const는 안됨.
    // const와 다르게 자동으로 static 되지 않는다. 
    //  -static 붙이면 스태틱 상수 안붙이면 일반 상수 . 

    public readonly static int weather_static;
    public readonly int weather_normal;

    // static 생성자
    static RoketOutfact()
    {
        // 스태틱 생성자에선 스태틱 상수만 읽어올 수 있음.일반상수(x).
        weather_static = 100;
    }

    // 일반 생성자
    RoketOutfact(int w)
    {
        /*
        // 일반 생성자에선 일반 상수만 읽어올 수 있음. static(x).
        weather_normal = 200;
        */
        weather_normal = w;
    }

    public static void Main()
    {
        // static readonly 호출 : static 호출 방식 ( 별도의 메모리할당 필요없음)
        Debug.Log(RoketOutfact.weather_static);

        /*
         // 일반상수는 일반 호출방식 ( 객체를 만들어서 메모리 할당 해야 사용할수 있음)
         RoketOutfact nrm = new RoketOutfact();
         Debug.Log(nrm);
        */


        // 일반상수 응용
        RoketOutfact wind = new RoketOutfact(1000);
        Debug.Log(wind);
    }

}

/*
 * 오버로딩 (over loading)
 * 하나의 이름으로 여러개의 함수를 만드는 기법
 * 매개변수의 종류를 달리해서 각각의 매개변수에 따라 호출되는 함수를 고를수 있음
 * 
 * 변환형 함수이름 (int a)
 * {
 * 
 * }
 * * 변환형 함수이름 (double a)
 * {
 * 
 * }
    * 변환형 함수이름 (String a)
 * {
 * 
 * }
    이런식

    
 */

public class Donation
{
    public int TodayDonation(int earnMoney)
    {
        return earnMoney;
    }
    public double TodayDonation(double earnMoney)
    {
        return earnMoney;
    }
    public string TodayDonation(double earnMoney)
    {
        return earnMoney;
    }
}

public class GetToday
{
    public void Main()
    {
        //객체생성
        Donation getMoney = new Donation();
        int todayMoney = 0;
        double todayBox = 0;
        string todayLetter = 0;

        // 후원 집계
        todayMoney += getMoney.TodayDonation(10000);
        todayBox += getMoney.TodayDonation(2.2);
        todayLetter += getMoney.TodayDonation("I Love You");

        Debug.Log("오늘의 수익: {0}", todayMoney);
        Debug.Log("오늘의 택배: {0}", todayBox);
        Debug.Log("오늘의 편지: {0}", todayLetter);
    }
}
