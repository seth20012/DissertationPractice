using UnityEngine;

namespace _3DGuidance
{
    public class AudioGuide : MonoBehaviour
    {
        private AudioSource _source;
        private bool _isFound;

        /// <summary>
        /// Is the user gazing at the object
        /// </summary>
        public bool IsFound
        {
            get => _isFound;
            set
            {
                if (_isFound) return; // If previously found don't replay chime
                _isFound = value;
                Select();
            }
        }
        [SerializeField] AudioClip gazeSound;
        [SerializeField] AudioClip guideSound;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _source.clip = guideSound;
            _source.loop = true;
            _source.Play(); // Start 3D audio guidance
        
        }

        private void Select()
        {
            _source.Pause(); // Stop guidance
            _source.loop = false;
            _source.clip = gazeSound;
            _source.Play(); // Play the chime to notify user of correct gaze
        }
    }
}
