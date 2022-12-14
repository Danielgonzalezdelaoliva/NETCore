using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingInASPNETCoreWebAPI.Controllers
{
    //Default
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //}


    //Definición básica de métodos
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("Emp/All")]
    //    public string GetAllEmployees()
    //    {
    //        return "Response from GetAllEmployees Method";
    //    }
    //    [Route("Emp/ById")]
    //    public string GetEmployeeById()
    //    {
    //        return "Response from GetEmployeeById Method";
    //    }
    //}



    //Definición con variables en el route
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("Employee/{Id}")]
    //    public string GetEmployeeById(int Id)
    //    {
    //        return $"Return Employee Details : {Id}";
    //    }
    //}


    //Definición con variables solo en el método
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("Employee/Search")]
    //    public string SearchEmployees(string Department)
    //    {
    //        return $"Return Employees with Department : {Department}";
    //    }
    //}


    //Acceder al mismo recurso/método con diferentes URL
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("Employee/All")]
    //    [Route("AllEmployees")]
    //    [Route("Employee/GetAll")]
    //    public string GetAllEmployees()
    //    {
    //        return "Response from GetAllEmployees Method";
    //    }
    //}

    //acceso mediante token
    //[ApiController]
    //[Route("[controller]")]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("[action]")]
    //    public string GetAllEmployees()
    //    {
    //        return "Response from GetAllEmployees Method";
    //    }
    //    [Route("[action]")]
    //    public string GetAllDepartment()
    //    {
    //        return "Response from GetAllDepartment Method";
    //    }
    //}


    //acceso al método con restricción en el parámetro
    //[ApiController]
    //[Route("api/[controller]")]
    //public class EmployeeController : ControllerBase
    //{
    //    [Route("{EmployeeId:int}")]
    //    public string GetEmployeeDetails(int EmployeeId)
    //    {
    //        return $"Response from GetEmployeeDetails Method, EmployeeId : {EmployeeId}";
    //    }
    //    [Route("{EmployeeName}")]
    //    public string GetEmployeeDetails(string EmployeeName)
    //    {
    //        return $"Response from GetEmployeeDetails Method, EmployeeName : {EmployeeName}";
    //    }
    //}


    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        //acceso al método con valor mínimo en el parámetro
        [Route("{EmployeeId:int:min(1000)}")]
        public string GetEmployeeDetails(int EmployeeId)
        {
            return $"Response from GetEmployeeDetails Method, EmployeeId : {EmployeeId}";
        }
    }
}



