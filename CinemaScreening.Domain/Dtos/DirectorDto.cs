using System;
using System.Collections.Generic;
using System.Text;
//using DapperAttribute = Dapper.Contrib.Extensions;

namespace CinemaScreening.Domain.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks> 
    /// We can notice, property FullName is not there in Director table and it will through error while perform insert operation. 
    ///To overcome this we need to find a way so that this property can be ignored while insert.
    ///To do this simply add [DapperAttribute.Computed] attribute on FullName.
    /// </remarks>
    public  sealed class DirectorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // [DapperAttribute.Computed]
        public string FullName { get; set; }

    }
}
