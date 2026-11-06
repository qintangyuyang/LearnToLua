using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lesson1_LuaState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //主要学习目的 学会用toLua提供的解析器(虚拟机)对象执行lua代码和脚本
        //初始化一个tolua解析器(虚拟机)
        LuaState luaState = new LuaState();
        //启动解析器(虚拟机)
        luaState.Start();

        //执行lua代码
        luaState.DoString("print('你好世界')");
        //执行lua代码 并指明出处 方便调试查看问题
        luaState.DoString("print('你好世界')", "Lesson1_LuaState.cs");

        //执行lua文件 通过DoFile执行lua文件 可加可不叫.lua后缀
        //luaState.DoFile("Main.lua");
        //第二种执行lua文件的方法 不需要加.lua后缀
        luaState.Require("Main");
        
        //检查解析器栈顶是否置空
        luaState.CheckTop();
        //销毁解析器
        luaState.Dispose();
        luaState = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
