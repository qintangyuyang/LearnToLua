print("************tolua访问C#list,Dic************")

-- 虽然自定义类Lesson3已经存在
-- 但是我们改变了这个类 里面新加了变量
-- 所以必须重新生成一次代码
local obj = Lesson3()
print("List")
obj.list:Add(10)
obj.list:Add(11)
obj.list:Add(12)
-- 得到其中一个元素
print(obj.list[0])
-- 长度
print("长度" .. obj.list.Count)

-- 遍历
for i = 0, obj.list.Count - 1 do
    print("遍历:" .. obj.list[i])
end

-- 在tolua中创建一个list
print("创建list")
-- tolua对泛型支持比较糟糕 想要用什么泛型类型的对象
-- 都需要在自定义文件中去添加 才能在tolua中使用
-- List<string>
local list2 = System.Collections.Generic.List_string()
list2:Add("1")
list2:Add("2")
list2:Add("3")
print(list2[0])

print("Dictionary")
obj.dic:Add(1,"123")
obj.dic:Add(2,"234")
obj.dic:Add(3,"345")
print(obj.dic[1])

--xlua是通过pairs去遍历 字典
--tolua中不支持这种遍历方式
--tolua中要用迭代器
local iter=obj.dic:GetEnumerator()
while iter:MoveNext() do
    local v=iter.Current
    print(v.Key.."+"..v.Value)
end
--遍历键
local iterKey=obj.dic.Keys:GetEnumerator()
while iterKey:MoveNext() do
    print("键:"..iterKey.Current)
end
--遍历值
local iterValue=obj.dic.Values:GetEnumerator()
while iterValue:MoveNext() do
    print("值:"..iterValue.Current)
end


--如果要在lua创建字典对象
--和list一样也要在自定义文件中去加
print("创建Dic")
local dic2=System.Collections.Generic.Dictionary_int_string()
dic2:Add(10,"aaa")
print(dic2[10])

local dic3=System.Collections.Generic.Dictionary_string_int()
dic3:Add("bbb",100)
--tolua使用dic 不能直接通过字符串来访问值
--print(dic3["bbb"])
local b,v=dic3:TryGetValue("bbb",nil)
print(v)