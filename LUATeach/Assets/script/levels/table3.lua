
title = "table下标"
type = "写代码"
infomation = "自定义下标"
question = [[在前两节，我们的`table`都只是一些简单的List（列表），每个元素的`下标`都是自动从1排列的

实际上，Lua中，下标可以直接在声明时进行指定，像下面这样：

```lua
t = {6,7,8,9}
--上面和下面的代码等价
t = {
    [1] = 6,
    [2] = 7,
    [3] = 8,
    [4] = 9,
}

--甚至你可以跳过某些下标
t = {
    [1] = 6,
    [3] = 7,
    [5] = 8,
    [7] = 9,
}
print(t[7])
--输出9

--在声明后赋予元素值也是可以的
t = {}--空的table
t[101] = 10
print(t[101])
--输出10
```

下面你需要：

新建一个变量`t`，并按下面的格式声明

下标为`1`的元素，值为`123`（number）

下标为`13`的元素，值为`"abc"`（string）

下标为`666`的元素，值为`"666"`（string）
]]
code = [[
--请补全代码
t = {

}
]]
explain = "下一节将了解另一种下标"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local r,i = pcall(function ()
        lua:DoString(s)
        local lr = lua:DoString([[return type(t) == "table" and t[1] == 123 and t[13] == "abc" and t[666] == "666"]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            lua:Dispose()--销毁对象释放资源
            return "t里的数据不符合要求哦"
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
