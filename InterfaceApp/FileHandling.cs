using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceApp
{
	public class FileHandling
	{
		public bool CheckIfFileIsEmpty(string filePath)
		{
			if (File.Exists(filePath))
			{
				long fileLength = new FileInfo(filePath).Length;
                if (fileLength == 0)
                {
					return true;
                }
				else
				{
					return false;
				}
            }
			else
			{
                Console.WriteLine("File does not exist");
				return false;
			}
		}

		public void WriteToFile(List<string> participantList, string path, int year)
		{
			try
			{

				using (StreamWriter streamWriter = new(path, false, Encoding.Unicode))
				{
					if (CheckIfFileIsEmpty(path))
					{
						streamWriter.WriteLine(year);
					}
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

		/*
		public void ReadFromFile(string path, BrightsCSharp brightsCSharp, int year)
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

		*/
		public List<string> ReadFromFileWithReturn(string path, int year)
		{
			List<string> participants = new();

			try
			{
				string? text;
				using (StreamReader streamReader = new(path, Encoding.Unicode))
				{
					if (CheckIfFileIsEmpty(path))
					{
						participants.Add(year.ToString());
					}
					else if(!(streamReader.ReadLine().Contains(year.ToString())))
					{
						participants.Add(year.ToString());
					}
					while ((text = streamReader.ReadLine()) != null)
					{
						participants.Add(text);
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
			return participants;
		}
	}
}
