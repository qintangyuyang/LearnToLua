using System.Collections;
using System.Collections.Generic;
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
