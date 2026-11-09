using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using UnityEngine.Events;

public class Lesson5_CallFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.instance.Init();
        LuaMgr.instance.Require("Main");

        //第一种方法 通过 GetFunction方法获取
        LuaFunction function = LuaMgr.instance.LuaState.GetFunction("testFun");
        //调用
        function.Call();
        //执行完后销毁
        function.Dispose();

        //第二种方法 通过 中括号 函数名的形式
        function = LuaMgr.instance.LuaState["testFun"] as LuaFunction;
        function.Call();
        function.Dispose();

        //第三种方式 转为委托来使用
        //首先得到一个luaFunction然后再转成委托的形式
        function = LuaMgr.instance.LuaState["testFun"] as LuaFunction;
        //通过luafunction中的方法 存入到委托中再使用
        UnityAction action = function.ToDelegate<UnityAction>();
        action.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
