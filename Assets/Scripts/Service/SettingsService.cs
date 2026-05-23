namespace Service
{
    public class SettingsService
    {
        public class VolumeSettings
        {
            public float Master { get; set; } = 1f;
            public float Music { get; set; } = 1f;
            public float SFX { get; set; } = 1f;
        }
        
        public class InputSettings
        {
            public float MouseSensitivity { get; set; } = 70f;
        }

        public VolumeSettings Volume = new();
        public InputSettings Input = new();

    }
}