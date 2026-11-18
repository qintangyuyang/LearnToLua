print("************tolua访问C#的拓展方法************")

-- 静态方法的调用 就是 类.方法名
Lesson4.Eat()

-- 成员方法
local obj = Lesson4()
---成员方法 一定用冒号
obj:Speak("shsh")

--想要拓展方法使用成功
--自定义文件加 _GT(typeof(Lesson4)).AddExtendType(typeof(Tools)),
obj:Move()