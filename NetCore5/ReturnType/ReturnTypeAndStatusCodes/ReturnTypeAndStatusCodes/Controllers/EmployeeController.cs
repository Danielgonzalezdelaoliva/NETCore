using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnTypeAndStatusCodes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnTypeAndStatusCodes.Controllers
{

    //Metodos que devuelven specific type
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("Name")]
    //    public string GetName()
    //    {
    //        return "Return from GetName";
    //    }

    //    //método que devuelve un objeto tipo Employee en formato json
    //    [Route("Details")]
    //    public Employee GetEmployeeDetails()
    //    {
    //        return new Employee()
    //        {
    //            Id = 1001,
    //            Name = "Anurag",
    //            Age = 28,
    //            City = "Mumbai",
    //            Gender = "Male",
    //            Department = "IT"
    //        };
    //    }

    //    //método que devuelve una lista de tipo Employee en formato json
    //    [Route("All")]
    //    public List<Employee> GetAllEmployee()
    //    {
    //        return new List<Employee>()
    //        {
    //            new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
    //            new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
    //            new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
    //        };
    //    }

    //    //método que devuelve una lista IEnumerable de tipo Employee en formato json
    //    [Route("All2")]
    //    public IEnumerable<Employee> GetAllEmployee2()
    //    {
    //        return new List<Employee>()
    //        {
    //            new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
    //            new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
    //            new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
    //        };
    //    }


    //    [Route("All/Async")]
    //    public async IAsyncEnumerable<Employee> GetAllEmployeeAsync()
    //    {
    //        var listEmployees = new List<Employee>()
    //        {
    //            new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
    //            new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
    //            new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
    //        };
    //        foreach (var item in listEmployees)
    //        {
    //            yield return item;
    //        }
    //    }
    //}


    //métodos que devuelven IActionResult
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    //método que devuelve un OK si la hay empleados
    //    [Route("All")]
    //    public IActionResult GetAllEmployee()
    //    {
    //        var listEmployees = new List<Employee>()
    //                {
    //                    new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
    //                    new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
    //                    new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
    //                };
    //        if (listEmployees.Count > 0)
    //        {
    //            return Ok(listEmployees);
    //        }
    //        else
    //        {
    //            return NotFound();
    //        }
    //    }


    //    //para devolver un id especifico o un estado 404 (NotFound)
    //    //[Route("{Id}")]
    //    //public IActionResult GetEmployeeDetails(int Id)
    //    //{
    //    //    var listEmployees = new List<Employee>()
    //    //            {
    //    //                new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
    //    //                new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
    //    //                new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
    //    //            };
    //    //    var employee = listEmployees.FirstOrDefault(emp => emp.Id == Id);
    //    //    if (employee != null)
    //    //    {
    //    //        return Ok(employee);
    //    //    }
    //    //    else
    //    //    {
    //    //        return NotFound();
    //    //    }
    //    //}


    //    //con swagger no puede identificar identificar la salida 
    //    //debemos incluir los ProducesResponseType para que swagger identifique los tipos de estsado 200 o 404
    //    [Route("{Id}")]
    //    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    public IActionResult GetEmployeeDetails(int Id)
    //    {
    //        var listEmployees = new List<Employee>()
    //                {
    //                    new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
    //                    new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
    //                    new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
    //                };
    //        var employee = listEmployees.FirstOrDefault(emp => emp.Id == Id);
    //        if (employee != null)
    //        {
    //            return Ok(employee);
    //        }
    //        else
    //        {
    //            return NotFound();
    //        }
    //    }
    //}

    //metdos que devuelven IActionResult<T>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("{Id}")]
        public ActionResult<Employee> GetEmployeeDetails(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            else
            {
                return new Employee() { Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" };
            }
        }





    }
}
