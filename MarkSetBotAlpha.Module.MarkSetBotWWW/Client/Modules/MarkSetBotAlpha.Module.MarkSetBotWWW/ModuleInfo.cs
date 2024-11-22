using Oqtane.Models;
using Oqtane.Modules;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "MarkSetBotWWW",
            Description = "A MarkSetBotWWW Module",
            Version = "1.0.0",
            ServerManagerType = "MarkSetBotAlpha.Module.MarkSetBotWWW.Manager.MarkSetBotWWWManager, MarkSetBotAlpha.Module.MarkSetBotWWW.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "MarkSetBotAlpha.Module.MarkSetBotWWW.Shared.Oqtane",
            PackageName = "MarkSetBotAlpha.Module.MarkSetBotWWW" 
        };
    }
}
