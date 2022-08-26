using System;
using System.Linq;
using System.Reflection;

namespace AttributeConcept
{
    public class MySpecialAttribute : Attribute
    {
    }

    [MySpecial]
    public class SomeOtherClass:ISomeInterface
    {
        public  void Print()
        {
            Console.WriteLine("Hello from SomeOtherClass");
        }
    }


    public class SomeOtherClassWithoutMySpecailAttribute:ISomeInterface
    {
        public  void Print()
        {
            Console.WriteLine("Hello from SomeOtherClassWithoutMySpecailAttribute");
        }
    }

    interface ISomeInterface
    {
        void Print();
    }
    class MyClass
    {
        // get the class with MySpecial attribute
        public ISomeInterface GetClassWithAttribute()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(MySpecialAttribute), true).Length > 0)
                {
                    return (ISomeInterface)Activator.CreateInstance(type);

                }
            }
            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
          MyClass myClass = new MyClass();
            myClass.GetClassWithAttribute().Print(); // Print method of SomeOtherClass will be called as it has MySpecial attribute.

        }
    }
}
