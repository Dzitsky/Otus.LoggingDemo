using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Otus.LoggingDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILogger<string> _slogger;

        public LogController(
            ILogger<LogController> logger,
            ILoggerFactory factory)
        {
            _slogger = factory.CreateLogger<string>();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogThings()
        {
            _logger.LogInformation("Я логирую обычный текст");
            _logger.LogWarning("Я Warning");
            _logger.LogError("А я - ошибку!");
            _logger.LogCritical("Что-то критичное!");
            _logger.LogTrace("И не очень");
            
            _slogger.LogError("Я slogger");

            return Ok(new { Ok = true });
        }

                [HttpGet("fail")]
        public IActionResult Fail()
        {
            //throw new Exception("Я очень серьезная ошибка!");

            try
            {
                throw new Exception("Err!");
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, "Error!");
                return Ok(new { ok = false });
            }
        }

        [HttpPost]
        public IActionResult LogThingsPost([FromBody] User user)
        {
            _logger.LogInformation("Я логирую пользователя {@user}", user);

            var a = new Foo { A = 4 };
            _logger.LogInformation("Я логирую as is {user} {Now} {$a}", user, DateTime.Now, a);
            return Ok(new { Ok = true });
        }

        #region Объекты для логирования

        public class Foo
        {
            public int A { get; set; }

            public override string ToString()
            {
                return $"Я объект {A}";
            }
        }

        public class User
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        #endregion
    }
}