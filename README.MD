
# ASP.NET Core 3框架揭秘(上册)

![BookCover](https://images.cnblogs.com/cnblogs_com/artech/158198/o_201026055319asp-net-core-3.jpg)

## 第1章 全新的开发体验

## 第2章 跨平台的奥秘

## 第3章 依赖注入(上篇)

DI: Dependence Injection  
IoC: Inverse of Control  

IoC是一种框架设计的思想或原则：将一组通用的流程控制权从应用转移到框架中，以实现对流程的复用，并按照好莱坞法则实现应用程序的代码与框架之间的交互。DI则是IoC的一种模式体现。  
[Injection]:构造器注入，属性注入，方法注入  

Service Locator不是DI。
Service Locator依靠属性或方法拉取所需服务，模糊且不可靠
DI通过构造器注入所需服务，依赖明确  
