namespace ConvarianceAndContravariance
{
    interface IProducer<out T>
    {
        T Producer();
    }

    interface ICustomer<in T>
    {
        void Customer(T obj);
    }
    public class Base
    {
        public void DoSomeThing()
        {
            Console.WriteLine($"Do Something in {this.GetType().Name}");
        }
    }

    public class Derived : Base
    {
        public void DoMore()
        {
            Console.WriteLine($"Do More in {this.GetType().Name}");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Base a = new Base();
            Base b =  new Derived();
            a.DoSomeThing();
            b.DoSomeThing();
            //b.Domore khong duoc vi Base khong co phuong thuc Domore
            Derived c =  new Derived();
            c.DoMore();

            
            IProducer < Base > proOfBase = null!;
            Base bp = proOfBase.Producer();

            IProducer<Derived> proOfDer = null!;
             Base bd = proOfDer.Producer();
            //Derived dp = proOfBase.Producer(); bien lop dan xuat khong khai bao kieu lop co so
            Derived dd = proOfDer.Producer();

            //Derived: Base implies IProducer<Derived>: IProducer<Base> also known as convariance

            ICustomer<Base> cusOfBase = null!;
            ICustomer<Derived> cusOfDer = null!;
            cusOfBase.Customer(new Base());
            cusOfDer.Customer(new Derived());
            cusOfBase.Customer(new Derived());
            //cusOfDer.Customer(new Base());

            //Derived: Base implies Icustomer<Derived>: Icustomer<Base> also known as contracvariace


        }
    }
}
