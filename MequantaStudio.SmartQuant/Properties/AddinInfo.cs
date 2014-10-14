using Mono.Addins;

[assembly:Addin("SmartQuant", Namespace = "MequantaStudio", Version = "1.0")]
[assembly:AddinDependency("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency("::MonoDevelop.DesignerSupport", MonoDevelop.BuildInfo.Version)]
