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

		public string CreatePath()
		{
			string projectDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(@"\bin") + 1);
			string pathDefault = projectDir + @"Participants.txt";
			return pathDefault;
		}

		public void SaveListToFile(List<string> participantList, string? path = null)
		{
			string? pathCheck;
			if (path == null)
			{
				pathCheck = CreatePath();
			}
			else
			{
				pathCheck = path;
			}
			FileHandling fileHandling = new();
			fileHandling.WriteToFile(participantList, pathCheck);
		}
		public void ReadFromFileAndAddToList(string? path = null)
		{
			string? pathCheck;
			if (path == null)
			{
				pathCheck = CreatePath();
			}
			else
			{
				pathCheck = path;
			}
			FileHandling fileHandling = new();
			BrightsCSharp brightsCSharpInstance = new();
			fileHandling.ReadFromFile(pathCheck, this);
		}


	}
}
