/*Problem 11. Version attribute
Apply the version attribute to a sample class and display its version at runtime.
 */
namespace DefiningClasses
{
    using System;
    class Sample
    {
        static void Main()
        {
            Type type = typeof(Sample);
            object[] attr = type.GetCustomAttributes(false);
            foreach (VersionAttribute item in attr)
            {
                Console.WriteLine(item.Version);
            }
        }
    }
}
