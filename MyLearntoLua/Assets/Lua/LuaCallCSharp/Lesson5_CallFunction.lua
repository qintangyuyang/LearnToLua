print("************tolua访问C#的ref和out************")

-- tolua和xlua中对ref和out函数使用基本类似
-- 通过多返回值的形式来处理的
-- 如果是out和ref函数
-- 第一个返回值 是函数默认的返回值
-- 之后的返回值 就是ref和out对应的结果 从左到右一一对应

local obj = Lesson5()

print(obj:RefFun(10, 0, 0, 1))
local a, b, c = obj:RefFun(10, 0, 0, 1)
print(a)
print(b)
print(c)
-- tolua中out函数调用和xlua有区别
-- xlua中可以省略传入 out参数
-- tolua不能省略
print(obj:OutFun(20, 0, 0, 30))
local a, b, c = obj:OutFun(20, 0, 0, 30)
print(a)
print(b)
print(c)

--在tolua中要使用ref和out是 尽量就使用out
print(obj:RefOutFun(20,nil,1))
local a, b, c = obj:RefOutFun(20,nil,1)
print(a)
print(b)
print(c)
