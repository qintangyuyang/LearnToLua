print("************tolua访问C#类************")

-- tolua和xlua访问C#类非常相似
-- 固定套路
-- 命名空间.类名
-- Unity的类 比如 GameObject Transform等等 ——>UnityEngine.类名
-- UnityEngine.GameObject

-- 通过C#中的类实例化一个对象 lua没有new 所以我们直接使用 类名括号就是实例化对象
-- 默认调用的 相当于是无参构造

-- 和xlua的区别是 不需要加CS

local obj1 = UnityEngine.GameObject()
local obj2 = UnityEngine.GameObject("aaa")

-- 为了方便使用 并且节约性能 定义全局变量来存储我们C#中的类
-- 相当于取一个别名
GameObject = UnityEngine.GameObject
local obj3 = GameObject("bbb")

-- 类中的静态对象 可以使用.来调用
local obj4 = GameObject.Find("aaa")
-- 得到对象中的成员变量 也是 直接对象. 属性即可
print(obj4.transform.position.x)

-- Debug默认报错 因为 我们没有把它加到CustomSetting文件中
-- 如果发现lua使用C#中的类报错 不认识 我们需要把它加入到CustomSetting文件中的customTypeList中去
-- 然后通过菜单栏 lua中进行生成代码
Debug = UnityEngine.Debug
Debug.Log(obj4.transform.position.x)

-- 成员方法的使用
Vector3 = UnityEngine.Vector3
-- 如果要使用对象的成员方法 要使用：
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position.x)

-- 使用自定义 继承了mono的类
-- 继承了mono的类 是不能直接去new的
local obj5 = GameObject("加脚本测试")
-- 通过GameObject的 AddComponent方法 添加脚本
-- typeof 是tolua提供的一个 得到Type的方法
-- 如果发现lua使用C#中的类报错 不认识 我们需要把它加入到CustomSetting文件中的customTypeList中去
-- 然后通过菜单栏 lua中进行生成代码
obj5:AddComponent(typeof(LuaCallCSharp))

-- 如果要使用没有继承Mono的类
-- 同样 需要在CustomSetting文件夹中去添加
local t1 = Test()
t1:Speak("Test1说话")

local t2 = AAA.Test2()
t2:Speak("Test2说话")
