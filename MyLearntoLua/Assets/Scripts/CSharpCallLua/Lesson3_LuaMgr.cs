using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_LuaMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //使用时 先初始化
        LuaMgr.instance.Init();
        //再执行
        LuaMgr.instance.Require("CSharpCallLua/Lesson2_Loader");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
