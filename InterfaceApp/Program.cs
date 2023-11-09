namespace InterfaceApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BrightsCSharp brightsCSharp = new();
			brightsCSharp.SignUpForCourse("sander");
			brightsCSharp.SignUpForCourse("sander2");
			List<string> list = brightsCSharp.GetCourseParticipantNames();

			brightsCSharp.SaveListToFile(list);
		}
	}
}