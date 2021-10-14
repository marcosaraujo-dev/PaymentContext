namespace PaymentContext.Domain.ValueObjects
{
    public class Active
    {
        public Active(bool active)
        {
            Activated = active;
        }
        public bool Activated { get; private set; }


        public void Activate(bool active)
        {
            Activated = active;
        }
    }
}