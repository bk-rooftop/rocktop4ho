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
//연산자 오버로딩

    //연산자 오버로딩은 public static '반환형' operator '연산자' (매개변수) 형태임.
    class 귀요미
{
    public static string operator +(귀요미 one, 귀요미 two)
    {
        return "귀요미";
    }
    public static string operator *(귀요미 one, 귀요미 two)
    {
        return "과로사";
    }
    public static string operator -(귀요미 one, 귀요미 two)
    {
        return "행복해";
    }
    public static string operator /(귀요미 one, 귀요미 two)
    {
        return "너가해";
    }
}

class OperOverloadTestMain
{
    public static void Main()
    {
        귀요미 일 = new 귀요미();
        Debug.Log(일 + 일);
        Debug.Log(일 * 일);
        Debug.Log(일 - 일);
        Debug.Log(일 / 일);
    }

}

// this 의 사용법
// this는 함수내에서 클래스의 내의 변수에 접근할때 사용. 아래 예제처럼 함수의 매개변수 이름과 클래스변수의 이름이 같을때 this를 사용해서 클래스 변수를 호출할수있음. 
// this 를 이용해 생성자를 여러개 만든경우(ex 오버로딩) this를 사용해서 여러개의 생성자를 한꺼번에 호출할수있음. 

public class ThisTest
{
    private string name = "으아아";
    public ThisTest(string name)
    {
        Debug.Log(name);
        Debug.Log(this.name);
    }

    public static void Main()
    {
        ThisTest a = new ThisTest("홍길동");

    }
}

// this를 사용안해서 따로따로 생성자 함수를 호출하는경우

public class 알바호출
{
    // 1번 생성자
    public 알바호출()
    {

    }
    // 2번 생성자
    public 알바호출(string a)
    {

    }
    // 3번 생성자
    public 알바호출(string a, int c)
    {

    }

    public static void Main()
    {
        // 1번 알바 호출
        알바호출 call1 = new 알바호출();
        // 2번 알바 호출
        알바호출 call2 = new 알바호출("!!!!");
        // 3번 알바 호출
        알바호출 call3 = new 알바호출("!!!!", 5000);

    }
}

// this 를 사용해 여러가지 생성자를 한번에 호출하는 경우 

public class 알바호출
{
    // 1번 생성자
    public 알바호출() : this ("분신술 사용!!") 
    //아래 함수에서 빈 생성자(1번)을 호출했으나 this가 있어서 this가 가르키는 생성자(매개변수 스트링인)에게 먼저 갔다가 끝나면 돌아와서 1번생성자 실행
    {
        Console.WriteLine("1번 생성자 호출");
    }
    // 2번 생성자
    public 알바호출(string a) : this("2번분신술 사용!!", 5000)
    // 위에서 2번을 먼저실행시킨다고 해서 와봤더니 여기도 this(스트링, 인트)인 생성자를 가르킴. 그래서 3번생성자에게 가서 실행후 2번생성자 실행. 
    {
        Console.WriteLine("2번 생성자 호출");
    }

    // 3번 생성자
    public 알바호출(string a, int c)
    {
        Console.WriteLine("3번 생성자 호출");
    }

    public static void Main()
    {
        // 1번 알바 호출
        알바호출 call1 = new 알바호출();
    }
}

/* 1번 생성자가 2번생성자를 상속받고
 * 2번 생성자가 3번 생성자를 상속 받으면 실행 순서
 * 
 * 할아버지 > 아빠 > 아들 이라고 치면 
 * 
 * 할아버지 
 * {
 * 
 * }
 * 아빠 : 할아버지
 * {
 * 
 * }
 * 아들 : 아빠
 * {
 * 
 * } 
 * 
 * 이런식이라고 치면 아들을 실행시키면 아빠를 먼저 실행시키기 위해 가고 아빠를 보면 할아버지 상속이니까 할아버지를 먼저 실행시키게 됨
 * 결국 아들을 실행시키지만 실행순서는 할아버지 -> 아빠 -> 아들 순으로 실행시키게 된다 
*/

class 아버지
{
    public void 아빠옷()
    {
        Debug.Log("아빠의 오래된 옷");
    }
}

class 아들 : 아버지
{
    //함수를 오버라이딩 할떄 new를 붙여서 오버라이딩 함수와 일반 함수를 구분한다. 
    new public void 아빠옷()
    {
        Debug.Log("아들이 수선한 아빠의 옷");
    }

    public void 아들옷()
    {
        Debug.Log("아들의 원래 옷");
    }
}

class Main
{
    public void Main()
    {
        아들 son = new 아들();
        son.아빠옷();
        son.아들옷();
    }
}

class 아버지
{
    public void 아빠옷()
    {
        Debug.Log("아빠의 오래된 옷");
    }
}

class 아들 : 아버지
{
    //함수를 오버라이딩 할떄 new를 붙여서 오버라이딩 함수와 일반 함수를 구분한다. 
    new public void 아빠옷()
    {
        Debug.Log("아들이 수선한 아빠의 옷");
    }

    public void 아들옷()
    {
        Debug.Log("아들의 원래 옷");
    }
    public void 돈없는아들옷()
    {
        //base를 붙이면 오버라이딩 되지 않은 아버지클래스의 함수를 호출한다.
        base.아빠옷();
        아빠옷();
    }
}
class Main
{
    public void Main()
    {
        아들 son = new 아들();
        son.돈없는아들옷();
    }  
}

class For
{
    void Start()
    {
        LoopA(); // LoopA 실행 끝날때까지 LoopA 에게 주도권 넘어감 -> 끝나면 다음줄 실행
        LoopB();
    }

    void LoopA() 
    {
        for (i = 0; i < 100; i++)
        {
            print("i의 값 =" + i);
        }
    }

    void LoopB()
    {
        for (x = 0; x < 100; x++)
        {
            print("x의 값 =" + x);
        }
    }
}

class For2
{
    void Start()
    {
        Startcoroutine(LoopA());
        Startcoroutine(LoopB());
    }

    IEnumerator LoopA()
    {
        for (i = 0; i < 100; i++)
        {
            print("i의 값 =" + i);
        }
    }

    IEnumerator LoopB()
    {
        for (x = 0; x < 100; x++)
        {
            print("x의 값 =" + x);
        }
    }
}
