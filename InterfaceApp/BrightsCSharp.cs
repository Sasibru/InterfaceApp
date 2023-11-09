using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApp
{
	public class BrightsCSharp : ICourse
	{
		private static List<string> _participantNames {  get; set; } = new List<string>();

		private int _courseYear {  get; set; }


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
			List<string> listWithYear = new() { GetCourseYear().ToString() };
			listWithYear.AddRange(_participantNames);
			return listWithYear;
		}

        public BrightsCSharp()
        {
            SetCourseYear();
        }

        public int GetCourseYear()
		{
			return _courseYear;
		}

		public void SetCourseYear(int? year = null)
		{
			_courseYear = year ?? DateTime.Now.Year;
		}

		public string CreatePath()
		{
			string projectDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(@"\bin") + 1);
			string pathDefault = projectDir + @"Participants.txt";
			return pathDefault;
		}

		public void WriteListToFile(List<string> participantList, string? path = null)
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
