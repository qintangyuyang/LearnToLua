print("************tolua访问C#的重载************")

local obj = Lesson6()

print(obj:Calc())
-- tolua和xlua一样 对重载函数的精度支持不太好
-- lua中只有Number一种数值类型 它会分不清
print(obj:Calc(1))
print(obj:Calc(1.2))
print(obj:Calc("123"))

-- 这里调用的是非out参数的函数重载
print(obj:Calc(10, 1))
-- 在tolua中用out重载 有一个固定套路
-- 意味着我们在使用 Unity中的一些API时有out时 我们就可以用nil占位了
-- tolua中对ref支持不太好 建议不要使用 特别是在重载函数时
print(obj:Calc(10, nil))
