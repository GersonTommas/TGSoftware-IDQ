namespace IDQ.Domain.Base
{
    public class ModelBase : PropertyChangedBase
    {
        public int Id { get; set; }

        public virtual void updateModel() { }
    }
}
