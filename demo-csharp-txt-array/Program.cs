using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp_txt_array
{
    class Program
    {
        static void Main(string[] args)
        {
            //To read the text from defined file path
            TextReader inputFile = new StreamReader("c:\\test.txt");
            var rawData = inputFile.ReadToEnd();

            //To remove the unwanted data
            var dataString = rawData.Substring(rawData.LastIndexOf("cm\t\t\t\t\t\r\n")+2);

            //To define the place to separate the string into array and remove the nulled array elements
            string[] separators = { "\t", "\n", "\r"};
            var data1dArray = dataString.Split(separators, StringSplitOptions.RemoveEmptyEntries);            

            //To call method with a return of int array
            var colData1 = dataToGroup(data1dArray, 0, 6);
            var colData2 = dataToGroup(data1dArray, 2, 6);
            //To display and verify result
            for (int i = 0; i < colData1.Length; i++)
            {
                Console.WriteLine(colData1[i]);
            }

            Console.WriteLine("\n");

            for (int i = 0; i < colData2.Length; i++)
            {
                Console.WriteLine(colData2[i]);
            }

            //Wait for user input to close the console
            Console.Read();
        }

        //data is the input array
        //offset is to choose which column you want, e.g. 0 for first column, 5 for 6th column
        //totalCol is to define how many columns is there in the table
        private static int[] dataToGroup(string[] data, int offset, int totalCol)
        {
            var arrayLength = data.Length / totalCol;
            var result = new int[arrayLength];
            int pointer = 0;
            int convertedNum = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                pointer = offset + (i * totalCol);
                Int32.TryParse(data[pointer], out convertedNum);
                result[i] = convertedNum;
            }

            return result;
        }
    }
}
