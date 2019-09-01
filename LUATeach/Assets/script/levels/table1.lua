
title = "数组"
type = "写代码"
infomation = "认识数组"
question = [[数组，使用一个变量名，存储一系列的值

很多语言中都有数组这个概念，在Lua中，我们可以使用`table`（`表`）来实现这个功能

在Lua中，table是一个一系列元素的集合，使用大括号进行表示，其中的元素之间以逗号分隔，类似下面的代码：

```lua
t = {1,3,8,5,4}
```

我们可以直接使用元素的`下标`，来访问、或者对该元素进行赋值操作。

在上面的`table`变量`t`中，第一个元素的`下标`是`1`，第二个是`2`，以此类推。

我们可以用`变量名`+`中括号`，中括号里加上下标，来访问或更改这个元素，如下面的例子：

```lua
t = {1,3,8,5,4}
print(t[1]) --打印1
print(t[3]) --打印8

t[2] = 99 --更改第二个元素的值
print(t[2]) --打印99

t[6] = 2 --凭空新建第六个元素并赋值
print(t[6]) --打印2

print(t[10])
--因为不存在，打印nil
```

以上就是table最简单的一个例子了，就是当作数组来用（注意，一般语言中的数组基本都为不可变长度，这里的table为可变长度）

下面你需要完成：

新建一个table，名为`cards`，存入1-10十个数字

将第3个元素与第7个元素交换

将第9个元素与第2个元素交换

增加第11个变量，值为23
]]
code = [[
--请补全代码
cards =
]]
explain = "在Lua中，万物基于table，到后面你就明白了"

check = function(s)

    if s:find("1.*,.*9.*,.*7.*") then
        return "请自觉做题，作弊没什么意义"
    end

    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local r,i = pcall(function ()
        lua:DoString(s)
        local lr = lua:DoString([[
local result = true
local rt = {1,9,7,4,5,6,3,8,2,10,23}
for i=1,#rt do
    if cards[i] ~= rt[i] then
        result = false
        break
    end
end
return result
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            lua:Dispose()--销毁对象释放资源
            return "cards里的数据不符合要求哦"
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
