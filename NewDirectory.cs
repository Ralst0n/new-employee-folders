using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace newResumefolder
{
    class NewDirectory
    {
        public NewDirectory(string firstName, string lastName, string location, string employeeNumber = "")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.location = location;
            this.employeeNumber = employeeNumber;
            if (location == "Pittsburgh")
                employeePath = @"P:\012 - EMPLOYMENT\PERSONNEL FILE\ACTIVE EMPLOYEES\PGH\";
            else
                employeePath = @"P:\012 - EMPLOYMENT\PERSONNEL FILE\ACTIVE EMPLOYEES\KOP\";
        }

        private string firstName;
        private string lastName;
        private string location;
        private string employeeNumber;
        private string resumePath =  @"P:\012 - EMPLOYMENT\RESUMES\Resumes\";
        private string employeePath;

       private bool CreatePersonnel()
        {
            string[] subfolders = new string[] { "Certifications", "Correspondence", "Emergency Contact", "New Hire Documents", "Status Change", "Wage Acknowledgement" };
            bool changes = false;
            string personnelFolder = $"{lastName.ToUpper()}, {firstName.ToUpper()}";
            if (!Directory.Exists(employeePath + personnelFolder))
                Directory.CreateDirectory(employeePath + personnelFolder);

            foreach (string folder in subfolders)
            {
                //if the employee folder is missing one of the subfolders, then add it.
                Console.WriteLine(employeePath + personnelFolder + @"\" + folder);
                if (!Directory.Exists(employeePath + personnelFolder + @"\" + folder))
                {
                    Directory.CreateDirectory(employeePath + personnelFolder + @"\" + folder);
                    changes = true;
                }
            }
            return changes;

        }

        private bool CreateResume()
        {
            string[] subfolders = new string[] { "Current Certifications", "Expired Certifications", "Support Documentation"};
            string resumeFolder = $"{ProperName(lastName)}-{ProperName(firstName)} {employeeNumber}";
            bool changes = false;
            if (!Directory.Exists(resumePath + resumeFolder)) 
                Directory.CreateDirectory(resumePath + resumeFolder);
            foreach (string folder in subfolders)
            {
                if(!Directory.Exists(resumePath + resumeFolder + @"\" + folder))
                {
                    Directory.CreateDirectory(resumePath + resumeFolder + @"\" + folder);
                    changes = true;
                }
            }
            return changes;
        }

        public bool CreateDirectories()
        {
            bool changes = false;
            if (CreateResume())
                changes = true;
            if (CreatePersonnel())
                changes = true;
            return changes;
        }
        private string ProperName(string name)
        {
            return name.First().ToString().ToUpper() + name.Substring(1);
        }
    }
}
