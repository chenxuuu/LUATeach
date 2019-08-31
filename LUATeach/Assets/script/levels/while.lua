
title = "while循环"
type = "写代码"
infomation = "学习while循环语句"
question = [[在实际功能实现中，经常会遇到需要循环运行的代码，比如从1到100填充table数据，我们可以直接用循环语句来实现

我们首先来学习`while`这个循环语法，整体的格式如下：

```lua
while 继续循环判断依据 do
    执行的代码
end
```

下面举一个例子，我们计算从1加到100的结果：

```lua
local result = 0
local num = 1

while num <= 100 do
    result = result + num
    num = num + 1
end

print(result)
```

上面的代码，就是当num≤100时，result不断地加num，并且num每次循环后自己加1

理解了上面的代码，我们来完成下面一个简单的任务吧：

已知两个number类型的变量`min`和`max`

请计算从`min`与`max`之间，所有`3的倍数`的`和`

新建一个变量`result`，将结果存到这个变量中
]]
code = [[
--请补全代码
result = 0

while 请完善 do

end
]]
explain = "下一章将讲另一种循环"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran1 = math.random(1,100)
    local ran2 = math.random(500,800)
    local r,i = pcall(function ()
        lua:DoString("min="..tostring(ran1).."\r\nmax="..tostring(ran2))
        lua:DoString(s)
        lua:DoString("min="..tostring(ran1).."\r\nmax="..tostring(ran2))
        local lr = lua:DoString([[
            check = 0
            for i=min,max do
                if i%3 == 0 then
                    check = check + i
                end
            end
            return result == check
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString("return result")[0]
            local lc = lua:DoString("return check")[0]
            lua:Dispose()--销毁对象释放资源
            return "和不符合要求哦，"..tostring(ran1).."加"..tostring(ran2).."应为"..
            tostring(lc)..
            "但是你的结果为"..tostring(lr)
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
