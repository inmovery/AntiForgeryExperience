namespace AntiForgeryExperience.Contracts.Security;

public interface IAntiForgeryManager
{
    /// <summary>
    /// Генерация CSRF токена
    /// </summary>
    /// <returns>CSRF токен</returns>
    public string GenerateToken();

	/// <summary>
    /// Получение пары токенов (cookie и request)
    /// </summary>
    /// <returns>Экземпляр класса <see cref="AntiforgeryTokenSet"/></returns>
    public AntiforgeryTokenSet GetTokenSet();
}