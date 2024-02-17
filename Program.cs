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
            string tagName = args[1];

            try
            {
                // Read the CSProj file and extract the tag value
                string tagValue = ReadTagValue(csprojFilePath, tagName);

                // Output the result
                Console.WriteLine($"{tagValue}");
            }
            catch (Exception)
            {
                Console.WriteLine("");
                Environment.Exit(1);
            }
        }

        static string? ReadTagValue(string csprojFilePath, string tagName)
        {
            // Load the CSProj file
            XmlDocument doc = new XmlDocument();
            doc.Load(csprojFilePath);

            // Find the specified tag in the CSProj file
            XmlNodeList nodes = doc.GetElementsByTagName(tagName);

            // Check if the tag exists
            if (nodes.Count == 0)
            {
                return null;
            }

            // Get the value of the tag
            string tagValue = nodes[0].InnerText;

            return tagValue;
        }
    }
}
