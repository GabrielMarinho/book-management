using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BookManager.Application.Extensions;

public static class EnumExtension
{
    
    public static string GetDescription(this Enum value)
        => value?
               .GetType()
               .GetMember(value.ToString())
               .FirstOrDefault()
               ?.GetCustomAttribute<DescriptionAttribute>()
               ?.Description
           ?? value.ToString();

    public static string GetDisplayName(this Enum value)
        => value?
               .GetType()
               .GetMember(value.ToString())
               .FirstOrDefault()
               ?.GetCustomAttribute<DisplayAttribute>()
               ?.Name
           ?? value.ToString();
    
}