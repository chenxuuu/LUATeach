
title = "table小测试"
type = "写代码"
infomation = "检查下前几堂课的学习"
question = [[请新建一个名为`t`的`table`，满足以下要求

t[10]可获得`number`类型数据`100`

t.num可获得`number`类型数据`12`

t.abc[3]可获得`string`类型数据`abcd`

t.a.b.c可获得`number`类型数据`789`

]]
code = [[
--请补全代码
t = {

}
]]
explain = "看样子你已经理解了这部分内容了"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local ran = math.random(1, 9999)
    local r,i = pcall(function ()
        lua:DoString(s)
        local lr = lua:DoString([[
            return t[10] == 100 and
            t.num == 12 and
            type(t.abc) == 'table' and
            t.abc[3] == 'abcd' and
            type(t.a) == 'table' and
            type(t.a.b) == 'table' and
            t.a.b.c == 789
]])
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
