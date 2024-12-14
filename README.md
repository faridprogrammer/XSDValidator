# XSD Validator

A simple command-line tool written in C# to validate XML files against an XSD schema. This tool is useful for ensuring that your XML documents conform to the expected structure defined in the XSD.

## Features

- Validates an XML file against an XSD schema.
- Provides detailed error messages if validation fails.
- Lightweight and easy to use.

## Requirements

- .NET SDK 6.0 or later (for building the project).

## How to Build

1. Clone this repository:
   ```bash
   git clone https://github.com/faridprogrammer/XSDValidator.git
   cd XSDValidator
   ```

2. Build the project using the .NET SDK:
   ```bash
   dotnet build -o output
   ```

   The compiled executable will be available in the `output` folder.

## How to Use

Run the executable with the following syntax:

```bash
XSDValidator.exe <XML_File_Path> <XSD_File_Path>
```

### Example

To validate an XML file (`example.xml`) against an XSD file (`example.xsd`), use:

```bash
XSDValidator.exe "C:\path\to\example.xml" "C:\path\to\example.xsd"
```

### Sample Output

#### If the XML is valid:
```
XML is valid.
```

#### If the XML is invalid:
```
Validation failed: The 'age' element is invalid - The value 'thirty' is not a valid integer.
```

#### If a file path is incorrect:
```
XML file not found: C:\path\to\example.xml
```
## Contact

For issues or feature requests, feel free to open an issue on GitHub or contact me at [faridbekran15@gmail.com].
