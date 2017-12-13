# MarkdownDocNet 

[![Build Status](https://travis-ci.org/LukasBoersma/MarkdownDocNet.svg?branch=master)](https://travis-ci.org/LukasBoersma/MarkdownDocNet)

*MarkdownDocNet* is a small command-line tool that creates API reference documents for .NET projects.

It transforms [.NET XML documentation files](https://msdn.microsoft.com/en-us/library/aa288481.aspx) into minimalistic Markdown documents.
I recommend to use this tool to generate the "API reference" part of your documentation, and write the rest of your documentation by hand in separate Markdown files.

Here is a **[live demo](https://fastcgi-for-net.readthedocs.org/en/latest/api_reference/)** of a documentation generated with MarkdownDocNet.

MarkdownDocNet integrates well with [MkDocs](http://www.mkdocs.org/) and [ReadTheDocs](https://readthedocs.org).

## Usage

To create a documentation file, simply execute:

    MarkdownDocNet.exe <documentation.xml> <assembly.dll> <output.md>

* **documentation.xml** is the .NET XML documentation file.
* **assembly.dll** is the Assembly filename that corresponds to the given documentation file name.
* **output.md** is the output file.

In Visual Studio, you can enable the generation of this documentation file in the project settings. If you use Mono, you can use the [/doc option](http://www.mono-project.com/docs/tools+libraries/tools/monodoc/generating-documentation/#inline-xml-documentation) of the Mono compiler to create the XML file.

## How it works

MarkdownDocNet looks at all the public types in the given assembly. If the type is not documented in the XML file, it is ignored.
It then generates the description of the type and a list of all members. Members are included even if no documentation is present.

Everything is then written to a single Markdown file, as specified in the command line.

MarkdownDocNet uses only some tags in the XML documentation. It focuses on creating a minimalistic reference document. The supported tags are:

* *&lt;summary&gt;* and *&lt;remarks&gt;*: These are concatenated and used as the description of types and members.
* *&lt;see&gt;*: Creates links as you would expect. The links will only work for types inside the current assembly.
* *&lt;example&gt;*: Adds a section "Examples" to the description. Only used for types. For class mebers, this is ignored.
* *&lt;code&gt;*: Formats the enclosed code.

Other tags, like *returns* or *param* are ignored. This is done to keep the documentation as simple as possible.

When creating the documentation for types, a single list of the members is created. No individual sections for the members are created.

## Compilation

If you want to build MarkdownDocNet from source, simply build the `MarkdownDocNet.sln` solution file. There are no external dependencies.

On Windows, open the solution in Visual Studio and build it.
    
On Linux, use xbuild:

    xbuild /t:Build /p:Configuration=Release MarkdownDocNet.sln

## License and contributing

This software is distributed under the terms of the MIT license. You can use it for your own projects for free under the conditions specified in LICENSE.txt.

If you have questions, feel free to contact me. Visit [lukas-boersma.com](https://lukas-boersma.com) for my contact details.

If you think you found a bug, you can open an Issue on Github. If you make changes to this tool, I would be happy about a pull request.

