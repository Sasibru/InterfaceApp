using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApp
{
	public interface ICourse
	{
		void SignUpForCourse(string participantName);

		string GetCourseParticipantName(int participentIndex);

		List<string> GetCourseParticipantNames();
		void WriteListToFile(List<string> participantList, string? path);

		void ReadFromFileAndAddToList(string path);
	}
}
