namespace SequenceLogic
{
    public enum StepStatus
    {
        AtStart,
        InProcess,
        AtEnd
    }

    public class Step<T>
    {
        /// <summary>
        /// The item correlating to the beginning of the step
        /// </summary>
        public T From { get; private set; }
    
        /// <summary>
        /// The item correlating to the end of the step
        /// </summary>
        public T To { get; private set; }
    
        /// <summary>
        /// The status of the step
        /// </summary>
        public StepStatus Status { get; set; }

        public Step(T from, T to)
        {
            From = from;
            To = to;
        }
    }
}