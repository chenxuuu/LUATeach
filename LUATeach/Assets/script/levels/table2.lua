
title = "简单table"
type = "写代码"
infomation = "什么都能装的table"
question = [[上一节里，我们将`table`来表示`数组`，实际上，`table`中可以包括`任意类型的数据`

比如我们可以在`table`中放置`number`和`string`数据，类似下面的代码：

```lua
t = {"abc",223,",..a",123123}
```

我们甚至能在里面放`function`变量

```lua
t = {
    function() return 123 end,
    function() print("abc") end,
    function(a,b) return a+b end,
    function() print("hello world") end,
}
```

这些`table`访问每个元素的方式仍然是直接用下标，并且也能用下标来进行修改

下面你需要完成：

新建一个`table`，名为`funcList`，并实现以下功能

调用`funcList[1](a,b)`，返回a和b的乘积

调用`funcList[2](a,b)`，返回a减b的差

调用`funcList[3](a)`，返回a的相反数（-a）

]]
code = [[
--请补全代码
funcList = {

}
]]
explain = "万物基于table，你正在慢慢理解"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    for n=1,20 do
        local a = math.random(1, 100)
        local b = math.random(1, 100)
        local r,i = pcall(function ()
            lua:DoString(s)
            local lr = lua:DoString([[
return type(funcList[1]) == "function" and
    type(funcList[2]) == "function" and
    type(funcList[3]) == "function" and
    funcList[1](]]..tostring(a)..[[,]]..tostring(b)..[[) == ]]..tostring(a*b)..[[ and
    funcList[2](]]..tostring(a)..[[,]]..tostring(b)..[[) == ]]..tostring(a-b)..[[ and
    funcList[3](]]..tostring(a)..[[) == ]]..tostring(-a))
            return lr and lr[0]
        end)
        if r then
            if not i then
                lua:Dispose()--销毁对象释放资源
                return "funcList里的函数不符合要求哦"
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
