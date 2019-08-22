
local oldtype = type
title = "返回多个值"
type = "写代码"
infomation = "使用有多个返回值的function"
question = [[你需要使用前面几章的知识，来完成下面的题目

已知2个number类型的变量，分别代表一个长方体的长和宽

请计算这个长方形的周长和面积

请新建一个函数`rectangle`，并可以用如下形式调用：

```lua
area,len = rectangle(1,2)
--结果：
--area为2
--len为6
```

其中`area`为面积，`len`为周长
]]

code = [[
function rectangle(a,b)

end
]]
explain = "函数就是个工具箱，需要熟练掌握"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    for n=1,20 do
        local a = math.random(1, 10)
        local b = math.random(1, 10)
        local r,i = pcall(function ()
            lua:DoString(s)
            local lr = lua:DoString("return rectangle("..tostring(a)..","..tostring(b)..")")
            return lr and {lr[0],lr[1]}
        end)
        if r then
            if not (oldtype(i) == "table" and i[1] == a*b and i[2] == (a+b)*2) then
                lua:Dispose()--销毁对象释放资源
                return "当两边长度为"..tostring(a)..","..tostring(b).."时，结果不对"
            end
        else
            lua:Dispose()--销毁对象释放资源
            return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
            (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
        end
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
