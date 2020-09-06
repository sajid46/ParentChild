namespace DependencyInjectionConsole
{
    class doProcess
    {
        Add add = new Add();
        IMultAdd multAdd;
        

    }

    internal class Process
    {
        public Process(IMultAdd multAdd)
        {
            multAdd.Process2(3,2);
        }
    }

    internal class Multiply: IMultAdd
    {
        public int Process2(int a, int b)
        {
            return a * b;
        }

    }

    internal class Add:IMultAdd
    {
        public int Process2(int a, int b)
        {
            return a + b;
        }
    }

    interface IMultAdd
    {
        int Process2(int a, int b);
    }
}