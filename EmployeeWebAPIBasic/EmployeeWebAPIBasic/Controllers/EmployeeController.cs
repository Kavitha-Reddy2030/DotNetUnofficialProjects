using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebAPIBasic.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/employee
        [HttpGet]
        [Route("api/employee")]
        public IHttpActionResult Get()
        {
            try
            {
                using (EmployeeDbEntities entities = new EmployeeDbEntities())
                {
                    var employees = entities.Employees.ToList();
                    if (employees == null || !employees.Any())
                    {
                        return NotFound();
                    }
                    return Ok(employees);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/employee/5
        [HttpGet]
        [Route("api/employee/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (EmployeeDbEntities entities = new EmployeeDbEntities())
                {
                    var employee = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

}