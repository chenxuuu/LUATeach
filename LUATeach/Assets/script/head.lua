--提前运行的脚本
--用于提前声明某些要用到的函数

--加强随机数随机性
math.randomseed(tostring(os.time()):reverse():sub(1, 6))

--防止跑死循环，超时设置秒数自动结束，-1表示禁用
runMaxSeconds = runType == "send" and 3 or -1
local start = os.time()
function trace (event, line)
    if runMaxSeconds > 0 and os.time() - start >=runMaxSeconds then
        error("代码运行超时")
    end
end
debug.sethook(trace, "l")

--加上需要require的路径
local rootPath = apiUtf8ToHex(apiGetPath())
rootPath = rootPath:gsub("[%s%p]", ""):upper()
rootPath = rootPath:gsub("%x%x", function(c)
                                    return string.char(tonumber(c, 16))
                                end)
package.path = package.path..
";"..rootPath.."?.lua"..
";"..rootPath.."require/?.lua"..
";"..rootPath.."requires/?.lua"

--重载几个可能影响中文目录的函数
local oldrequire = require
require = function (s)
    local s = apiUtf8ToHex(s):fromHex()
    return oldrequire(s)
end
local oldloadfile = loadfile
loadfile = function (s)
    local s = apiUtf8ToHex(s):fromHex()
    return oldloadfile(s)
end
local oldioopen = io.open
io.open = function (s,p)
    local s = apiUtf8ToHex(s):fromHex()
    return oldioopen(s,p)
end

--重写print函数
function print(...)
    arg = { ... }
    local logAll = {}
    for i=1,select('#', ...) do
        table.insert(logAll, tostring(arg[i]))
    end
    apiPrintLog(table.concat(logAll, "\t"))
end









