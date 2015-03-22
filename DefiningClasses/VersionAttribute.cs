/*Problem 11. Version attribute
Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
 */

namespace DefiningClasses
{
    class VersionAttribute
    {
        private string version;

        public string Version 
        {
            get { return this.version; }
            private set { this.version = value; }
        }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}
