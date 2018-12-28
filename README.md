# unity_strangeioc_examples
AppRoot.cs框架入口


![MVCS结构图](https://raw.githubusercontent.com/11lin/unity_strangeioc_examples/master/Image/class-flow.png)

# 一、基本概念
StrangeIoC是一个超级轻量级且高度可扩展的Inversion-of-Control框架，专为C＃和Unity编写。

# 二、StrangeIOC基础类型
实际要理解一个框架的类型，还是要自己看源码，这里我只说一下几个重要类型的作用，这个看源码的时候有个印象，也方便理解，而且说这部分的帖子也很多，我就不再赘述了。

## 1.Context
上下文组件定义程序边界，也就是可以把一个程序定义成多上下文，让代码更加模块化 
它提供了程序入口，也算是框架中耦合度最高的地方

## 2.Binder和Binding
这两个类是这个框架最重要的组成部分 
Binding存储了对象的绑定关系，而Binder存储了Binding的对象

## 3.View和Mediator
MVCS中的View层，View只用于显示，也就是View只负责管理UI，Mediator负责界面逻辑，事件响应等

## 4.Model
MVCS中的Model层，负责数据部分

## 5.Command
MVCS中的Control层，负责执行逻辑代码

## 6.Service
MVCS中的Service层，负责与第三方交互，通讯消息等

## 7.Dispatcher
派发器是框架内通信主线的其中一种，用来派发消息，触发命令，从而进一步解耦

## 8.Signal
信号是框架内另外一种通信主线，它采用强类型，来绑定信号和命令之间的关系，实现消息响应的触发

## 9.ReflectionBinder
反射部分，通过binding来获取类的信息，存储在ReflectedClass中

## 10.injector
注入器,通过反射获取的信息，来实例化请求的对象

### [strangeioc github](http://strangeioc.github.io/strangeioc/)