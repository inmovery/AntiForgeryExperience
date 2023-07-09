namespace AntiForgeryExperience.Contracts.Entities;

/// <summary>
/// Контракт для структур данных, которые имеют идентификатор
/// </summary>
public interface IIdentifiable
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public int Id { get; set; }
}