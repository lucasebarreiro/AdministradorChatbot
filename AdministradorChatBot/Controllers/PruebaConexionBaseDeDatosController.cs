using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

public class PruebaController : Controller
{
    private readonly IConfiguration _config;

    public PruebaController(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult TestConexion()
    {
        string cadena = _config.GetConnectionString("DefaultConnection");
        try
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                return Content("Conexión exitosa a ChatbotAdminDB.");
            }
        }
        catch (Exception ex)
        {
            return Content($"Error de conexión: {ex.Message}");
        }
    }
}
