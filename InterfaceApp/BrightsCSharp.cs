using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApp
{
	public class BrightsCSharp : ICourse
	{
		private List<string> _participantNames {  get; set; } = new List<string>();

		public string GetCourseParticipantName(int participentIndex) 
		{
            return _participantNames[participentIndex];
        }

		public void SignUpForCourse(string participantName) 
		{ 
			_participantNames.Add(participantName);
		}


		public List<string> GetCourseParticipantNames()
		{
			return _participantNames;
		}
	}
}
