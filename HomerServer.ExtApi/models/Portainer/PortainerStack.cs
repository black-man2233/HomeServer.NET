namespace HomerServer.ExtApi.models.Portainer;

public class PortainerStack
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long Type { get; set; }
    public long EndpointId { get; set; }
    public string SwarmId { get; set; } = string.Empty;
    public string EntryPoint { get; set; } = string.Empty;
    // public List<object> Env { get; set; } 
    public ResourceControl ResourceControl { get; set; } = new();
    public long Status { get; set; }
    public string ProjectPath { get; set; } = string.Empty;
    public long CreationDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public long UpdateDate { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public bool AdditionalFiles { get; set; }
    public bool AutoUpdate { get; set; }
    // public object Option { get; set; }
    // public object GitConfig { get; set; }
    public bool FromAppTemplate { get; set; }
    // public string Namespace { get; set; }
}

public class ResourceControl
{
    public long Id { get; set; }
    public string ResourceId { get; set; } = string.Empty;
    // public List<object> SubResourceIds { get; set; }
    public long Type { get; set; }
    // public List<object> UserAccesses { get; set; }
    // public List<object> TeamAccesses { get; set; }
    public bool Public { get; set; }
    public bool AdministratorsOnly { get; set; }
    public bool System { get; set; }
}
