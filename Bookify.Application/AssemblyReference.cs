using System.Reflection;

namespace Bookify.Application;

internal class AssemblyReference
{
    public  static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
