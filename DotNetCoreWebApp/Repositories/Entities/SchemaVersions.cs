using System;
using System.Collections.Generic;

namespace DotNetCoreWebApp.Repositories.Entities
{
    public partial class SchemaVersions
    {
        public int Id { get; set; }
        public string ScriptName { get; set; }
        public DateTime Applied { get; set; }
    }
}
