using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace StimulsoftReport.Controllers
{
    /// <summary>
    /// Контроллер работы с отчетами.
    /// </summary>
    [ApiController, Route("report")]
    public class ReportController : Controller
    {
        public ReportController()
        {
            // Лицензионный ключ необходимый для активации.
            // Чувствителен к версии Stimulsoft. Для этого ключа нужна именно версия 2020.1.1.
            StiLicense.Key ??= "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHnVa+Da9S68x+QAYwx/k1ZpVrYbeVsKM1k7aFyswiWZqDM99Y" + "ybVLwqjsDRr3Jr7nDn9wFvWCXjH5E8sgcdiaTSnQqfrXA+X9ygIdiXzsC9xG9XOb1VBmS/tgW8GZeHPZXQmYCrll0L" + "h0mhw+SWgklpv3x+/0TkwNH32xNwCzI+K3Z2nYjJOT5biy/8HGh9us+AQR63dllGWrJiT5mUiosQAIYdqwKchCZlk4" + "pKQpn8jVgc2AdM/PUWhZe4ADYoVSW1rMOiaWI0Tf6TnRJUdBfOdz8XaAoMrBLo8VPmwcOGP8829LYBESLbFNsUg41L" + "P7rKbdrMwkpLoBvQJV9Wu6zcQxrEauihIXEt7c7D1eVo74X11nSg7K6f5TuJ5x4R5GizJb43y3sOsq/UBRZQuGF0q/" +
                               "isQAzi5euKrIcg84sacpI61O7cqqubKegRGFUvrkslcSK+1sej4G3iRuUI5VdVaEEfgOV+kGGO5mxER+NY4IBbAtsf" + "vtEG4hQkdjh4hDaBl60z7SvzaDFbMAYS7J0sG9D2fzBSaapA3u+yfnSNww==";
        }

        /// <summary>
        /// Метод экспортирует шаблон в PDF, изменив перед этим отрисовку нужным образом.
        /// </summary>
        [HttpPost, Route("get-report")]
        public async Task<IActionResult> GetReport()
        {
            StiReport report = new StiReport();

            // Загрузит шаблон отчета из папки.
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/ReportV3.mrt"));

            // Рендерит отчет.
            await report.RenderAsync();

            // Экспорт в PDF в указанную папку.
            await report.ExportDocumentAsync(StiExportFormat.Pdf, @"C:\StimulsoftReports\ReportResult.pdf");

            return Ok("Save success");
        }
    }
}