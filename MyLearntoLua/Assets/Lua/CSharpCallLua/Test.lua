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

-- lua协程相关的代码
local coDelay = nil

-- 开启协程
-- 协程相关的lua逻辑 这些内容都是toLua帮我们实现好的
-- lua自带的 creat resume yield status wrap running
StartDelay = function ()
    coDelay = coroutine.start(Delay)
end

Delay = function ()
    local c = 1
    while true do
        -- 等待一秒执行一次逻辑
        coroutine.wait(1)
        print("Count:" .. c)
        c = c + 1
        if c >= 5 then
            StopDelay()
            break
        end
    end
end

-- 停止协程
StopDelay = function ()
    coroutine.stop(coDelay)
end
