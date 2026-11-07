using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lesson2_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //主要学习目的 学会通过toLua的解析器 自定义解析路径

        //申明Lua解析器 用于执行Lua代码
        LuaState luaState = new LuaState();
        luaState.Start();

        //第二种 使用lua解析器中的方法 AddSearchPath
        luaState.AddSearchPath(Application.dataPath + "/Lua/CSharpCallLua");
        luaState.Require("Lesson2_Loader");

        //第一种 如果该文件夹 属于 Lua文件夹下 那么可以直接加父目录
        //luaState.Require("CSharpCallLua/Lesson2_Loader");

        //测试 新建文件夹的加载
        luaState.AddSearchPath(Application.dataPath + "/MyLua");
        //移除一个搜索路径 用的很少
        //luaState.RemoveSeachPath(Application.dataPath + "/MyLua");
        luaState.Require("Lesson2_Loader2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
