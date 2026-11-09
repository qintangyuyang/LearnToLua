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
