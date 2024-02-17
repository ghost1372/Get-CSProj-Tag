using System.Xml;

namespace Get_CSProj_Tag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Check if the correct number of arguments are provided
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Get-CSProj-Tag.exe <CSProjFilePath> <TagName>");
                Environment.Exit(1);
            }

            // Extract command-line arguments
            string csprojFilePath = args[0];
            string[] tags = args[1].Split('|');

            try
            {
                // Read the CSProj file and extract the tag value
                var tagValues = ReadTagValues(csprojFilePath, tags);

                // Output the result
                for (int i = 0; i < tags.Length; i++)
                {
                    Console.WriteLine($"{tagValues[i]}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
                Environment.Exit(1);
            }
        }

        static string[]? ReadTagValues(string csprojFilePath, string[] tags)
        {
            // Load the CSProj file
            XmlDocument doc = new XmlDocument();
            doc.Load(csprojFilePath);

            // Initialize an array to store tag values
            string[] tagValues = new string[tags.Length];

            // Loop through each tag and extract its value
            for (int i = 0; i < tags.Length; i++)
            {
                // Find the specified tag in the CSProj file
                XmlNodeList nodes = doc.GetElementsByTagName(tags[i]);

                // Check if the tag exists
                if (nodes.Count == 0)
                {
                    return null;
                }

                // Get the value of the tag
                tagValues[i] = nodes[0].InnerText;
            }

            return tagValues;
        }
    }
}
