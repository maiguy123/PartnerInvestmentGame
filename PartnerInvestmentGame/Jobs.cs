using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerInvestmentGame
{
    public enum JobOptions { Doctor, Developer, FryCook, Teacher, TrashMan, SalesPerson}
    
    public class Jobs
    {
        Dictionary<JobOptions, int> JobToSalary = new Dictionary<JobOptions, int>
        {
            {JobOptions.Doctor, 100000 },
            {JobOptions.Developer, 70000 },
            {JobOptions.FryCook, 30000 },
            {JobOptions.Teacher, 40000 },
            {JobOptions.TrashMan,  50000},
            {JobOptions.SalesPerson, 55000 },
        };

        public Jobs(JobOptions jobTitle)
        {
            JobTitle = jobTitle;
        }

        public JobOptions JobTitle { get; set; }
        public int Salary
        { get
            {
                return JobToSalary[JobTitle];
            } 
        }
    }
}
