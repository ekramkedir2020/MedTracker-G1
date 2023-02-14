
namespace MedAdvisor.DataAccess.Mysql
{
    public class Diagnose
    {
        public int UserId { get; set; }
        public int DiagnoseId { get; set; }
        public string DiagnoseName { get; set; } = string.Empty;
    }
}