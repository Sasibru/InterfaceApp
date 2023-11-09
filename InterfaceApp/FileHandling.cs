using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApp
{
	public class FileHandling
	{
		public void WriteToFile(List<string> participantList, string path)
		{

			try
			{
				using (StreamWriter streamWriter = new(path, false, Encoding.Unicode))
				{
					foreach (string participant in participantList)
					{
						streamWriter.WriteLine(participant);
					}

				}
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine($"You do not have authorization to this path. " + e.Message);
			}
			catch (DirectoryNotFoundException e)
			{
				Console.WriteLine("Can not find the directory. " + e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Could not perform operation. " + e.Message);
			}
		}

		public void ReadFromFile(string path, BrightsCSharp brightsCSharp)
		{
			try
			{
				string? text;
				using (StreamReader streamReader = new(path, Encoding.Unicode))
				{

					while ((text = streamReader.ReadLine()) != null)
					{
						brightsCSharp.SignUpForCourse(text);
					}
				}
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("File could not be found. " + e.Message);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine("The argument is not valid. " + e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Could not perform operation." + e.Message);
			}

		}
	}
}
