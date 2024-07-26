namespace Project
{
    public enum Side
    {
        Right,
        Left
    }

    public interface IInput 
    {
        public Side Value { get; set; }

        public float Direction();
    }
}