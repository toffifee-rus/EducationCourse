namespace Task2;

/// <summary>
/// Атрибут задачи
/// </summary>
public class Task2Attribute : Attribute
{
    /// <summary>
    /// Название атрибута
    /// </summary>
    public string Name;

    /// <summary>
    /// Версия атрибута
    /// </summary>
    public string Version;

    /// <summary>
    /// Конструктор атрибута
    /// </summary>
    /// <param name="Name">Название Задачи</param>
    /// <param name="Version">Версия Задачи</param>
    public Task2Attribute(string name, string version)
    {
        this.Name = name;
        this.Version = version;
    }
}