using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Models;
using Students.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        
        private readonly CourseService _courseService;
        public CoursesController(CourseService cService)
        {
           
            _courseService = cService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(string id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }


        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult<Course>> GetById(string id)
        //{
        //    var student = await _studentService.GetByIdAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    if (student.Courses.Count > 0)
        //    {
        //        var tempList = new List<Course>();
        //        foreach (var courseId in student.Courses)
        //        {
        //            var course = await _courseService.GetByIdAsync(courseId);
        //            if (course != null)
        //                tempList.Add(course);
        //        }
        //        student.CourseList = tempList;
        //    }
        //    return Ok(student);
        //}
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            await _courseService.CreateAsync(course);
            return Ok(course);
        }
        [HttpPut]
        public async Task<IActionResult> Update(string id, Course updatedCourse)
        {
            var queriedcourse = await _courseService.GetByIdAsync(id);
            if (queriedcourse == null)
            {
                return NotFound();
            }
            await _courseService.UpdateAsync(id, updatedCourse);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            await _courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}