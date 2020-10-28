using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;
using System.CodeDom;
using TMPro;


//这个例子的功能：每N秒进行一个固定的行为功能（打印信息）
//事件的拥有者:类---->customer 
//事件:event关键字修饰---->OnOrder 
//事件响应者:类---->Waiter 
//事件处理器:方法-受到约束的方法---->TakeAction 
//事件的订阅关系 +=


//public delegate void OrderEventHandler(Customer _customer,OrderEventArgs _e);//为了声明[Onorder事件]所使用的委托
//也可以直接只用eventhandler

public class EventNew : MonoBehaviour
{
    //Timer timer = new Timer();

    //public static int counter = 0;
    //public static string displayString = "This stirng will loop th length";
    //private void Start()
    //{
    //    //简略订阅的格式
    //    //timer.Elapsed += Printer.MyAction;//Printer类的事件处理器：MyAction订阅了由timer为主体的[ELAPSED事件]
    //    //完整订阅的格式
    //    timer.Elapsed += new ElapsedEventHandler(Printer.MyAction);
    //    //timer.Elapsed += otherClass.otherA;
    //    timer.Interval = 1000;//1000ms=1s

    //    timer.Start();

    //}

    //public class Printer //事件的拥有者一定是一个类
    //{
    //    internal static void MyAction(object sender, ElapsedEventArgs e)
    //    {
    //        Debug.Log(counter++%displayString.Length);
    //    }
    //}
    Customer customer = new Customer();
    Waiter waiter = new Waiter();
    private void Start()
    {
        customer.OnOrder += waiter.TakeAction;
        customer.Order("Mocha","Grand",32);//事件拥有者的内部逻辑，触发的事件

        customer.PayTheBill();
    }
}
public class Customer
{
        public float Bill { get; set; }
        public void PayTheBill()
        {
            Debug.Log("I have to pay:" + this.Bill);
        }
    //[完整声明格式]
    //private OrderEventHandler orderEventHandler;//委托类型的字段，未来会去储存，引用那些服务员的事件处理器
    //public event OrderEventHandler OnOrder//声明事件，并用委托类型约束
    //{
    //    add
    //    {
    //        orderEventHandler += value;//添加事件处理器
    //    }
    //    remove
    //    {
    //        orderEventHandler -= value;//移除事件处理器
    //    }
    //}

    //[简略声明格式]
    public event /*Order*/EventHandler OnOrder;
    public void Order(string _name,string _size,float _price)
    {
        if(/*orderEventHandler*/OnOrder != null)//判断事件是否为空
        {
            OrderEventArgs e = new OrderEventArgs();
            e.CoffeeName = _name;
            e.CoffeeSize = _size;
            e.CoffeePrice = _price;
            /*orderEventHandler*/
            OnOrder(this, e);
        }
    }
}

public class OrderEventArgs:EventArgs//如果某个类是作为EventArgs类来使用的话，就应该派生自EventArgs这个类型
{
    public string CoffeeName { get; set; }
    public string CoffeeSize { get; set; }
    public float CoffeePrice { get; set; } 
}

public class Waiter
{
    //internal void TakeAction(Customer _customer, OrderEventArgs _e)
    //{
    //    float finalprice = 0;

    //    switch(_e.CoffeePrice)
    //    {
    //        case "Tall":
    //            finalprice = _e.CoffeePrice;
    //            break;
    //        case "Grande":
    //            finalprice = _e.CoffeePrice+3;
    //            break;
    //        case "Venti":
    //            finalprice = _e.CoffeePrice+6;
    //            break;
    //    }
    //    _customer.Bill += finalprice;
    //}
    internal void TakeAction(object _sender, EventArgs _ea)
    {
        float finalprice = 0;

        Customer customer = _sender as Customer;

        OrderEventArgs e = _ea as OrderEventArgs;
        switch (e.CoffeePrice)
        {
            case 'A':
                finalprice = e.CoffeePrice;
                break;
            case 'B':
                finalprice = e.CoffeePrice + 3;
                break;
            case 'C':
                finalprice = e.CoffeePrice + 6;
                break;
        }
        customer.Bill += finalprice;
    }
}
