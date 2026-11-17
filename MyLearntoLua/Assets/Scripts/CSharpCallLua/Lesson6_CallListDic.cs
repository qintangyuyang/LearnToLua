using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lesson6_CallListDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //主要学习目标 学会tolua 如何在C#中调用lua中talbe表现的list和Dictionary
        LuaMgr.instance.Init();
        LuaMgr.instance.Require("Main");

        //list相关
        //tolua中 C#得到lua中的表 都只有一个套路 通过luatable来获取
        LuaTable table = LuaMgr.instance.LuaState.GetTable("testList");
        Debug.Log(table[1]);
        Debug.Log(table[2]);
        Debug.Log(table[3]);
        Debug.Log(table[4]);
        Debug.Log(table[5]);

        object[] objs = table.ToArray();
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log("遍历打印:" + objs[i]);
        }

        //引用拷贝
        table[1] = 999;
        LuaTable tabletmp = LuaMgr.instance.LuaState.GetTable("testList");
        Debug.Log("测试引用拷贝" + tabletmp[1]);

        LuaTable table2 = LuaMgr.instance.LuaState.GetTable("testList2");
        Debug.Log(table2[1]);
        Debug.Log(table2[2]);
        Debug.Log(table2[3]);
        Debug.Log(table2[4]);
        Debug.Log(table2[5]);

        objs = table2.ToArray();
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log("遍历打印:" + objs[i]);
        }

        //Dic相关
        LuaTable Dic = LuaMgr.instance.LuaState.GetTable("testDic");
        Debug.Log(Dic["1"]);
        Debug.Log(Dic["2"]);
        Debug.Log(Dic["3"]);
        Debug.Log(Dic["4"]);

        Dic["1"] = 999;
        LuaTable Dictmp = LuaMgr.instance.LuaState.GetTable("testDic");
        Debug.Log("引用拷贝测试:" + Dictmp["1"]);

        //通过中括号得到值 只支持int和string 其他类型没办法来直接获取到值
        LuaTable Dic2 = LuaMgr.instance.LuaState.GetTable("testDic2");
        LuaDictTable<object, object> luaDic2 = Dic2.ToDictTable<object, object>();
        Debug.Log(luaDic2["1"]);
        Debug.Log(luaDic2[true]);
        Debug.Log(luaDic2[false]);
        Debug.Log(luaDic2["123"]);

        //dic建议使用迭代器遍历
        IEnumerator<LuaDictEntry<object, object>> ie = luaDic2.GetEnumerator();
        while (ie.MoveNext())
        {
            Debug.Log(ie.Current.Key + "_" + ie.Current.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
