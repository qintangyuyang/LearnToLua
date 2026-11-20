print("************tolua访问C#的委托和事件************")

local obj = Lesson7()

-- 委托是用来装函数的
-- 要使用C#中的委托 就是用来装lua函数
local fun = function ()
    print("Lua函数Fun")
end

print("委托中加函数*************")
-- lua中没有复合运算符 不能用+=
-- 如果是第一次在委托中加函数 因为是nil 不能直接+ 所以第一次要先等
obj.del = fun
obj.del = obj.del + fun
obj.del = obj.del
    + function ()
        print("临时申明的函数")
    end

-- xlua执行 obj.del()
-- tolua中没有办法这样直接执行 tolua中没办法直接执行委托函数
obj:DoDel()

print("委托中减函数*************")
obj.del = obj.del - fun
obj.del = obj.del - fun
obj:DoDel()

print("委托中清空函数*************")
obj.del = nil
obj:DoDel()

local fun2 = function ()
    print("事件加的函数")
end
print("事件中加函数*************")
-- xlua中事件加函数 对象:事件名("+/-",函数)
-- tolua中事件加减函数 和 委托方式一样
--obj.eventAction = fun2 会报错 因为遵循C#中的规则 不能直接= 只能+=和-=
obj.eventAction = obj.eventAction + fun2
obj.eventAction = obj.eventAction
    + function ()
        print("事件加的匿名函数")
    end
obj:DoEvent()

print("事件中减函数*************")
obj.eventAction = obj.eventAction - fun2
obj:DoEvent()

print("事件中清空函数*************")
obj:CleanEvent()
obj:DoEvent()