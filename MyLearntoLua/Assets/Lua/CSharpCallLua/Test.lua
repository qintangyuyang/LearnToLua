print("C#调用Lua的测试脚本")

-- 全局变量
testNumber = 1
testBool = true
testFloat = 1.2
testString = "aaa"
-- 通过C#没办法直接获取局部变量
local testLocal = 10

-- 无参无返回值
testFun = function ()
    print("无参无返回值")
end
-- 有参有返回
testFun2 = function (a)
    print("有参有返回")
    return a + 100
end
-- 多返回值
testFun3 = function (a)
    print("多返回值")
    return 1, 2, false, "123", a
end
-- 变长参数函数
testFun4 = function (a, ...)
    print("变长参数函数")
    print(a)
    arg = { ... }
    for k, v in pairs(arg) do
        print(k, v)
    end
    return
end

-- table表现的list
testList = { 10, 20, 30, 40, 50, 60 }
testList2 = { "123", "123", true, 1, 1.2 }
-- table表现的Dictionary
testDic = { ["1"] = 1, ["2"] = 10, ["3"] = 20, ["4"] = 30 }
testDic2 = { ["1"] = 1, [true] = 1, [false] = true, ["123"] = false }

-- lua中的一个自定义table（类）
testClass = {
    testInt = 1,
    testBool = true,
    testFloat = 1.2,
    testString = "123",
    testFun = function ()
        print("表中的函数打印")
    end
}
