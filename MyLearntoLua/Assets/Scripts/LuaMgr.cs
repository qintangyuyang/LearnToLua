using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

/// <summary>
/// 学习目标 通过luaMgr来管理唯一的一个tolua解析器
/// </summary>
public class LuaMgr : MonoBehaviour
{
    public static LuaMgr instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private LuaState luaState;
    public void Init()
    {
        //最后打包的时候 再用
        //new LuaCustomLoader();

        //初始化唯一的luaState
        luaState = new LuaState();
        luaState.Start();
    }

    /// <summary>
    /// 该属性可以让外部获取到 解析器
    /// </summary>
    public LuaState LuaState
    {
        get
        {
            return LuaState;
        }
    }
    /// <summary>
    /// 提供一个外部执行 lua语法字符串的方法
    /// </summary>
    /// <param name="str"></param>
    /// <param name="chunkName"></param>
    public void DoString(string str, string chunkName = "LuaMgr.cs")
    {
        luaState.DoString(str, chunkName);
    }

    /// <summary>
    /// 执行指定名字的lua脚本
    /// </summary>
    /// <param name="fileName"></param>
    public void Require(string fileName)
    {
        luaState.Require(fileName);
    }

    /// <summary>
    /// 销毁lua解析器
    /// </summary>
    public void Dispose()
    {
        if (luaState == null)
            return;
        luaState.CheckTop();
        luaState.Dispose();
        luaState = null;
    }
}
