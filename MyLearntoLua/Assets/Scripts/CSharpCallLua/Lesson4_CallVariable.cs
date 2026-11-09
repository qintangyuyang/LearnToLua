using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_CallVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.instance.Init();
        LuaMgr.instance.Require("Main");

        //获取全局变量
        //toLua中访问全局变量 一个套路 得到luaState解析器 然后中括号 变量名 即可得到
        Debug.Log("testNumber:" + LuaMgr.instance.LuaState["testNumber"]);
        Debug.Log("testBool:" + LuaMgr.instance.LuaState["testBool"]);
        Debug.Log("testFloat:" + LuaMgr.instance.LuaState["testFloat"]);
        Debug.Log("testString:" + LuaMgr.instance.LuaState["testString"]);

        //值拷贝
        int value = Convert.ToInt32(LuaMgr.instance.LuaState["testNumber"]);
        value = 99;
        Debug.Log("testNumber:" + LuaMgr.instance.LuaState["testNumber"]);
        //如果要该值 直接这样写即可
        LuaMgr.instance.LuaState["testNumber"] = 99;
        Debug.Log("testNumber:" + LuaMgr.instance.LuaState["testNumber"]);

        //toLua中也没有办法通过C#得到local申明的局部临时变量
        Debug.Log("testLocal:" + LuaMgr.instance.LuaState["testLocal"]);

        //可以在C#处为lua添加全局变量 相当于在lua中的_G中加了一个变量
        Debug.Log("addValue:" + LuaMgr.instance.LuaState["addValue"]);
        LuaMgr.instance.LuaState["addValue"] = 990;
        Debug.Log("addValue:" + LuaMgr.instance.LuaState["addValue"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
