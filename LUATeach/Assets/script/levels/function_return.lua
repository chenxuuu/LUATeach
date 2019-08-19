--函数返回值

title = "函数返回值"
type = "写代码"
infomation = "学习函数返回值的设定"
question = [[在前面的代码中，我们实现了一个函数，输入变量`a`、`b`，函数会自动输出两个数值的和。

但是一般来说，我们的需求远远不止这些，我们可能需要一个如下功能的函数：

`执行函数，输入两个值，获取这两个值的和`

如果还是按上面几节的内容，我们只会输出这个值，并不能把这个值传递给其他的变量进行后续使用，如何解决这个需求呢？

我们可以使用函数的返回值来实现这个需求，结合上面的需求，我们可以用下面的代码实现：

```lua
function add(a,b)
    return a+b
end
all = add(1,2)
--这里all的值就是3了
```

这里的`return`表示返回一个值，并且`立刻结束这个函数的运行`

同时，和输入值可以有多个一样，返回值也可以有多个

```lua
function add(a,b)
    return a+b,"ok"
end
all, result = add(1,2)
--这里all的值就是3了
--这里result的值就是string "ok"
```

下面问题来了，请设计一个函数`p`，可以按下面的调用方式来返回出物体的密度，返回值为number类型：

```lua
--一个长方体的长宽高分别为a、b、c（单位米）
a = 1
b = 2
c = 3
--这个物体重量为m（单位克）
m = 230
--下面返回密度值
--注：密度计算公式 密度 = 质量 / 体积
result = p(a,b,c,m)
```
]]

code = [[
function p(a,b,c,m)
    --请补全代码
end
]]
explain = "至此，你已经初步掌握了函数的使用方法，后面将进行多个测试"

check = function(s)
    local lua = CS.LUATeach.LuaEnv.LuaEnv.CreateLuaEnv()
    local result
    local r,i = pcall(function ()
        lua:DoString(s)
    end)
    return ""
end
