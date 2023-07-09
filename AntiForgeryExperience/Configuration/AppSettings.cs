namespace AntiForgeryExperience.Configuration;

/// <summary>
/// Модель данных, представляющая конфигурацию приложения
/// </summary>
public class AppSettings
{
	/// <summary>
	/// Строки подключения к шинам и базам данных
	/// </summary>
	public ConnectionStringsModels ConnectionStrings { get; set; } = default!;
}