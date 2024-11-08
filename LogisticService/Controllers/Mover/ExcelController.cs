using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using ExcelDataReader;
using OfficeOpenXml;

namespace LogisticService.Controllers.Mover
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ExcelController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
  

        [HttpPost("upload")]
        public IActionResult UploadExcelFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a file to upload.");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xls", StringComparison.OrdinalIgnoreCase) &&
                !Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file type. Please upload an Excel file (xls or xlsx).");
            }

            if (file.Length > 10 * 1024 * 1024)
            {
                return BadRequest("File size too large. Please upload a file smaller than 10 MB.");
            }


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            try
            {
                using (var stream = file.OpenReadStream())
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        var carTypesRepository = new CarTypeRepository(_dataContext);
                        var crashedRepository = new CrashedRepository(_dataContext);
                        var containerRepository = new ContainerRepository(_dataContext);
                        var directionRepository = new DirectionRepository(_dataContext);
                        var worksheet1 = package.Workbook.Worksheets["Sheet1"];
                        if (worksheet1 != null)
                        {
                            for (int row = 2; row <= worksheet1.Dimension.Rows; row++)
                            {
                                try
                                {
                                    var model = worksheet1.Cells[row, 1].Text;
                                    var coef = float.Parse(worksheet1.Cells[row, 2].Text);
                                    var carType = new CarType { Model = model, Coef = coef };
                                    carTypesRepository.Add(carType);
                                }
                                catch (Exception ex)
                                {
                                    BadRequest(ex.Message);
                                }
                            }
                        }
                        var worksheet2 = package.Workbook.Worksheets["Sheet2"];
                        if (worksheet2 != null)
                        {
                            for (int row = 2; row <= worksheet2.Dimension.Rows; row++)
                            {
                                try
                                {
                                    var isCrashed = bool.Parse(worksheet2.Cells[row, 1].Text);
                                    var coef = float.Parse(worksheet2.Cells[row, 2].Text);
                                    var crashed = new Crashed { IsCrashed = isCrashed, Coef = coef };
                                    crashedRepository.Add(crashed);
                                }
                                catch (Exception ex)
                                {
                                    BadRequest(ex.Message);
                                }
                            }
                        }
                        var worksheet3 = package.Workbook.Worksheets["Sheet3"];
                        if (worksheet3 != null)
                        {
                            for (int row = 2; row <= worksheet3.Dimension.Rows; row++)
                            {
                                try
                                {
                                    var isClosed = bool.Parse(worksheet3.Cells[row, 1].Text);
                                    var coef = float.Parse(worksheet3.Cells[row, 2].Text);
                                    var container = new Containers { IsClosed = isClosed, Coef = coef };
                                    containerRepository.Add(container);
                                }
                                catch (Exception ex)
                                {
                                    BadRequest(ex.Message);
                                }
                            }
                        }
                        var worksheet4 = package.Workbook.Worksheets["Sheet4"];
                        if (worksheet4 != null)
                        {
                            for (int row = 2; row <= worksheet3.Dimension.Rows; row++)
                            {
                                try
                                {
                                    var from = worksheet3.Cells[row, 1].Text;
                                    var to = worksheet3.Cells[row, 2].Text;
                                    var price = decimal.Parse(worksheet4.Cells[row, 3].Text);
                                    var distance = float.Parse(worksheet4.Cells[row,4].Text);
                                    var direction = new Direction { From1 = from, To1 = to,Price = price,Distance = distance};
                                    directionRepository.Add(direction);
                                }
                                catch (Exception ex)
                                {
                                    BadRequest(ex.Message);
                                }
                            }
                        }
                    }
                    return Ok("Excel file uploaded and processed successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the file.");
            }
        }
    }
    }

