using System.Reflection;

namespace Bookify.Infrastructure;

internal static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
