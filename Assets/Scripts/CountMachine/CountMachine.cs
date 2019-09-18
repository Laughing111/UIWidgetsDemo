using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Icons = UIWidgetsSample.Icons;

public class CountMachine : UIWidgetsPanel
{
    protected override Widget createWidget()
    {
        //附带样式的Widgets组件库，FlutterApp框架，
        //通过它可以设置应用的名称，主题，语言，首页和路由列表等
        return new MaterialApp(
            //应用名称
            title:"Flutter Demo",
            //主题信息
            theme:new ThemeData(primarySwatch:Colors.blue),
            //应用首页的路由
            home:new MyHomePage(title:"Flutter Demo Home Page")
            );
    }
}


/// <summary>
/// 新路由页面
/// </summary>
public class NewRoute : StatelessWidget
{
    public override Widget build(BuildContext context)
    {
        return new Scaffold(
            appBar:new AppBar(title:new Text("NewRoute")),
            body:new Center(child:new Text("This is new route"))
        );
    }
}

//首页继承于StatefulWidget，表示它是一个有状态的组件，这些状态在widget生命周期中是可变的
//statefulWidget 至少有两部分组成：
//1.一个statefulWidget类
//2.一个State类 StatefulWidget类本身是不变的，但是State类中持有的状态在widget生命周期中，可能发生变化
//MyHomePageState类是MyHomePage类对应的状态类。
public class MyHomePage:StatefulWidget
{
    public string title;
    public MyHomePage(string title)
    {
       this.title = title;
    }
    public override State createState()
    {
        return new MyHomePageState();
    }
}

public class MyHomePageState : State<MyHomePage>
{
    private int _counter;   //用于记录按钮的点击总次数（保存点击次数的状态）

    private void _incrementCounter()  //设置状态的自增函数
    {
        setState(() => _counter++);   
        //setState方法的作用是通知Flutter框架，
        //有状态发生改变时，
        //Flutter框架收到通知后，会执行build方法，来根据新状态重新构建界面。
        //此处重新构建，Flutter进行了优化，是重新执行变得很快
    }
    
    public override Widget build(BuildContext context)
    {
        //scaffold是Material库中提供的页面脚手架，包含导航栏，标题，和Body以及各种按钮，路由推荐通过scaffold创建
        return new Scaffold(
            appBar:new AppBar(title:new Text(widget.title)),   //导航栏
            body:new Center(  //是一个Column组件
                child:new Column(  //作用是将其所有子组件沿屏幕的垂直方向依次排列
                    mainAxisAlignment:MainAxisAlignment.center,
                    children:new List<Widget>
                    {
                        new Text("You have pushed the button this many times"),
                        new Text(_counter.ToString(),style:Theme.of(context).textTheme.display1),
                        new FlatButton(
                            child:new Text("open new route"),
                            textColor:Colors.blue,
                            onPressed: () =>
                            {
                                Navigator.push(
                                    context,
                                    new MaterialPageRoute(
                                        (BuildContext buildContext) => { return new NewRoute();}
                                        )
                                    );
                            }
                        )
                    }
                  )
                ),
            floatingActionButton:new FloatingActionButton(
                onPressed:_incrementCounter,
                tooltip:"Increment",
                child:new Icon(Unity.UIWidgets.material.Icons.add)
               )
            );
    }
}
