using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBugTracker
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        private string project_name;
        private string description;


        public ProjectData() { }
        public ProjectData(string project_name)
        {
            this.project_name = project_name;
        }

        public string Project_name
        {
            get
            {
                if (project_name != null)
                {
                    return project_name;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                project_name = value;
            }
        }

        public string Description
        {
            get
            {
                if (description != null)
                {
                    return description;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                description = value;
            }
        }

        public int CompareTo(ProjectData other)
        {
            
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Project_name.CompareTo(other.Project_name) == 0)
            {
                return (Description.CompareTo(other.Description));
            }
            else { return Project_name.CompareTo(other.Project_name); }
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ((Description == other.Description) && (Project_name == other.Project_name));
        }
    }
}