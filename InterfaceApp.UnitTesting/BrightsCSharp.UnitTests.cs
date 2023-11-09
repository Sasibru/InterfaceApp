namespace InterfaceApp.UnitTesting
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void SignUpForCourse_AddTwoNewItems_ReturnCountOfList()
		{
			BrightsCSharp brightsCSharp = new();
			brightsCSharp.SignUpForCourse("Test1");
			brightsCSharp.SignUpForCourse("Test2");
			int actual = brightsCSharp.GetCourseParticipantNames().Count;

			int expected = 2;

			Assert.That(expected, Is.EqualTo(actual));

		}

		[Test]
		public void GetCourseParticipantName_AddAndViewItem_ReturnString()
		{
			BrightsCSharp brightsCSharp = new();
			brightsCSharp.SignUpForCourse("TestName");
			string actual = brightsCSharp.GetCourseParticipantName(0);

			string expected = "TestName";

			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void GetCourseParticipantNames_AddAndViewList_ReturnListCount()
		{
			BrightsCSharp brightsCSharp = new();
			brightsCSharp.SignUpForCourse("Test1");
			brightsCSharp.SignUpForCourse("Test2");
			brightsCSharp.SignUpForCourse("Test3");
			brightsCSharp.SignUpForCourse("Test4");
			List<string> actual = brightsCSharp.GetCourseParticipantNames();
	
			List<string> expected = new List<string> {"Test1", "Test2", "Test3", "Test4" };

			Assert.That(expected, Is.EqualTo(actual));
		}
	}
}