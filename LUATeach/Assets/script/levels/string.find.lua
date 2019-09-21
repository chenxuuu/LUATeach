
title = "string.find"
type = "写代码"
infomation = "查找字符串内容"
question = [[string.find(s, p [, init [, plain] ])

这个函数会在字符串`s`中，寻找匹配`p`字符串的数据。如果成功找到，那么会返回`p`字符串在`s`字符串中出现的开始位置和结束位置；如果没找到，那么就返回`nil`。

第三个参数`init`默认为`1`，表示从第几个字符开始匹配，当`init`为负数时，表示从`s`字符串的倒数第`-init`个字符处开始匹配。

第四个参数`plain`默认为`false`，当其为`true`时，只会把`p`看成一个字符串对待。

=========

可能你会奇怪，第四个参数有什么存在的必要吗？`p`不是本来就应该是个字符串吗？

实际上，lua中的匹配默认意义是`正则匹配`，同时，这里的正则与其它语言也有些许不同。

由于篇幅有限，本节和下面的几节涉及匹配内容时，均不会考虑正则的使用方法，Lua正则教程将会在最后几节单独详细地列出来。

第四个参数为`true`时，便不会使用正则功能。

=========

示例代码：

```lua
--只会匹配到第一个
print(string.find("abc abc", "ab"))
-- 从索引为2的位置开始匹配字符串：ab
print(string.find("abc abc", "ab", 2))
-- 从索引为5的位置开始匹配字符串：ab
print(string.find("abc abc", "ab", -3))

-->输出
1  2
5  6
5  6
```

请完成下面的任务：

已知字符串`s`，里面有很多相同的字符串

请找出字符串`s`中，所有字符串`awsl`的位置

使用print打印结果，结果一行一个

如字符串`12awslawslaw`

打印结果：

```
3
7
```
]]
code = [[
--已知变量s
--需要用print输出要求的结果
]]
explain = "find可以快速找到指定字符串的位置"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(3,7)
    local ran2 = math.random(1,999)
    local r,i = pcall(function ()
        lua:DoString("s=string.rep('aaa',"..tostring(ran2)..")..string.rep('awsl123',"..tostring(ran)..[[)

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
        lua:DoString("s=string.rep('aaa',"..tostring(ran2)..")..string.rep('awsl123',"..tostring(ran)..")")
        local lr = lua:DoString([[
check = {}
local last = 1
while true do
    local l = s:find("awsl",last)
    if l then
        table.insert(check,tostring(l))
        last = l+1
    else
        break
    end
end

return table.concat(allPrintData, "\r\n") == table.concat(check, "\r\n")]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            local lr = lua:DoString([[return table.concat(allPrintData, "\r\n")]])[0]
            local lc = lua:DoString([[return table.concat(check, "\r\n")]])[0]
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
