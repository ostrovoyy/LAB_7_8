using System;

namespace lr13
{
    class Program
    {
        static void Main()
        {
            Context context = new Context(new SlowTrain());
            Console.WriteLine(string.Format("Trains speed is {0}\n\n", context.State.MaxSpeed));

            context.Request();
            Console.WriteLine(string.Format("Trains speed is {0}\n", context.State.MaxSpeed));

            context.Request();
            Console.WriteLine(string.Format("Trains speed is {0}", context.State.MaxSpeed));
        }
    }
    abstract class TrainState
    {
        public int MaxSpeed { get; protected set; }
        public abstract void ChangeState(Context context);
    }
    class FastTrain : TrainState
    {
        public FastTrain()
        {
            MaxSpeed = 150;
        }
        public override void ChangeState(Context context)
        {
            context.State = new SlowTrain();
            MaxSpeed = 150;
            Console.WriteLine("Now it is slow train");
        }
    }
    class SlowTrain : TrainState
    {
        public SlowTrain()
        {
            MaxSpeed = 70;
        }
        public override void ChangeState(Context context)
        {
            context.State = new FastTrain();
            MaxSpeed = 70;
            Console.WriteLine("Now it is fast train");
        }
    }

    class Context
    {
        public TrainState State { get; set; }
        public Context(TrainState state)
        {
            this.State = state;
        }
        public void Request()
        {
            this.State.ChangeState(this);
        }
    }
}
