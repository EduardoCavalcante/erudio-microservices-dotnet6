using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
   
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
    public IActionResult subtracao(string firstNumber, string secondNumber)
    {
        
        try
        {
            decimal sum = 0;

            if (IsNumeric(firstNumber) == false || IsNumeric(secondNumber) == false)
                throw new Exception("Invalid Input");

            sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        } catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
    public IActionResult multiplicacao(string firstNumber, string secondNumber)
    {

        try
        {
            decimal sum = 0;

            if (IsNumeric(firstNumber) == false || IsNumeric(secondNumber) == false)
                throw new Exception("Invalid Input");

            sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber , string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    
}
