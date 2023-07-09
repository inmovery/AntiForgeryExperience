namespace AntiForgeryExperience.Configuration;

/// <summary>
/// Модель данных, представляющая список строк подключения к шинам и базам данных
/// </summary>
public class ConnectionStringsModels
{
	/// <summary>
	/// Строка подключения к MS SQL
	/// </summary>
	public string MsSqlDatabase { get; set; } = default!;
}