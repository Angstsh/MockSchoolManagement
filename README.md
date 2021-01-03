中间件
中间件可以同时处理 传入请求和传出响应。因此，中间件可以处理传入请求并将该请求传递给管道中的下一个中间件进行处理
终端中间件可以处理请求，并决定不调用管道中的下一个中间件，从而使管道短路
使用Run()方法注册的中间件是终端中间件，如果需要调用管道中的下一个中间件，应该注册Use()中间件

静态文件中间件
使用静态文件需要先添加静态文件中间件UseStaticFiles
支持访问默认文件UseDefaultFiles
UseDirectoryBrowser中间件，并允许用户查看指定目录中的文件
UseFileServer中间件结合了UseStaticFiles、UseDefaultFiles、UseDirectoryBrowser中间件的功能

开发人员异常页面
UseDeveloperExceptionPage中间件
环境变量IsDevelopment()、IsStaging()、IsProduction()

添加MVC
services.AddMvc(a=>a.EnableEndpointRouting=false);
app.UseMvcWithDefaultRoute();