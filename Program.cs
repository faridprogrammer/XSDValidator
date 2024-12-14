using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace XSDValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: XSDValidator.exe <XML_File_Path> <XSD_File_Path>");
                return;
            }

            string xmlPath = args[0];
            string xsdPath = args[1];

            try
            {
                if (!File.Exists(xmlPath))
                {
                    throw new FileNotFoundException($"XML file not found: {xmlPath}");
                }

                if (!File.Exists(xsdPath))
                {
                    throw new FileNotFoundException($"XSD file not found: {xsdPath}");
                }

                ValidateXml(xmlPath, xsdPath);
                Console.WriteLine("XML is valid.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation failed: {ex.Message}");
            }
        }

        static void ValidateXml(string xmlPath, string xsdPath)
        {
            // Load the XSD schema
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, xsdPath);

            // Set up the validation settings
            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                Schemas = schemaSet
            };

            // Event handler for validation errors
            settings.ValidationEventHandler += ValidationEventHandler;

            // Create an XmlReader for validation
            using (XmlReader reader = XmlReader.Create(xmlPath, settings))
            {
                // Read through the XML document
                while (reader.Read()) { }
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            // Throw an exception if the XML is invalid
            if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
