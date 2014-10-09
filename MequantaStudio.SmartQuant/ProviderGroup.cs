using System;
using MonoDevelop.Projects;

namespace MonoDevelop.SmartQuant
{
  public class ProviderGroup
  {
    public ProviderType ProviderType { get; private set; }

    public ProviderGroup(ProviderType type)
    {
      this.ProviderType = type;
    }
  }
}

