using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//类
#region Lesson1_CallClass
public class Test
{
    public void Speak(string str)
    {
        Debug.Log("Test:" + str);
    }
}

namespace AAA
{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log("Test:" + str);
        }
    }
}

#endregion

//枚举
#region Lesson2_CallEnum
/// <summary>
/// 自定义枚举
/// </summary>
public enum E_MyEnum
{
    Idle,
    Move,
    Atk
}
#endregion

//数组
#region Lesson3 CallArray List Dic
public class Lesson3
{
    public int[] array = new int[5] { 1, 2, 3, 4, 5 };
    public List<int> list = new List<int>();
    public Dictionary<int, string> dic = new Dictionary<int, string>();
}
#endregion

//扩展方法相关
#region Lesson4 CallFunction
public static class Tools
{
    public static void Move(this Lesson4 obj)
    {
        Debug.Log(obj.Name + "移动");
    }
}
public class Lesson4
{
    public string Name = "Lesson4";
    public void Speak(string str)
    {
        Debug.Log(str);
    }

    public static void Eat()
    {
        Debug.Log("吃东西");
    }
}
#endregion

//ref和out
#region Lesson5 CallFunction ref out
public class Lesson5
{
    public int RefFun(int a, ref int b, ref int c, int d)
    {
        b = a + d;
        c = a - d;
        return 100;
    }

    public int OutFun(int a, out int b, out int c, int d)
    {
        b = a;
        c = d;
        return 200;
    }

    public int RefOutFun(int a,out int b,ref int c)
    {
        b = a * 10;
        c = a * 20;
        return 300;
    }
}
#endregion

#region Lesson6 CallFunction 重载
public class Lesson6
{
    public int Calc()
    {
        return 100;
    }

    public int Calc(int a)
    {
        Debug.Log("int");
        return a;
    }

    public float Calc(float a)
    {
        Debug.Log("float");
        return a;
    }

    public string Calc(string a)
    {
        Debug.Log("string");
        return a;
    }

    public int Calc(int a, int b)
    {
        return a + b;
    }

    public int Calc(int a, out int b)
    {
        b = 10;
        return a + b;
    }
    
}
#endregion

public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
