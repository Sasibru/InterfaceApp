using System.Text;
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

			List<string> expected = new List<string> { "Test1", "Test2", "Test3", "Test4" };

			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void SaveToFile_AddNewParticipantsRenderToFile_ReturnListCount()
		{
			BrightsCSharp brightsCSharp = new();
			brightsCSharp.SignUpForCourse("sander");
			brightsCSharp.SignUpForCourse("sander2");
			List<string> list = brightsCSharp.GetCourseParticipantNames();

			brightsCSharp.WriteListToFile(list);
			int actual = brightsCSharp.GetCourseParticipantNames().Count;

			int expected = 2;

			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void ReadFromFileAndAddToListDynamic_AddParticipantsFromFile_ReturnListCount()
		{
			BrightsCSharp brightsCSharp = new();
			brightsCSharp.ReadFromFileAndAddToList();
			int actual = brightsCSharp.GetCourseParticipantNames().Count;

			int expected = 2;

			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void ReadFromFileAndAddToListHardTyped_AddParticipantsFromFile_ReturnListCount()
		{
			BrightsCSharp actual = new();
			string customFilePath = @"C:\Users\SanderSimonsenBrusta\source\repos\02C#Intermediate\Interface\Participants.txt";
			actual.ReadFromFileAndAddToList(customFilePath);

			BrightsCSharp expected = new(); 
			expected.ReadFromFileAndAddToList();

			List<string> actualParticipants = actual.GetCourseParticipantNames();
			List<string> expectedParticipants = expected.GetCourseParticipantNames();

			Assert.That(expectedParticipants.Count, Is.EqualTo(actualParticipants.Count));
			CollectionAssert.AreEqual(expectedParticipants, actualParticipants);
		}
	}
}