using Assets.Scripts.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MainBuilding : MonoBehaviour,
        IUnitProducer, ISelectable
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        [SerializeField] private Shader _outlineShader;

        [SerializeField] private Color _outlineColor = Color.white;

        [SerializeField, Range(0f, 10f)] private float _outlineWidth = 2f;

        [SerializeField] private Material _material;
        
        [SerializeField] private Camera _outlineCamera;

        private float _health = 500;

        private RenderTexture _source;
        private RenderTexture _destination;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public Color OutlineColor => _outlineColor;

        public float OutlineWidth => _outlineWidth;

        public Material ShaderMaterial => _material;
        
        private float far = 11;

        private void Awake()
        {
            _outlineCamera.CopyFrom(Camera.main);
            _outlineCamera.farClipPlane = far;
            _outlineCamera.clearFlags = CameraClearFlags.Color;
            _outlineCamera.backgroundColor = Color.black;
            _outlineCamera.cullingMask = 1 << LayerMask.NameToLayer ("Outline");
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10),
                0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }


        public void HighlightUnit()
        {
            Debug.Log("Highlited");
            {
                if (_material != null && _outlineShader != null)
                {
                    RenderTexture rt = RenderTexture.GetTemporary(_source.width, _source.height, 0);
                    rt.Create();
                    RenderTexture rawRt = _outlineCamera.targetTexture;
                    _outlineCamera.targetTexture = rt;
                    _outlineCamera.RenderWithShader(_outlineShader, "");
                    _material.SetTexture("_SceneTex", _source);
                    _material.SetColor("_Color", _outlineColor);
                   _material.SetFloat("_Width", _outlineWidth);

                    Graphics.Blit(rt, _destination, _material, 0);
                    _outlineCamera.targetTexture = rawRt;
                    rt.Release();
                    rt = null;
                }
                else
                {
                    Graphics.Blit(_source, _destination);
                }
                
            }
        }
    }
}

