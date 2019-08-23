
title = "table下标进阶"
type = "写代码"
infomation = "字符串下标"
question = [[在上一节，我们学习了如何自定义下标，其实在Lua中，下标也可以是字符串，如下面的例子

```lua
t = {
    ["apple"] = 10,
    banana = 12,
    pear = 6,
}
--使用["下标"] = 值
--和  下标 = 值
--都是正确写法
--当第二种方式有歧义时，应该用第一种方式

--可以用下面两种方式访问：
print(t["apple"])
--输出10
print(t.apple)
--输出10
--当第二种方式有歧义时，应该用第一种方式
```

可见，在使用`string`作为下标时，`table`的灵活性提升了一共数量级。

`string`作为下标时，也可以动态赋值：

```lua
t = {} -- 空table
t["new"] = "新的值"
print(t.new)
--输出 新的值
```

下面你需要完成：

新建`table`变量`t`

下标为`apple`的元素，值为`123`（number）

下标为`banana`的元素，值为`"abc"`（string）

下标为`1@1`的元素，值为`"666"`（string）

]]
code = [[
--请补全代码
t = {

}
]]
explain = "你猜，为什么说Lua中，万物基于table呢？"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local r,i = pcall(function ()
        lua:DoString(s)
        local lr = lua:DoString([[return type(t) == "table" and t.apple == 123 and t.banana == "abc" and t["1@1"] == "666"]])
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
