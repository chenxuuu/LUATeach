--此处可测试你的lua脚本运行效果
--支持Lua5.3自带功能、以及LUAT Task任务相关接口
--同时支持XLua直接调用C#接口的功能

--新建任务，每休眠1000ms继续一次
sys.taskInit(function()
    while true do
        sys.wait(1000)--等待1000ms
        log.info("task wait",os.time())
    end
end)

--1000ms循环定时器
sys.timerLoopStart(log.info,1000,"timer test")

