
title = "Lua全局变量与table"
type = "写代码"
infomation = "了解_G"
question = [[在前面我们知道了，在`table`中，可以直接用`table名[下标]`或`table名.string下标`来访问元素

实际上，在Lua中，所有的全局变量全部被存放在了一共大`table`中，这个`table`名为：

`_G`

我们可以用下面的例子来示范：

```lua
n = 123--新建变量
print(n)--输出123
print(_G.n)--输出123

_G.abc = 1--相当于新建全局变量
print(abc)--输出1

_G["def"] = 23--相当于新建全局变量
print(def)--输出23

--甚至你可以像下面这样
_G.print("hello")
_G["print"]("world")
```

现在，你明白为什么说`万物基于table`了吧？

你需要完成下面的任务：

已知有一个全局变量，名为`@#$`

请新建一个变量`result`

将`@#$`变量里的值赋值给`result`
]]
code = [[
--请补全代码
result =
]]
explain = "table基础部分学习完毕"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(1, 9999)
    local r,i = pcall(function ()
        lua:DoString("_G[\"@#$\"] = "..tostring(ran))
        lua:DoString(s)
        local lr = lua:DoString("return result == "..tostring(ran))
        return lr and lr[0]
    end)
    if r then
        if not i then
            lua:Dispose()--销毁对象释放资源
            return "result里的数据不符合要求哦"
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
