
title = "table删减"
type = "写代码"
infomation = "删减table元素"
question = [[`table.insert (table, [pos ,] value)`

在（数组型）表 table 的 pos 索引位置插入 value，其它元素向后移动到空的地方。pos 的默认值是表的长度加一，即默认是插在表的最后。

`table.remove (table [, pos])`

在表 table 中删除索引为 pos（pos 只能是 number 型）的元素，并返回这个被删除的元素，它后面所有元素的索引值都会减一。pos 的默认值是表的长度，即默认是删除表的最后一个元素。

下面是例子：

```lua
local a = {1, 8}             --a[1] = 1,a[2] = 8
table.insert(a, 1, 3)   --在表索引为1处插入3
print(a[1], a[2], a[3])
table.insert(a, 10)    --在表的最后插入10
print(a[1], a[2], a[3], a[4])

-->打印的结果：
3    1    8
3    1    8    10
```

```lua
local a = { 1, 2, 3, 4}
print(table.remove(a, 1)) --删除速索引为1的元素
print(a[1], a[2], a[3], a[4])

print(table.remove(a))   --删除最后一个元素
print(a[1], a[2], a[3], a[4])

-->打印的结果：
1
2    3    4    nil
4
2    3    nil    nil
```

请完成下面的任务：

已知`table`变量`t`，

去除`t`中的第一个元素

然后这时，在t的第三个元素前，加上一个`number`变量，值为`810`
]]
code = [[
--请补全代码
--已知变量为t
--需要更改这个t的值
]]
explain = "table十分灵活"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local r,i = pcall(function ()
        lua:DoString([[t={1,2,3,4,5}
]])
        lua:DoString(s)
        local lr = lua:DoString([[t={}
check = true
r = {2,3,810,4,5}
for i=1,#t do
    if t[i] ~= r[i] then
        check = false
        break
    end
end
return check
]])
        return lr and lr[0]
    end)
    if r then
        if not i then
            lua:Dispose()--销毁对象释放资源
            return "结果不符合要求哦"
        end
    else
        lua:Dispose()--销毁对象释放资源
        return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..
        (i:match("c# exception:XLua.LuaException: (.-)\r\n") or i)
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
