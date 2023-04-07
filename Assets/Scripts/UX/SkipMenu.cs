using SequenceLogic;
using UnityEngine;
using UnityEngine.Serialization;

namespace UX
{
    /// <summary>
    /// UX controller for the skip menu
    /// </summary>
    public class SkipMenu : MonoBehaviour
    {
        [SerializeField] private ZoneStepSequenceInstance sequenceInstance;

        // Start is called before the first frame update
        void Start()
        {
            // Hide skip menu when a user finishes a task sequence
            sequenceInstance.OnSequenceInstanceEnded?.AddListener(() => gameObject.SetActive(false));
        }
    }
}
