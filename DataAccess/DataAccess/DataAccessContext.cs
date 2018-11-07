using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DataAccessContext
    {
        private readonly string _sourceDirectory;

        public string GetSourcePath()
        {
            return _sourceDirectory;
        }
    }
}