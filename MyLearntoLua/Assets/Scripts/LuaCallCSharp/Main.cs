using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main脚本 作为C#的主入口 来启动lua脚本
/// </summary>
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.instance.Init();
        LuaMgr.instance.Require("Main");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
