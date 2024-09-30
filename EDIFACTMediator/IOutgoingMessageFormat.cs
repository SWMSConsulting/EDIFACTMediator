using System.Reflection;

namespace SWMS.EDISolution.Module.MappingService;

public interface IOutgoingMessageFormat
{
    public IList<PropertyInfo> GetProperties(); 

}
