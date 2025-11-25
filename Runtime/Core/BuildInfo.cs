
using qb.Pattern;
using TriInspector;
using UnityEngine;

#if UNITY_EDITOR
using System;
using UnityEditor;
using System.IO;
using System.Threading.Tasks;
#endif

namespace qb.EnvironmentBuild
{
    [CreateAssetMenu(fileName = "buildInfo", menuName = "qb/Environement/buildInfo", order = 1)]
    public class BuildInfo : SOSingleton<BuildInfo>
    {
        public enum EnvironmentType { Development, Stage, Production, PreProduction }
/*
#if UNITY_EDITOR
        [OnValueChanged(nameof(UpdateApplicationExtension))]
#endif
*/
        [SerializeField] 
        private EnvironmentType environment = EnvironmentType.Development;
        public EnvironmentType Environment=> environment;
        
        public string Version => Application.version;

        [SerializeField,ReadOnly]
        private string buildNumber = "1";
        public string BuildNumber
        {
            get=> buildNumber;
#if UNITY_EDITOR
            set
            {
                if (Application.isPlaying)
                    throw new Exception("This parameter cannot be set at runtime!");
               
                buildNumber = value;
            }
#endif
        }
        
        [SerializeField, ReadOnly]
        private string date;
        public string Date=> date;
        
        public const string ProfileName = "RemoteAssets";
        public override string ToString()
        {
            return $"{environment} - {Version}.{buildNumber} - {date}";
        }

#if UNITY_EDITOR
        async public Task GenerateBuildNumber()
        {
            DateTime now = DateTime.UtcNow;
            string buildNumber = now.ToString("yyMMddHHmm").Substring(1);
            BuildNumber = buildNumber;
            SetDate(now);
            AssetDatabase.SaveAssets();
            //wait for assetDatabase to save
            await Task.Yield();
            await Task.Delay(100);
        }
        
        public void SetDate(DateTime dateTime)
        {
            if (Application.isPlaying)
                throw new Exception("This method cannot be set at runtime!");
            date = dateTime.ToString("duration/MM/yy HH:mm:ss");
        }
        string ApplicationExtensionCode => "namespace qb\r\n{\r\n    "+
                                           "public static class BuildEnvironment\r\n    {\r\n        "+
                                           $"public static buildInfo.EnvironmentType Environment => buildInfo.EnvironmentType.{environment.ToString()};"+
                                           "\r\n    }\r\n}";

        public void SetEnvironment(EnvironmentType environmentType)
        {
            if (Application.isPlaying)
                throw new Exception("This method cannot be set at runtime!");
            environment = environmentType;
            
        }

      
        public static bool GetClassAssetInfo(string className, out string fileName, out string dirPath, out string guid)
        {
            guid = "";
            dirPath = Application.dataPath;
            fileName = $"{className}.customEase";
            var guids = AssetDatabase.FindAssets($"t:Script {className}");
            if (guids != null && guids.Length > 0)
            {
                foreach (var entry in guids)
                {
                    var completePath = AssetDatabase.GUIDToAssetPath(entry);
                    if (Path.GetFileName(completePath) == fileName)
                    {
                        guid = entry;
                        dirPath = completePath.Replace(fileName, "");
                        return true;
                    }
                }
            }
            return false;
        }
#endif       
    }
}
