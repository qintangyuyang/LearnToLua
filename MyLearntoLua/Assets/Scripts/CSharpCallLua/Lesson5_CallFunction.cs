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

        #region 无参无返回
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
        function.Dispose();
        #endregion

        #region 有参有返回
        //第一种方式 通过luafunction的call来访问
        function = LuaMgr.instance.LuaState.GetFunction("testFun2");
        //开始使用
        function.BeginPCall();
        //传参
        function.Push(99);
        //传参结束 调用
        function.PCall();
        //得到返回值
        int result = (int)function.CheckNumber();
        //执行结束
        function.EndPCall();
        Debug.Log("有参有返回值 Call：" + result);

        //第二种方式 通过 luaFunction Invoke方法调用
        //最后一个泛型类型 是返回值类型 前面的 是参数类型 依次往后排
        result = function.Invoke<int, int>(199);
        Debug.Log("有参有返回值 Invoke" + result);

        //第三种方式 传委托
        Func<int, int> func = function.ToDelegate<Func<int, int>>();
        result = func(900);
        Debug.Log("有参有返回值 委托" + result);

        //第四种方式 不得function 直接执行
        result = LuaMgr.instance.LuaState.Invoke<int, int>("testFun2", 800, true);
        Debug.Log("有参有返回值 通过解析器直接调用" + result);
        #endregion

    }

    // Update is called once per frame
    void Update()
    {

    }
}
