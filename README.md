DbEntry With Asp.Net MVC
==========

简介
----------

[DbEntry.Net](https://github.com/Lifeng-Liang/DbEntry) 在配合 Asp.Net MVC 的时候，有一个问题，就是对于想把字段值改为缺省值（比如long型字段，数据库中是5，想要改成0），会失效。

这是因为 DbEntry 的“部分更新”功能，会忽略未修改的字段，而 Asp.Net MVC 的缺省的 ModelBinder 在创建 Edit 页面的对象时并不是先从数据库读取，而是直接创建对象，这样，本来就是缺省值，再改成缺省值，DbEntry 会认为没有改动，所以不会执行这个字段的更新。

以前， 曾经提供过一个编译时配置 AddCompareToSetProperty 来解决这个问题，在 Leafing.Processor.exe.config 中使用这个配置的话，可以禁用 DbEntry 的部分更新功能，从而达到修改成缺省值的目的。

不过这毕竟不是一个好的解决方案，所以现在提供这样一个例子，让 Asp.Net MVC 在使用 DbEntry 的时候也可以使用部分更新功能。

用法
----------

复制 DbEntryWithAspNetMvc 目录下的 DbEntryModelBinder.cs 文件到你的 MVC Application 目录下，在 Global.asax.cs 文件中的 Application_Start 函数中新增一句代码：

````c#
DbEntryModelBinderHelper.Init();
````

其他
----------

这个项目，是一个完整的 Asp.Net MVC 4 的项目，可以运行，配置成了使用 SQLite 1.0.66.0，你可以自行下载它的驱动程序，并复制的 bin 目录即可。或者你也可以修改配置文件，把它改成 DbEntry 支持的其它数据库。

之所以没有把 DbEntryModelBinder 加入 DbEntry 中，而是提供这样一个例子，在于不想编译太多针对不同版本的 Asp.Net MVC 的 DLL。

Usage
----------

Copy DbEntryModelBinder.cs in DbEntryWithAspNetMvc folder to your MVC Application folder. Add following code to your Application_Start function in Global.asax.cs :

````c#
DbEntryModelBinderHelper.Init();
````

