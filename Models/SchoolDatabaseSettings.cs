using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class SchoolDatabaseSettings : ISchoolDatabaseSettings
    {
        public string StudentsCollectionName { get; set; }
        public string CoursesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

   
}