using UnityEngine;

public class settings_data : MonoBehaviour
{

    [System.Serializable]
    public class DalSettings
    {
        public bool Sound;
        public float Volume;
        public bool Annoying;
        public float NumberThatDoesntDoAnything;
        public float MinIdleTime;
        public float MaxIdleTime;
        public int Health;
    }
    private DalSettings stgs;
    //[SerializeField] private TextAsset jsontxt;

    public DalSettings get_settings(){
        stgs = JsonUtility.FromJson<DalSettings>(System.IO.File.ReadAllText("Assets/StreamingAssets/dal_settings.txt"));
        return stgs;
    }
}
