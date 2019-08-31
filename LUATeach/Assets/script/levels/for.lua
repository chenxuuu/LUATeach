
title = "for循环"
type = "写代码"
infomation = "学习for循环语句"
question = [[for循环在某些程度上，和while循环很相似，但是for循环可以更加简洁地表达中间累积的量

我们首先来学习`for`这个循环语法，整体的格式如下：

```lua
for 临时变量名=开始值,结束值,步长 do
    循环的代码
end
```

其中，`步长`可以省略，默认为1

`临时变量名`可以直接在代码区域使用，每次循环会自动加`步长值`，并且在到达`结束值`后停止循环

下面举一个例子，我们计算从1加到100的结果：

```
local result = 0

for i=1,100 do
    result = result + i
end

print(result)
```

上面的代码，就是当i≤100时，result不断地加i，并且i每次循环后增加1

理解了上面的代码，我们来完成下面一个简单的任务吧：

已知两个number类型的变量`min`和`max`

请计算从`min`与`max`之间，所有`7的倍数`的`和`

新建一个变量`result`，将结果存到这个变量中
]]
code = [[
--请补全代码
result = 0
for
]]
explain = "repeat这个不会进行介绍，和while语法重复度太高了"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran1 = math.random(1,100)
    local ran2 = math.random(500,1000)
    local r,i = pcall(function ()
        lua:DoString("min="..tostring(ran1).."\r\nmax="..tostring(ran2))
        lua:DoString(s)
        lua:DoString("min="..tostring(ran1).."\r\nmax="..tostring(ran2))
        local lr = lua:DoString([[
            check = 0
            for i=min,max do
                if i%7 == 0 then
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
