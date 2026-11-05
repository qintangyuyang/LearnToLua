using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ABMgr : MonoBehaviour
{
    public static ABMgr instance;
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

    //主包
    private AssetBundle mainAB = null;
    //主包依赖的配置文件
    private AssetBundleManifest mainfest = null;
    //存储加载过的AB包
    private Dictionary<string, AssetBundle> abDic = new Dictionary<string, AssetBundle>();

    /// <summary>
    /// AB包加载路径
    /// </summary>
    private string PathURL
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }

    /// <summary>
    /// 主包名 方便修改
    /// </summary>
    private string MainABName
    {
        get
        {
#if UNITY_IOS
            return "IOS";
#elif UNITY_ANDROID
            return "Android";
#else
            return "PC";
#endif
        }
    }

    /// <summary>
    /// 加载AB包
    /// </summary>
    /// <param name="ABName"></param>
    public void LoadAB(string ABName)
    {
        if (mainAB == null)
        {
            mainAB = AssetBundle.LoadFromFile(PathURL + MainABName);
            mainfest = mainAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }
        //获取依赖包相关信息
        AssetBundle ab = null;
        string[] strs = mainfest.GetAllDependencies(ABName);
        for (int i = 0; i < strs.Length; i++)
        {
            //判断包是否被加载过
            if (!abDic.ContainsKey(strs[i]))
            {
                ab = AssetBundle.LoadFromFile(PathURL + strs[i]);
                abDic.Add(strs[i], ab);
            }
        }
        //加载资源来源包
        //如果没有加载过 再加载
        if (!abDic.ContainsKey(ABName))
        {
            ab = AssetBundle.LoadFromFile(PathURL + ABName);
            abDic.Add(ABName, ab);
        }
    }

    /// <summary>
    /// 同步加载,不指定类型
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadRes(string abName, string resName)
    {
        LoadAB(abName);
        //为了外面方便 在加载资源时 判断一下 资源是不是GameObject
        //如果是 直接实例化了 再返回
        UnityEngine.Object obj = abDic[abName].LoadAsset(resName);
        if (obj is GameObject)
        {
            return Instantiate(obj);
        }
        else
        {
            return obj;
        }
    }

    /// <summary>
    /// 同步加载 根据type指定类型
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadRes(string abName, string resName, Type type)
    {
        LoadAB(abName);
        UnityEngine.Object obj = abDic[abName].LoadAsset(resName, type);
        if (obj is GameObject)
        {
            return Instantiate(obj);
        }
        else
        {
            return obj;
        }
    }

    /// <summary>
    /// 同步加载 根据泛型指定类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public T LoadRes<T>(string abName, string resName) where T : UnityEngine.Object
    {
        LoadAB(abName);
        T obj = abDic[abName].LoadAsset<T>(resName);
        if (obj is GameObject)
        {
            return Instantiate(obj);
        }
        else
        {
            return obj;
        }
    }

    /// <summary>
    ///异步加载
    ///这里的异步加载 AB包并没有使用异步加载
    ///只是从AB包中 加载资源时 使用异步
    ///根据名字异步加载资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="callBack"></param>
    public void LoadResAsync(string abName, string resName, UnityAction<UnityEngine.Object> callBack)
    {
        StartCoroutine(ReallyLoadResAsync(abName, resName, callBack));
    }
    private IEnumerator ReallyLoadResAsync(string abName, string resName, UnityAction<UnityEngine.Object> callBack)
    {
        LoadAB(abName);
        AssetBundleRequest abr = abDic[abName].LoadAssetAsync(resName);
        yield return abr;
        if (abr.asset is GameObject)
        {
            callBack(Instantiate(abr.asset));
        }
        else
        {
            callBack(abr.asset);
        }
    }

    /// <summary>
    /// 根据Type异步加载资源
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="type"></param>
    /// <param name="callBack"></param>
    public void LoadResAsync(string abName, string resName, Type type, UnityAction<UnityEngine.Object> callBack)
    {
        StartCoroutine(ReallyLoadResAsync(abName, resName, type, callBack));
    }

    private IEnumerator ReallyLoadResAsync(string abName, string resName, Type type, UnityAction<UnityEngine.Object> callBack)
    {
        //加载AB包
        LoadAB(abName);
        //为了外面方便 在加载资源时 判断一下 资源是不是GameObject
        //如果是 直接实例化了 再返回
        AssetBundleRequest abr = abDic[abName].LoadAssetAsync(resName, type);
        yield return abr;
        //异步加载结束后 通过委托 传递给外部来使用
        if (abr.asset is GameObject)
        {
            callBack(Instantiate(abr.asset));
        }
        else
        {
            callBack(abr.asset);
        }
    }

    /// <summary>
    /// 根据泛型 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="callBack"></param>
    public void LoadResAsync<T>(string abName, string resName, UnityAction<T> callBack) where T : UnityEngine.Object
    {
        StartCoroutine(ReallyLoadResAsync<T>(abName, resName, callBack));
    }

    private IEnumerator ReallyLoadResAsync<T>(string abName, string resName, UnityAction<T> callBack) where T : UnityEngine.Object
    {
        //加载AB包
        LoadAB(abName);
        //为了外面方便 在加载资源时 判断一下 资源是不是GameObject
        //如果是 直接实例化了 再返回
        AssetBundleRequest abr = abDic[abName].LoadAssetAsync<T>(resName);
        yield return abr;
        //异步加载结束后 通过委托 传递给外部来使用
        if (abr.asset is GameObject)
        {
            callBack(Instantiate(abr.asset) as T);
        }
        else
        {
            callBack(abr.asset as T);
        }
    }

    /// <summary>
    /// 单个包卸载
    /// </summary>
    /// <param name="abName"></param>
    public void UnLoad(string abName)
    {
        if (abDic.ContainsKey(abName))
        {
            abDic[abName].Unload(false);
            abDic.Remove(abName);
        }
    }

    /// <summary>
    /// 所有包卸载
    /// </summary>
    public void ClearAb()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        abDic.Clear();
        mainAB = null;
        mainfest = null;
    }
}
