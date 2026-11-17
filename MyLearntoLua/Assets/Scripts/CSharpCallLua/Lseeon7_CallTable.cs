using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lseeon7_CallTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //主要学习目标 学会tolua中如何在C#中调用lua中的自定义table
        LuaMgr.instance.Init();
        LuaMgr.instance.Require("Main");

        //通过lua解析器中的getTable方法来获取
        LuaTable table = LuaMgr.instance.LuaState.GetTable("testClass");
        //访问其中的变量
        //中括号 变量名 就可以获取
        Debug.Log(table["testInt"]);
        Debug.Log(table["testBool"]);
        Debug.Log(table["testFloat"]);
        Debug.Log(table["testString"]);
        //引用拷贝
        table["testInt"] = 999;
        LuaTable table2 = LuaMgr.instance.LuaState.GetTable("testClass");
        Debug.Log(table2["testInt"]);


        //获取其中的函数
        LuaFunction function = table.GetLuaFunction("testFun");
        function.Call();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
