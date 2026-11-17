using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lesson8_CallCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.instance.Init();
        LuaMgr.instance.Require("Main");

        LuaFunction function = LuaMgr.instance.LuaState.GetFunction("StartDelay");
        function.Call();
        function.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
