// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEditor;

namespace RCFramework.Core
{
    public static class CreateScriptTemplates
    {
        [MenuItem("Assets/Create/RC Framework/Bootstrapper", priority = 0)]
        public static void CreateBootstrapperMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewBootstrapper.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewBootstrapper.cs");
        }

        [MenuItem("Assets/Create/RC Framework/Command", priority = 0)]
        public static void CreateCommandMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewCommand.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewCommand.cs");
        }

        [MenuItem("Assets/Create/RC Framework/Controller", priority = 0)]
        public static void CreateViewControllerMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewController.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewController.cs");
        }

        [MenuItem("Assets/Create/RC Framework/Model", priority = 0)]
        public static void CreateModelMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewModel.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewModel.cs");
        }

        [MenuItem("Assets/Create/RC Framework/System", priority = 0)]
        public static void CreateSystemMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewSystem.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewSystem.cs");
        }

        [MenuItem("Assets/Create/RC Framework/Utility", priority = 0)]
        public static void CreateUtilityMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewUtility.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewUtility.cs");
        }

        [MenuItem("Assets/Create/Script Templates/Class", priority = 0)]
        public static void CreateClassMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewClass.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewClassScript.cs");
        }

        [MenuItem("Assets/Create/Script Templates/Interface", priority = 0)]
        public static void CreateInterfaceMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewInterface.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewInterfaceScript.cs");
        }

        [MenuItem("Assets/Create/Script Templates/MonoBehaviour", priority = 0)]
        public static void CreateMonoBehaviourMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewMonoBehaviour.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewBehaviourScript.cs");
        }

        [MenuItem("Assets/Create/Script Templates/ScriptableObject", priority = 0)]
        public static void CreateScriptableObjectMenuItem()
        {
            string templatePath = "Assets/RCFramework/Core/Editor/ScriptTemplates/Templates/NewScriptableObject.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScriptableObjectScript.cs");
        }
    }
}