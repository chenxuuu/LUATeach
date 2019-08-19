--函数返回值2

title = "判断三角形合法性2"
type = "写代码"
infomation = "三角形合法性判断问题2"
question = [[你需要使用前面几章的知识，来完成下面的题目

已知三个number类型的变量，分别代表三根木棒的长度

请判断，使用这三根木棒，是否可以组成一个三角形（两短边之和大于第三边）

请新建一个函数triangle，并可以用如下形式调用：

```lua
result = triangle(1,2,3)
```

如果可以组成，就返回true
]]

code = [[
function triangle(a,b,c)

end
]]
explain = "难度开始上升了哦"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    for n=1,20 do
        local a = math.random(1, 10)
        local b = math.random(1, 10)
        local c = math.random(1, 10)
        local r,i = pcall(function ()
            lua:DoString(s)
            local lr = lua:DoString("return triangle("..tostring(a)..","..tostring(b)..","..tostring(c)..")")
            return lr and lr[0]
        end)
        if r then
            if a+b>=c and b+c>=a and a+c>=b then
                if not i then
                    lua:Dispose()--销毁对象释放资源
                    return "当三边长度为"..tostring(a)..","..tostring(b)..","..tostring(c).."时，结果不对"
                end
            else
                if i then
                    lua:Dispose()--销毁对象释放资源
                    return "当三边长度为"..tostring(a)..","..tostring(b)..","..tostring(c).."时，结果不对"
                end
            end
        else
            lua:Dispose()--销毁对象释放资源
            return "代码报错啦，请检查是否有语法错误或运行时错误\r\n报错信息：\r\n"..i
        end
    end
    lua:Dispose()--销毁对象释放资源
    return ""
end
