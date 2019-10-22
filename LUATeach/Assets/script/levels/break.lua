
title = "break"
type = "写代码"
infomation = "学习break语句"
question = [[前面我们学习了循环语句，有些时候循环运行到一半，我们不想再继续运行了，怎么办呢？

我们可以在一个循环体中使用`break`，来立即结束本次循环，继续运行下面的代码

比如像下面这样，计算1-100相加途中，小于100的最大的和：

```lua
result = 0
for i=1,100 do
    result = result + i
    if result > 100 then
        result = result - i
        break
    end
end

print(result)
```

可以看见，当发现和大于100后，代码立即把`result`的值还原到了加上当前数字之前的状态，并且调用`break`语句，立即退出了本次循环

实际上，在`while`中，我们也可以使用`break`:

```lua
result = 0
c = 1
while true do
    result = result + c
    c = c + 1
    if result > 100 then
        result = result - i
        break
    end
end

print(result)
```

我们在这里直接使用了死循环（因为`while`的继续运行判断依据始终为`true`），整体逻辑也和之前for的代码一致，当发现和大于100后，代码立即把`result`的值还原到了加上当前数字之前的状态，并且调用`break`语句，立即退出了本次循环

现在你需要完成一项任务：

请求出大于变量`max`的，最小的`13的倍数`

并将结果放置于新建的变量`result`中

（`max`大于0）
]]
code = [[
--请补全代码
result = 0
for
]]
explain = "至此，你已经初步掌握了循环语句"

check = function(s)

    if not s:find("for") and not s:find("while") then
        return "请使用循环语句来解决该问题"
    end

    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran2 = math.random(500,2000)
    local r,i = pcall(function ()
        lua:DoString("max="..tostring(ran2))
        lua:DoString(s)
        lua:DoString("max="..tostring(ran2))
        local lr = lua:DoString([[
            check = 0
            for i=max,max+13 do
                if i%13==0 then
                    check=i
                    break
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
            return "和不符合要求哦，当max为"..tostring(ran2).."时符合要求的数应为"..tostring(lc).."\r\n"..
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
