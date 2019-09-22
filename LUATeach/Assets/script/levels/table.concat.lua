
title = "table.concat"
type = "写代码"
infomation = "连接table"
question = [[table.concat (table [, sep [, i [, j ] ] ])

将元素是`string`或者`number`类型的`table`，每个元素连接起来变成字符串并返回。

可选参数`sep`，表示连接间隔符，默认为空。

`i`和`j`表示元素起始和结束的下标。

下面是例子：

```lua
local a = {1, 3, 5, "hello" }
print(table.concat(a))
print(table.concat(a, "|"))

-->打印的结果：
135hello
1|3|5|hello
```

请完成下面的任务：

已知`table`变量`t`，

将`t`中的结果全部连起来

间隔符使用`,`

并使用print打印出来
]]
code = [[
--请补全代码
--已知变量为t
--需要用print输出要求的结果
--一共1行
]]
explain = "这个函数主要是在连接一堆字符串时使用"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(5,10)
    local r,i = pcall(function ()
        lua:DoString([[t={}
for i=1,]]..tostring(ran)..[[ do
    table.insert(t,string.char(0x63+i))
end

allPrintData = {}
function print(...)
    arg = { ... }
    if #arg == 0 then table.insert(allPrintData,"nil") return end
    local logAll = {}
    for i=1,select("#", ...) do
        table.insert(logAll, tostring(arg[i]))
    end
    table.insert(allPrintData,table.concat(logAll, "\t"))
end
]])
        lua:DoString(s)
        local lr = lua:DoString([[t={}
for i=1,]]..tostring(ran)..[[ do
    table.insert(t,string.char(0x63+i))
end
check = table.concat(t, ",")
return table.concat(allPrintData, "\r\n") == check
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            local lc = lua:DoString([[return check]])[0]
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦，应输出\r\n"..lc.."\r\n但你输出的是\r\n"..lr
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
