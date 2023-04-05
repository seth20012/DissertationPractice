using UnityEngine.Events;

namespace SequenceLogic
{
    public enum StepStatus
    {
        AtStart,
        InProcess,
        AtEnd
    }

    /// <summary>
    /// A task that instructs a user to move a physical object from one location to another
    /// </summary>
    /// <typeparam name="T">The type of the virtual objects that guide the user</typeparam>
    public class Step<T>
    {
        /// <summary>
        /// The virtual object indicating the starting location of the physical object
        /// </summary>
        public T From { get; }
    
        /// <summary>
        /// The virtual object indicating the finishing location of the physical object
        /// </summary>
        public T To { get; }
    
        /// <summary>
        /// The status of the step
        /// </summary>
        public StepStatus Status { get; set; }

        /// <summary>
        /// Subscribable event triggered when step starts
        /// </summary>
        public UnityEvent OnEntry = new UnityEvent();
        
        /// <summary>
        /// Subscribable event triggered when users begins moving the object
        /// </summary>
        public UnityEvent Operation = new UnityEvent();

        /// <summary>
        /// Subscribable event triggered when user has completed a step
        /// </summary>
        public UnityEvent OnExit = new UnityEvent();
        
        /// <summary>
        /// Step constructor
        /// </summary>
        /// <param name="from">Start object</param>
        /// <param name="to">Destination object</param>
        public Step(T from, T to)
        {
            From = from;
            To = to;
            
            OnEntry.AddListener(() => Status = StepStatus.InProcess); // Move to operational status after start
            Operation.AddListener(() => Status = StepStatus.AtEnd); // Move to end status after operation
        }
    }
}