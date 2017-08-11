namespace CppToCsharpConverter.Converters
{
    public interface IConverter
    {
        string Execute(string text, string pathToFile = null);
    }
}