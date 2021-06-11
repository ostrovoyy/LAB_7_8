using System;

namespace mediator
{
    class Program
    {
        static void Main()
        {
            Context context = new Context(new LowDamage());
            Console.WriteLine(string.Format("Damage of District is {0}\n\n", context.State.MaxDamage));

            context.Request();
            Console.WriteLine(string.Format("Damage of District is {0}\n", context.State.MaxDamage));
        }
    }
    abstract class DistrictState
    {
        public int MaxDamage { get; protected set; }
        public abstract void ChangeState(Context context);
    }
    class HighDamage : DistrictState
    {
        public HighDamage()
        {
            MaxDamage = 150000;
        }
        public override void ChangeState(Context context)
        {
            context.State = new LowDamage();
            MaxDamage = 150000;
            Console.WriteLine("Now this district have low damage!");
        }
    }
    class LowDamage : DistrictState
    {
        public LowDamage()
        {
            MaxDamage = 70000;
        }
        public override void ChangeState(Context context)
        {
            context.State = new HighDamage();
            MaxDamage = 70000;
            Console.WriteLine("Now this district have high damage!");
        }
    }

    class Context
    {
        public DistrictState State { get; set; }
        public Context(DistrictState state)
        {
            this.State = state;
        }
        public void Request()
        {
            this.State.ChangeState(this);
        }
    }
}
