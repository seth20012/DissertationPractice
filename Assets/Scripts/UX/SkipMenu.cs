using SequenceLogic;
using UnityEngine;

namespace UX
{
    /// <summary>
    /// UX controller for the skip menu
    /// </summary>
    public class SkipMenu : MonoBehaviour
    {
        [SerializeField] private MRTKInteractableSequenceInstance mrtkInteractableSequenceInstance;

        // Start is called before the first frame update
        void Start()
        {
            // Hide skip menu when a user finishes a task sequence
            mrtkInteractableSequenceInstance.OnSequenceInstanceEnded?.AddListener(() => gameObject.SetActive(false));
        }
    }
}
